namespace Repository.Models
{
    public class RegisteredAppointment
    {
        public int Id { get; set; }
        public int PatientId {  get; set; }
        public Patient? Patient { get; set; }
        public string Pesel { get; set; }
        public string? Procedure {  get; set; }

        public string? Priority { get; set; }

        public string? Worklist { get; set; }

        public DateTime? Date {  get; set; }
        public string? Time { get; set; }

        public string? Payers {  get; set; }

        public string? PayerName { get; set; }

        public string? PayerExtraNote { get; set; }

        public DateTime? DateOfIssue { get; set; }

        public string? ContractingAuthorities { get; set; }

        public string? ReasonForAdmission { get; set; }

        public string? CodeICD { get; set; }

        public string? NFZContractNr { get; set; }
       
    }
}
