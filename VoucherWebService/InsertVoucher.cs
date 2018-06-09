using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Configuration;
using IE.Entities;
using DelphiEntities.LinQ;
using VoucherWebService.FinVoucher;

namespace VoucherWebService
{

    public class InsertVoucher
    {
        const string BaseAddressResolverServiceRelativeAddress = "/BaseAddressResolver.svc";
        const string AuthenticationServiceRelativeAddress = "/Services/Framework/AuthenticationService.svc";
        const string VoucherServiceRelativeAddress = "/Services/Financial/VoucherManagementService.svc";
        string sgPath;
        public string UserName { get; set; }
        public string Password { get; set; }
        public long BranchRef;
        public long LedgerRef;
        public long VoucherTypeRef;
        public long FiscalYearRef;
        DelphiEntities.LinQ.DelphiDataContext db;
        IE.Entities.IEContext ie;
        RahkaranEntities.G3Context g3;

        public InsertVoucher(string sgPath, RahkaranEntities.G3Context g3,
            DelphiEntities.LinQ.DelphiDataContext db, IE.Entities.IEContext ie)
        {
            this.sgPath = sgPath;
            this.db = db;
            this.g3 = g3;
            this.ie = ie;
        }

        public bool InsertVoucherToSg3(List<DelphiEntities.LinQ.AccVchHdr> final)
        {
            //از نسخه 34 به بعد باید این گزینه false شود
            RestServiceClient(this.sgPath, false);
            string authCookie = "";
            WebClient client = new WebClient();
            // در این جا نام کاربری و رمز عبور راهکاران را وارد می کنیم. سایر پارامتر ها را مانند زیر تنظیم می کنیم
            var sessionID = Login(client, UserName, Password, out authCookie);

            client.Headers["Set-Cookie"] = authCookie;
            client.Headers["content-Type"] = "application/json";
            client.Encoding = Encoding.UTF8;

            var configResult = ReadConfigurations();
            if (!configResult)
                return false;
            else
            {

                try
                {
                    foreach (var i in final)
                    {
                        FinVoucher.VoucherData vd = new FinVoucher.VoucherData();
                        // در این جا مقدار کلید اصلی جدول 
                        // GNR3.Branch
                        // را وارد می کنیم 
                        // مثلا کد ۷
                        vd.BranchRef = BranchRef;
                        // در این جا تاریخ سند را درج می کنیم. در این جا از آدرس حال حاضر استفاده شده است
                        vd.Date = DateTime.Today;
                        // در این بخش شرح سند را وارد می کنیم
                        vd.Description = i.HdrDesc;
                        // در این جا مقدار کلید اصلی جدول 
                        // GNR3.Ledger
                        // را وارد می کنیم 
                        // مثلا کد 1
                        // که نشان دهنده ی دفتر کل اصلی است
                        vd.LedgerRef = LedgerRef;
                        // در این جا مقدار کلید اصلی جدول 
                        // Fin3.VoucherType
                        // را وارد می کنیم 
                        // مثلا کد 1
                        // که نشان دهنده ی نوع حساب است
                        vd.VoucherTypeRef = GetVoucherTypeRef(i.Ctgry.Trim());
                        // در این جا مقدار کلید اصلی جدول 
                        // GNR3.FiscalYear
                        // را وارد می کنیم 
                        // مثلا کد 3
                        // که نشان دهنده ی کد سال مالی است
                        vd.FiscalYearRef = FiscalYearRef;

                        vd.VoucherItems = GetVoucherItems(i);
                        //            new[]
                        //        {
                        //    new FinVoucher.VoucherItemData
                        //    { 
                        //        // شماره سطر که برای هر قلم به ترتیب از ۱ شماره گذاری می شود
                        //        RowNumber = 1,
                        //        // میزان بدهکار در این مثال ۱۰ لحاظ شده
                        //        Credit = 10,
                        //        // شرح قلم سند 
                        //        Description = "شرح تستي",
                        //        // کد معین فلم را در اینجا وارد می کنیم
                        //        SLCode = "111001",
                        //        // تفصیلی سطح ۴ را در صورتی که نیاز بود در این جا وارد می کنیم
                        //        DL4 = "000001",
                        //        // تفصیلی سطح ۴ را در صورتی که نیاز بود در این جا وارد می کنیم

                        //    },
                        //    new FinVoucher.VoucherItemData
                        //    { 
                        //        // شماره سطر که برای هر قلم به ترتیب از ۱ شماره گذاری می شود
                        //        RowNumber = 1,
                        //        // میزان بستانکار در این مثال ۱۰ لحاظ شده
                        //        Debit = 10,
                        //        // شرح قلم سند 
                        //        Description = "شرح تستي",
                        //        // کد معین فلم را در اینجا وارد می کنیم
                        //        SLCode = "111001",
                        //        // تفصیلی سطح ۴ را در صورتی که نیاز بود در این جا وارد می کنیم
                        //        DL4 = "000001",
                        //        // تفصیلی سطح ۴ را در صورتی که نیاز بود در این جا وارد می کنیم

                        //    }
                        //};

                        var data = WriteObject<FinVoucher.VoucherData>(vd);
                        var result = client.UploadString(VoucherServiceAddress + "/RegisterVoucher",
                           "POST", data);
                        var resultInfo = ReadObject<FinVoucher.VoucherInfo>(result);
                        MessageBox.Show(result);
                    }
                    //Done, logging out of Rahkaran
                    client.UploadString(AuthenticationServiceAddress + "/logout", WriteObject(sessionID));
                    client.Dispose();

                    // نمایش نتیجه ی عملیات

                }
                catch (WebException webEx)
                {
                    if (webEx.Response != null)
                    {
                        //نمایش خطا در صورت وجود
                        MessageBox.Show(HandleError(webEx));
                    }
                    else
                    {
                        MessageBox.Show("Unknown Error!");
                    }
                }



            }


            return true;
        }

