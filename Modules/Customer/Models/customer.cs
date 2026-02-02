using System.ComponentModel.DataAnnotations;

namespace telecom.Modules.Customer.Models;

public class customer : default_model
{
    [Key]
    public Guid? customer_uid { get; set; }
    public string? customer_first_name { get; set; }
    public string? customer_last_name { get; set; }
    public string? phone_number { get; set; }
    public string? email { get; set; }
    public string? main_addr_no { get; set; }
    public string? main_addr_building { get; set; }
    public string? main_addr_soi { get; set; }
    public string? main_addr_moo { get; set; }
    public string? main_addr_province { get; set; }
    public string? main_addr_district { get; set; }
    public string? main_addr_sub_district { get; set; }
    public string? main_addr_postcode { get; set; }
    public bool? is_main_doc { get; set; }
    public string? doc_addr_no { get; set; }
    public string? doc_addr_building { get; set; }
    public string? doc_addr_soi { get; set; }
    public string? doc_addr_moo { get; set; }
    public string? doc_addr_province { get; set; }
    public string? doc_addr_district { get; set; }
    public string? doc_addr_sub_district { get; set; }
    public string? doc_addr_postcode { get; set; }
    public Guid? register_package_uid { get; set; }
    
}