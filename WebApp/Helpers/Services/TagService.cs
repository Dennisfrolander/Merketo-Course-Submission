using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Services;

public class TagService
{
	private readonly TagRepository _tagRepo;
	private readonly ProductTagRepository _productTagRepo;
	private readonly ProductRepository _productRepository;

	public TagService(TagRepository tagRepo, ProductTagRepository productTagRepo, ProductRepository productRepository)
	{
		_tagRepo = tagRepo;
		_productTagRepo = productTagRepo;
		_productRepository = productRepository;
	}

	public async Task<List<SelectListItem>> GetTagsAsync()
	{
		try
		{
			var tags = new List<SelectListItem>();

			foreach (var tag in await _tagRepo.GetAllAsync())
			{
				tags.Add(new SelectListItem
				{
					Value = tag.Id.ToString(),
					Text = tag.TagName,
				});
			}
			return tags;
		}
		catch { return null!; }
	}

	public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedTags)
	{
		try
		{
			var tags = new List<SelectListItem>();

			foreach (var tag in await _tagRepo.GetAllAsync())
			{
				tags.Add(new SelectListItem
				{
					Value = tag.Id.ToString(),
					Text = tag.TagName,
					Selected = selectedTags.Contains(tag.Id.ToString())
				});
			}
			return tags;
		}
		catch { return null!; }
	}

	public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
	{
		var product = await _productRepository.GetAsync(x => x.Name == entity.Name);

		foreach (var tag in tags)
		{
			await _productTagRepo.CreateAsync(new ProductTagEntity
			{
				ProductId = product.Id,
				TagId = int.Parse(tag)
			});
		}
	}
}
