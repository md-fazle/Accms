using System.ComponentModel.DataAnnotations;

namespace ACCMS_AGH.Models.Accms
{
    public class ChequeRegisterMaster
    {

   
        [Required]
        [StringLength(50)]
        public string? CHQ_NO { get; set; }

        public int? BANK_ID { get; set; }

        public int? ACTIVE { get; set; }

        [StringLength(50)]
        public string? ACTIVATEDBY { get; set; }

        [StringLength(20)]
        public string? TRNSNO { get; set; }

        [StringLength(10)]
        public string? STATUS { get; set; }

        [StringLength(250)]
        public string? NOTE { get; set; }

        [StringLength(18)]
        public string? MAC_ID { get; set; }

        [StringLength(18)]
        public string? LOC_ID { get; set; }

        public int? ISALLOTMENT { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(12)]
        public string? ENTRYBY { get; set; }

        [StringLength(16)]
        public string? COMP_ID { get; set; }
    }
}
