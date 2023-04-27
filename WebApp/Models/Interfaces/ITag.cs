namespace WebApp.Models.Interfaces;

public interface ITag
{
	public bool IsNew { get; set; }
	public bool IsFeatured { get; set; }
	public bool IsPopular { get; set; }
}
