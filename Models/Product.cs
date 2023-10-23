using System.ComponentModel.DataAnnotations;
namespace EmpMVC.Models;


public class Product {
    [Display(Name = "Product ID")]
    [Key]
    [Required(ErrorMessage = "ID is Compulsory")]
    public int ID{get; set;}

    [Required(ErrorMessage = "Name cannot be blank!")]
    public string Name {get; set;}

    [Range(100, 900, ErrorMessage = "Price should be between 100 & 900")]
    public int Price {get; set;}
    public int Stock {get; set;}
}
