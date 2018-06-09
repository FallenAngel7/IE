using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RahkaranEntities
{
    [Table("Fin3.DL")]
    public class DL
    {
        [Key]
        public long DLID { get; set; }
        public long DLTypeRef { get; set; }
        public long ReferenceID { get; set; }        
        public string Code { get; set; }
        public string Title { get; set; }
        public string Title_En { get; set; }
        public long CurrencyRef { get; set; }
        public int EntityCode { get; set; }
        public string Discriminator { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
    }
}
