using TapChef_Backend.DTOs.Utility;

namespace TapChef_Backend.DTOs.Orders
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VendorId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionStatus Status { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; } = default!;

        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
        
        public int? ErrorId { get; set; }
        public Error? Error { get; set; }

        public List<Note>? Notes { get; set; } = new List<Note>();
        public List<Tag>? Tags { get; set; } = new List<Tag>();

    }

    public enum TransactionStatus
    {
        Pending,
        Processing,
        Completed,
        Failed
    }
}
