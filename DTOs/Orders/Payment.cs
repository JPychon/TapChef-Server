namespace TapChef_Backend.DTOs.Orders
{
    public class Payment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Currency { get; set; } = "USD";
        public string? Token { get; set; }
        public string Method { get; set; } = default!;
        public PaymentStatus Status { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; } = default!;
        public int? ErrorId { get; set; }
        public Error? Error { get; set; }

    }
    public enum PaymentStatus
    {
        Pending,
        Processing,
        Completed,
        Failed
    }
}
