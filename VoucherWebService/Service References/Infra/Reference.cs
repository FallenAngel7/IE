﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VoucherWebService.Infra {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticationSession", Namespace="http://schemas.datacontract.org/2004/07/SystemGroup.Web.Hosting.REST")]
    [System.SerializableAttribute()]
    public partial class AuthenticationSession : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private VoucherWebService.Infra.AuthenticationSession.RSAPublicParameters rsaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                if ((object.ReferenceEquals(this.idField, value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public VoucherWebService.Infra.AuthenticationSession.RSAPublicParameters rsa {
            get {
                return this.rsaField;
            }
            set {
                if ((object.ReferenceEquals(this.rsaField, value) != true)) {
                    this.rsaField = value;
                    this.RaisePropertyChanged("rsa");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticationSession.RSAPublicParameters", Namespace="http://schemas.datacontract.org/2004/07/SystemGroup.Web.Hosting.REST")]
        [System.SerializableAttribute()]
        public partial class RSAPublicParameters : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
            
            [System.NonSerializedAttribute()]
            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string MField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string EField;
            
            public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
                get {
                    return this.extensionDataField;
                }
                set {
                    this.extensionDataField = value;
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string M {
                get {
                    return this.MField;
                }
                set {
                    if ((object.ReferenceEquals(this.MField, value) != true)) {
                        this.MField = value;
                        this.RaisePropertyChanged("M");
                    }
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
            public string E {
                get {
                    return this.EField;
                }
                set {
                    if ((object.ReferenceEquals(this.EField, value) != true)) {
                        this.EField = value;
                        this.RaisePropertyChanged("E");
                    }
                }
            }
            
            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
            
            protected void RaisePropertyChanged(string propertyName) {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
                if ((propertyChanged != null)) {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Infra.IAuthenticationService")]
    public interface IAuthenticationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetNewAuthenticationSession", ReplyAction="http://tempuri.org/IAuthenticationService/GetNewAuthenticationSessionResponse")]
        VoucherWebService.Infra.AuthenticationSession GetNewAuthenticationSession();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetNewAuthenticationSession", ReplyAction="http://tempuri.org/IAuthenticationService/GetNewAuthenticationSessionResponse")]
        System.Threading.Tasks.Task<VoucherWebService.Infra.AuthenticationSession> GetNewAuthenticationSessionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/Login", ReplyAction="http://tempuri.org/IAuthenticationService/LoginResponse")]
        void Login(string sessionId, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/Login", ReplyAction="http://tempuri.org/IAuthenticationService/LoginResponse")]
        System.Threading.Tasks.Task LoginAsync(string sessionId, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetCurrentDateTime", ReplyAction="http://tempuri.org/IAuthenticationService/GetCurrentDateTimeResponse")]
        System.DateTime GetCurrentDateTime();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetCurrentDateTime", ReplyAction="http://tempuri.org/IAuthenticationService/GetCurrentDateTimeResponse")]
        System.Threading.Tasks.Task<System.DateTime> GetCurrentDateTimeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/Logout", ReplyAction="http://tempuri.org/IAuthenticationService/LogoutResponse")]
        void Logout(string sessionID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/Logout", ReplyAction="http://tempuri.org/IAuthenticationService/LogoutResponse")]
        System.Threading.Tasks.Task LogoutAsync(string sessionID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticationServiceChannel : VoucherWebService.Infra.IAuthenticationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationServiceClient : System.ServiceModel.ClientBase<VoucherWebService.Infra.IAuthenticationService>, VoucherWebService.Infra.IAuthenticationService {
        
        public AuthenticationServiceClient() {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public VoucherWebService.Infra.AuthenticationSession GetNewAuthenticationSession() {
            return base.Channel.GetNewAuthenticationSession();
        }
        
        public System.Threading.Tasks.Task<VoucherWebService.Infra.AuthenticationSession> GetNewAuthenticationSessionAsync() {
            return base.Channel.GetNewAuthenticationSessionAsync();
        }
        
        public void Login(string sessionId, string username, string password) {
            base.Channel.Login(sessionId, username, password);
        }
        
        public System.Threading.Tasks.Task LoginAsync(string sessionId, string username, string password) {
            return base.Channel.LoginAsync(sessionId, username, password);
        }
        
        public System.DateTime GetCurrentDateTime() {
            return base.Channel.GetCurrentDateTime();
        }
        
        public System.Threading.Tasks.Task<System.DateTime> GetCurrentDateTimeAsync() {
            return base.Channel.GetCurrentDateTimeAsync();
        }
        
        public void Logout(string sessionID) {
            base.Channel.Logout(sessionID);
        }
        
        public System.Threading.Tasks.Task LogoutAsync(string sessionID) {
            return base.Channel.LogoutAsync(sessionID);
        }
    }
}