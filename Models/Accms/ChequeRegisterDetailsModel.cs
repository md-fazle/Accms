namespace ACCMS_AGH.Models.Accms
{
    public class ChequeRegisterDetailsModel
    {
        public int SL { get; set; }
        public string? LEDGERNO { get; set; }
        public string? PARTY_NAME { get; set; }
        public string? CHEQ_NO { get; set; }
        public DateTime? CHEQ_DATE { get; set; }
        public decimal? CHEQ_AMOUNT { get; set; }
        public string? SIGNBY { get; set; }
        public string? ALLOTMENTBY { get; set; }
        public DateTime? VALIDTILL { get; set; }
        public string? REMARKS { get; set; }
        public string? PAYMENTTYPE { get; set; }
        public DateTime? ENTRY_DATE { get; set; }
        public string? TRNSNO { get; set; }
        public string? TNS_TYPE { get; set; }
        public DateTime? TRNS_DATE { get; set; }
        public int BANK_ID { get; set; }
        public string? BANK_NAME { get; set; }
        public string? ACC_NO { get; set; }
        public string? ROUTING_NO { get; set; }
        public string? BEF_NAME { get; set; }
        public string? NOTE { get; set; }
    }
}
