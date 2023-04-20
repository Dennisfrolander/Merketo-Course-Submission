using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Interfaces;

namespace WebApp.Models.ViewModels;

public class RegisterContactUsViewModel : IContactUser, IContactInformation
{
    [Required(ErrorMessage = "You need to provide a first name")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to provide a valid first name")]
    [Display(Name = "First Name*")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You need to provide a last name")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to provide a valid last name")]
    [Display(Name = "Last Name*")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "You need to provide an e-mail adress")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid e-mail format")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "E-mail*")]
    public string Email { get; set; } = null!;

    [RegularExpression(@"^07[02369]\d{7}$", ErrorMessage = "Invalid mobile phone number format")]
    [Display(Name = "Mobile (optional)")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "You need to provide a Description")]
    [Display(Name = "Description*")]
    public string Description { get; set; } = null!;


    public static implicit operator ContactUserEntity(RegisterContactUsViewModel model)
    {
        return new ContactUserEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };
    }

    public static implicit operator ContactInformationEntity(RegisterContactUsViewModel model)
    {
        return new ContactInformationEntity
        {
            Description = model.Description,
        };
    }
}
