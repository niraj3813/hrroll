namespace HRRoll.Models
{
    public class PayrollRecord
    {
        public int PayrollRecordId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateProcessed { get; set; }
        public decimal GrossPay { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetPay { get; set; }
    }
}
