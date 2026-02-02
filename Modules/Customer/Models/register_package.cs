using System.ComponentModel.DataAnnotations;

namespace telecom.Modules.Customer.Models;

public class register_package : default_model
{
    [Key]
    public Guid? register_package_uid { get; set; }
    public Guid? customer_uid { get; set; }
    public Guid? package_uid { get; set; }
    public DateTime? register_date { get; set; }
    public DateTime? expired_date { get; set; }
}