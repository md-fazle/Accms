using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCMS_AGH.Models.Accms
{
    public class ChequeRegisterDetails
    {
      
        [Column("BANK_ID")]
        public int BankId { get; set; }

        [Required]
        [Column("BANK_NAME")]
        [StringLength(150)]
        public string? BankName { get; set; }

        [Required]
        [Column("ACC_NO")]
        [StringLength(70)]
        public string? AccountNumber { get; set; }


        [Column("ACTIVE")]
        public int Active { get; set; }


        [Column("BRANCH")]
        [StringLength(100)]
        public string? Branch { get; set; }


        [Column("ROUTING_NO")]
        [StringLength(12)]
        public string? RoutingNumber { get; set; }

  
        [Column("ACC_TYPE")]
        [StringLength(50)]
        public string? AccountType { get; set; }

     
        [Column("ACCOUNT_NAME")]
        [StringLength(100)]
        public string? AccountName { get; set; }

        [Required]
        [StringLength(50)]
        public string? CHQ_NO { get; set; }

        public DateTime? CHEQ_DATE { get; set; }

        public decimal? CHEQ_AMOUNT { get; set; }

        [StringLength(150)]
        public string? PARTY_NAME { get; set; }

        [StringLength(50)]
        public string? SIGNBY { get; set; }

        public DateTime? ENTRY_DATE { get; set; }

        [StringLength(150)]
        public string? REMARKS { get; set; }

        [StringLength(10)]
        public string? TNS_TYPE { get; set; }

        [StringLength(50)]
        public string? LEDGERNO { get; set; }

        [StringLength(25)]
        public string? PAYMENTTYPE { get; set; }

        [StringLength(25)]
        public string? TRNSNO { get; set; }

        public DateTime? TRNS_DATE { get; set; }

        [StringLength(18)]
        public string? ALLOTMENTBY { get; set; }

        public DateTime? VALIDTILL { get; set; }

        [StringLength(16)]
        public string? MAC_ID { get; set; }

        [StringLength(16)]
        public string? LOC_ID { get; set; }

        [StringLength(16)]
        public string? COMP_ID { get; set; }

        [StringLength(25)]
        public string? ENTRYBY { get; set; }
    }
}
