﻿namespace WebApp.Models.Interfaces;

public interface IUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string? PhoneNumber { get; set; }
	public string? ProfileImage { get; set; }
}
