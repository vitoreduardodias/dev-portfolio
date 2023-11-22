using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace FinanceSolution.Models.Tables;

public class Account
{
    [Key]
    [DisplayName("Id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please provide a name")]
    [MinLength(3, ErrorMessage = "The name should contain at least 3 characters")]
    [StringLength(50, ErrorMessage = "The name should contain up to 50 characters")]
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;



    public List<Release> Releases { get; set; } = new();

        
}