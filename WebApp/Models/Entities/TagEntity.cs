namespace WebApp.Models.Entities;

public class TagEntity
{
	public int Id { get; set; }
	public string TagName { get; set; } = null!;
	public ICollection<ProductTagEntity> Products { get; set; } = new HashSet<ProductTagEntity>();
}