        private VoucherItemData[] GetVoucherItems(AccVchHdr hdr)
        {
            var items = db.AccVchItms.Where(w => w.HdrRef == hdr.HdrVchID).ToList();
            var feedList = new VoucherItemData[items.Count];
            var counter = 0;
            var q = new FinVoucher.VoucherItemData();
            string d1 = null, d2 = null, d3 = null;
            foreach (var i in items)
            {
                if (i.DLRef != null)
                    d1 = i.DLRef.Trim();
                if (i.DlFive != null)
                    d2 = i.DlFive.Trim();
                if (i.DlSix != null)
                    d3 = i.DlSix.Trim();
                if (i.Debit == 0)
                {
                    q = new FinVoucher.VoucherItemData
                    {
                        // شماره سطر که برای هر قلم به ترتیب از ۱ شماره گذاری می شود
                        RowNumber = counter+1,
                        // میزان بستانکار در این مثال ۱۰ لحاظ شده                                            
                        Credit = decimal.Parse(i.Credit.ToString()),
                        // شرح قلم سند 
                        Description = i.Descr,
                        // کد معین فلم را در اینجا وارد می کنیم
                        SLCode = i.SLRef.Trim(),
                        // تفصیلی سطح ۴ را در صورتی که نیاز بود در این جا وارد می کنیم                        
                        DL4 = d1,
                        DL5 = d2,
                        DL6 = d3
                        // تفصیلی سطح ۴ را در صورتی که نیاز بود در این جا وارد می کنیم

                    };
                }

                else if (i.Credit == 0)
                {
                    q = new FinVoucher.VoucherItemData
                    {
                        // شماره سطر که برای هر قلم به ترتیب از ۱ شماره گذاری می شود
                        RowNumber = counter+1,
                        // میزان بستانکار در این مثال ۱۰ لحاظ شده                    
                        Debit = decimal.Parse(i.Debit.ToString()),
                        // شرح قلم سند 
                        Description = i.Descr,
                        // کد معین فلم را در اینجا وارد می کنیم
                        SLCode = i.SLRef.Trim(),
                        // تفصیلی سطح ۴ را در صورتی که نیاز بود در این جا وارد می کنیم
                        DL4 = d1,
                        DL5 = d2,
                        DL6 = d3
                        // تفصیلی سطح ۴ را در صورتی که نیاز بود در این جا وارد می کنیم

                    };
                }
                feedList[counter] = q;
                counter++;
            }

            return feedList;
        }

        private long? GetVoucherTypeRef(string v)
        {
            long VoucherTypeRef = 0;
            var q = ie.VoucherTypeMaps.Where(w => w.DelphiVoucherTypeRef.ToString() == v).ToList();
            if (q.Count != 0)
            {
                VoucherTypeRef = ie.VoucherTypeMaps.Where(w => w.DelphiVoucherTypeRef.ToString() == v).Single().Fin3VoucherTypeRef;
            }
            return VoucherTypeRef;
        }

        private bool ReadConfigurations()
        {
            var iEConnectionString = ConfigurationManager.ConnectionStrings["IEConnectionString"].ConnectionString;
            IEContext ie = new IEContext(iEConnectionString);
            if (ie.Configurations.Where(w => w.Name == "Branch").Count() == 0)
            {
                return false;
            }
            else
            {
                var q = ie.Configurations.Where(w => w.Name == "Branch").Single();
                BranchRef = long.Parse(q.Value);
            }

            if (ie.Configurations.Where(w => w.Name == "Ledger").Count() == 0)
            {
                return false;
            }
            else
            {
                var q = ie.Configurations.Where(w => w.Name == "Ledger").Single();
                LedgerRef = long.Parse(q.Value);
            }

            if (ie.Configurations.Where(w => w.Name == "FiscalYear").Count() == 0)
            {
                return false;
            }
            else
            {
                var q = ie.Configurations.Where(w => w.Name == "FiscalYear").Single();
                FiscalYearRef = long.Parse(q.Value);
            }
            return true;
        }

