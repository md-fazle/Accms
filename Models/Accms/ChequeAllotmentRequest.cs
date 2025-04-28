namespace ACCMS_AGH.Models.Accms
{
    public class ChequeAllotmentRequest
    {
        public required string LCode { get; set; }
        public string? Lname { get; set; }
        public required string ChqNo { get; set; }
        public string? Amount { get; set; }
        public string? Chqdate { get; set; }
        public string? ValidDate { get; set; }
        public string? PaymentType { get; set; }
        public string? Remarks { get; set; }
        public string? EntryBy { get; set; }
        public string? CompanyID { get; set; }
        public string? LocationID { get; set; }
        public string? MachineID { get; set; }
    }
}
