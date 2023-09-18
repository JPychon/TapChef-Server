namespace TapChef_Backend.DTOs.Orders
{
    public class Error
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; }
        public ErrorType ErrorType { get; set; }
        public ErrorSeverity Severity { get; set; }
        public string? StackTrace { get; set; }
    }

    public enum ErrorType
    {
        TransactionError,
        PaymentError,
        SystemError,
    }
    public enum ErrorSeverity
    {
        Low,
        Medium,
        High,
        Critical
    }
}
