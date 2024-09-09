namespace HsptMS.Data.DTO
{
    public class SendEmailDto
    {
        public string? Html { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string Subject { get; internal set; }
    }
}
