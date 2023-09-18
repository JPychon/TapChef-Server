﻿namespace TapChef_Backend.DTOs.Communication
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string? Content { get; set; }
        public DateTime SentDate { get; set; }
    }
}
