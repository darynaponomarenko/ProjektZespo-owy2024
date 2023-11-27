namespace Repository.Models
{
    public class RegisteredAppointment
    {
        public int Id { get; set; }
        public Patient? Patient { get; set; }

        //manage term(AKA Termin)

        public string? Procedure {  get; set; }

        public string? Priority { get; set; }

        public string? Worklist { get; set; }

        public DateTime? Time { get; set; }

        public string? Duration { get; set; }

        public string? PayerType {  get; set; }

        public string? PayerName { get; set; }

        public string? Comments { get; set; }

        public DateTime? RefferalDate { get; set; }

        public string? OrderingEntity { get; set; }

        public string? DiagnosisFromRefferal { get; set; }

        public ICD10? ICD10 { get; set; }

        public string? ReasonForAdmission { get; set; }

        public string? NFZContractNumber { get; set; }

        public Doctor? MedicalWorker { get; set; }

       
    }
}
