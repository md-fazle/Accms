using System.ComponentModel.DataAnnotations;

namespace ACCMS_AGH.Models.Accms
{
    public class AccountLedger
    {

        [Required]
        [StringLength(30)]
        public string? L_CODE { get; set; }

        [Required]
        public decimal? L_SERIAL { get; set; }

        [Required]
        [StringLength(100)]
        public string? L_NAME { get; set; }

        [StringLength(5)]
        public string? CURRENCY_SYMBOL { get; set; }

        [Required]
        [StringLength(30)]
        public string? GR_CODE { get; set; }

        [StringLength(100)]
        public string? PARENT_GROUP { get; set; }

        [StringLength(100)]
        public string? ONE_DOWN { get; set; }

        [StringLength(100)]
        public string? PARTY_UNDER { get; set; }

        [StringLength(100)]
        public string? LEDGER_NAME_DEFAULT { get; set; }

        public int? L_STATUS { get; set; }

        public decimal? OPENING_BALANCE { get; set; }

        public decimal? FC_OPENING_BALANCE { get; set; }

        public decimal? CLOSING_BALANCE { get; set; }

        public decimal? DEBIT_AMOUNT { get; set; }

        public decimal? CREDIT_AMOUNT { get; set; }

        [StringLength(10)]
        public string? CURRENCY_NAME { get; set; }

        public char? L_NATURE { get; set; }

        public int? L_LEVEL { get; set; }

        public int? L_GROUP { get; set; }

        public int? PRIMARY_TYPE { get; set; }

        [StringLength(100)]
        public string? PRIMARY_GROUP { get; set; }

        public int? L_DEFAULT { get; set; }

        public int? REP_COMMISSION_TYPE { get; set; }

        public decimal? REP_COMMISSION { get; set; }

        [StringLength(4)]
        public string? LOC_ID { get; set; }

        [StringLength(20)]
        public string? MAC_ID { get; set; }

        [StringLength(4)]
        public string? COMP_ID { get; set; }

        public DateTime? INSERT_DATE { get; set; }

        [StringLength(60)]
        public string? ENTRY_BY { get; set; }

        [StringLength(60)]
        public string? UPDATED_BY { get; set; }

        public DateTime? UPDATE_DATE { get; set; }

        public int? CASH_FLOW_TYPE { get; set; }

        public int? COST_CENTER_STATUS { get; set; }

        [StringLength(30)]
        public string? L_CODE_ALLOC { get; set; }

        [StringLength(30)]
        public string? L_CODE_GR_CODE { get; set; }

        [StringLength(30)]
        public string? LCCODE_ACCOUNTS { get; set; }

        [StringLength(4)]
        public string? BRANCHID { get; set; }




    }
}
