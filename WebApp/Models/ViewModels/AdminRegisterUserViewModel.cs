using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Interfaces;

namespace WebApp.Models.ViewModels;

public class AdminRegisterUserViewModel : IRegisterUserProfile
{
    [Required(ErrorMessage = "You need to provide a first name")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to provide a valid first name")]
    [Display(Name = "First Name*")]
    public string FirstName { get; set; } = null!;


    [Required(ErrorMessage = "You need to provide a last name")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to provide a valid last name")]
    [Display(Name = "Last Name*")]
    public string LastName { get; set; } = null!;


    [Required(ErrorMessage = "You need to provide a street name")]
    [Display(Name = "Street Name*")]
    public string StreetName { get; set; } = null!;

    [RegularExpression(@"^(?:SE-)?\d{3}\s?\d{2}$", ErrorMessage = "Postal code is invalid, (12345 / 123 45)")]
    [Required(ErrorMessage = "You need to provide a postal code")]
    [Display(Name = "Postal Code*")]
    public string PostalCode { get; set; } = null!;

    [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]{3,}$", ErrorMessage = "Postal code is invalid, (12345 / 123 45)")]
    [Required(ErrorMessage = "You need to provide a City")]
    [Display(Name = "City*")]
    public string City { get; set; } = null!;


    [RegularExpression(@"^07[02369]\d{7}$", ErrorMessage = "City is invalid")]
    [Display(Name = "Mobile (optional)")]
    public string? PhoneNumber { get; set; }


    [Display(Name = "Company (optional)")]
    public string? CompanyName { get; set; }


    [Required(ErrorMessage = "You need to provide an e-mail adress")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid e-mail format")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "E-mail*")]
    public string Email { get; set; } = null!;


    [Required(ErrorMessage = "You need to provide a password")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "You must provide a valid password, at least 8 characters long and containing at least 1 letter, 1 number, and 1 special character.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password*")]
    public string Password { get; set; } = null!;


    [Required(ErrorMessage = "You need to confirm password")]
    [Compare(nameof(Password), ErrorMessage = "Password doesn't match")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password*")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "Upload Profile Image (optional)")]
    public string? ProfileImage { get; set; }

    [Display(Name = "Role")]
    [Required(ErrorMessage = "You need to provide a role")]
    public string RoleName { get; set; } = null!;

    public static implicit operator IdentityUser(AdminRegisterUserViewModel model)
    {
        return new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };
    }

    public static implicit operator UserProfileEntity(AdminRegisterUserViewModel model)
    {
        return new UserProfileEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            ProfileImage = model.ProfileImage,
            CompanyName = model.CompanyName,
        };
    }

    public static implicit operator AdressEntity(AdminRegisterUserViewModel model)
    {
        return new AdressEntity
        {
            StreetName = model.StreetName!,
            PostalCode = model.PostalCode!,
            City = model.City!,
        };
    }
}