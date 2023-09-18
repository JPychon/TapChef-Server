namespace TapChef_Backend.Utility
{
    // Provide a unified response-object for all API calls & database queries.
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