        public string AuthenticationServiceAddress;

        public string VoucherServiceAddress;

        public string WriteObject<T>(T anObject)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, anObject);
            return Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
        }

        private static string HandleError(WebException webEx)
        {
            using (var stream = new StreamReader(webEx.Response.GetResponseStream()))
            {
                string details = stream.ReadToEnd();

                //Any errors can be retrieved this way
                var code = webEx.Response.Headers["ERROR_CODE"];
                var message = webEx.Response.Headers["ERROR_MESSAGE"];
                if (!string.IsNullOrEmpty(message))
                {
                    message = Encoding.UTF8.GetString(Convert.FromBase64String(message));
                }

                var error = string.Format("Error Code = {0}, Message = {1}, \n Detail = {2}", code, message, details);
                return error;
                // throw new Exception(error);
            }
        }

        public string Login(WebClient client, string userName, string password, out string authCookie)
        {
            ///
            //WebClient client = new WebClient();
            var result = string.Empty;
            try
            {
                result = client.DownloadString(AuthenticationServiceAddress + "/session");
            }
            catch (WebException exception)
            {
                string responseText;

                if (exception.Response != null)
                {
                    var responseStream = exception.Response.GetResponseStream();

                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseText = reader.ReadToEnd();
                        }
                    }
                }
            }

            var session = ReadObject<Infra.AuthenticationSession>(result);

            var m = HexStringToBytes(session.rsa.M);
            var e = HexStringToBytes(session.rsa.E);

            var rsa = new RSACryptoServiceProvider(1024);
            rsa.ImportParameters(new RSAParameters { Exponent = e, Modulus = m });

            var sessionPlusPassword = session.id + "**" + password;

            client.Headers["content-Type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            //client.UploadString(AuthenticationServiceAddress + "/login", "POST",
            //    string.Format("{{\"sessionId\":\"{0}\",\"username\":\"{1}\",\"password\":\"{2}\"}}", session.id, userName, BytesToHexString(rsa.Encrypt(Encoding.Default.GetBytes(sessionPlusPassword), false))));

            ExtendedIdentity ei;
            ei.sessionId = session.id;
            ei.username = userName;
            ei.password = BytesToHexString(rsa.Encrypt(Encoding.Default.GetBytes(sessionPlusPassword), false));
            var data = WriteObject(ei);

            client.UploadString(AuthenticationServiceAddress + "/login", "POST", data);
            authCookie = client.ResponseHeaders["Set-Cookie"].Split(',')[1];
            return session.id;
        }

        public void RestServiceClient(string baseWebAddress, bool configureBasedOnSgVirtualPath)
        {
            if (!configureBasedOnSgVirtualPath)
            {
                AuthenticationServiceAddress = baseWebAddress + AuthenticationServiceRelativeAddress;
                VoucherServiceAddress = baseWebAddress + VoucherServiceRelativeAddress;
            }
            else
            {
                try
                {
                    string baseAddressResolverService = baseWebAddress + BaseAddressResolverServiceRelativeAddress;
                    WebClient client = new WebClient();

                    string redirectorAddress = client.DownloadString(baseAddressResolverService + "/GetBaseAddress");
                    redirectorAddress = ReadObject<string>(redirectorAddress);
                    baseWebAddress = baseWebAddress.Substring(0, baseWebAddress.LastIndexOf("/"));

                    AuthenticationServiceAddress = baseWebAddress + redirectorAddress + AuthenticationServiceRelativeAddress;
                    VoucherServiceAddress = baseWebAddress + redirectorAddress + VoucherServiceRelativeAddress;
                }
                catch (WebException webEx)
                {
                    if (webEx.Response != null)
                    {
                        //نمایش خطا در صورت وجود                     
                        MessageBox.Show(HandleError(webEx));
                    }
                    else
                    {
                        MessageBox.Show("Unknown Error!");
                    }
                }


            }
        }

        private static T ReadObject<T>(string jsonData)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(jsonData);
            writer.Flush();
            stream.Position = 0;
            return (T)js.ReadObject(stream);
        }

        private static byte[] HexStringToBytes(string hex)
        {
            if (hex.Length == 0)
            {
                return new byte[] { 0 };
            }

            if (hex.Length % 2 == 1)
            {
                hex = "0" + hex;
            }

            byte[] result = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length / 2; i++)
            {
                result[i] = byte.Parse(hex.Substring(2 * i, 2), NumberStyles.AllowHexSpecifier);
            }

            return result;
        }

        private static string BytesToHexString(byte[] input)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int i = 0; i < input.Length; i++)
            {
                hexString.Append(String.Format("{0:X2}", input[i]));
            }
            return hexString.ToString();
        }
    }

    [Serializable]
    struct ExtendedIdentity
    {
        [DataMember(Order = 1)]
        public string sessionId;
        [DataMember(Order = 2)]
        public string username;
        [DataMember(Order = 3)]
        public string password;
    }

}
