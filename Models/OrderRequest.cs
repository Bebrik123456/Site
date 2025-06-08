namespace Site.Models;

public class OrderRequest
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public DateTime EventDate { get; set; }
    public int Guests { get; set; }
    public string Comments { get; set; }
}