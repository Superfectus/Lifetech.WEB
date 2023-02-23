namespace Lifetech.WEB.Models;

public class Email
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirmName { get; set; }
    public string? Subject { get; set; }
    public string? Message { get; set; }
}