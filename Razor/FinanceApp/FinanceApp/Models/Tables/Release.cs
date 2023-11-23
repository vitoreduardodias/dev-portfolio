using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models.Tables;

public class Release
{
    [Key]
    [DisplayName("Id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please provide a date")]
    [DisplayName("Date")]
    [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Please provide a Description")]
    [StringLength(50, ErrorMessage = "The Description should contain up to 50 characters")]
    [MinLength(3, ErrorMessage = "The Description should contain at least 3 characters")]
    [DisplayName("Description")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please provide a quantity")]
    [Range(1, int.MaxValue, ErrorMessage = "The value should be greater than zero.")]
    [DisplayName("Quantity")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Please provide a value")]
    [Range(1.0, double.MaxValue, ErrorMessage = "The value should be greater than zero.")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
    public double UnityValue { get; set; }
    
    [DisplayName("Total Value")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
    public double TotalValue { get; set; }
    
    [Required(ErrorMessage = "Please specify if it's a Creditor or Debtor")]
    [DisplayName("Direction")]
    public Direction Direction { get; set; }
    
    [DisplayName("Account")]
    public int AccId { get; set; }
    public Account? Acc { get; set; }
}