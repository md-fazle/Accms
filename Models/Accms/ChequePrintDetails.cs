namespace ACCMS_AGH.Models.Accms
{
    public class ChequePrintDetails
    {
        public string? cp_LedgerNo { get; set; }
        public string? cp_Party_Name { get; set; }
        public string? Cheque_No { get; set; }
        public DateTime? cp_ChequeDate { get; set; }
        public double cp_Amount { get; set; }
        public string? cp_SignBy { get; set; }
        public string? cp_AllotmentBy { get; set; }
        public DateTime? cp_ValidTill { get; set; }
        public string? cp_Remarks { get; set; }
        public string? PAYMENTTYPE { get; set; }
        public DateTime? cp_Entrydate { get; set; }
        public string? cp_trnsNo { get; set; }
        public string? cp_trnsType { get; set; }
        public DateTime? cp_trns_Date { get; set; }
        public string? BankID { get; set; }
        public string? BANK_NAME { get; set; }
        public string? ACC_No { get; set; }
        public string? ROUTING_NO { get; set; }
        public string? BEF_NAME { get; set; }
    }
}