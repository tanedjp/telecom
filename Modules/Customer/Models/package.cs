using System.ComponentModel.DataAnnotations;

namespace telecom.Modules.Customer.Models;

public class package : default_model
{
    [Key]
    public Guid? package_uid { get; set; }
    public string? package_name { get; set; }
    public decimal? price { get; set; }
    public int? phone_limit { get; set; }
    public int? internet_limit { get; set; }
}