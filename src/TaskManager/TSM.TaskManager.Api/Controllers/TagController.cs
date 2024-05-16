using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSM.TaskManager.Application.Services.Tags;
using TSM.TaskManager.Application.Services.Tags.Models.Requests;
using TSM.TaskManager.Application.Services.Tags.Models.Responses;

namespace TSM.TaskManager.Api.Controllers;

[ApiController]
[Route("tags")]
public sealed class TagController : ControllerBase
{
	private readonly ITagService _tagService;

	public TagController(ITagService tagService)
	{
		_tagService = tagService;
	}

	[HttpGet]
	public Task<IReadOnlyList<TagResponse>> GetAll(CancellationToken cancellationToken)
	{
		return _tagService.GetAll(cancellationToken);
	}

	[HttpPost]
	public Task<CreateTagResponse> Create([FromBody] CreateTagRequest request, CancellationToken cancellationToken)
	{
		return _tagService.Create(request, cancellationToken);
	}

	[HttpPut]
	public Task<UpdateTagResponse> Update(
		[FromBody] UpdateTagRequest request,
		CancellationToken cancellationToken)
	{
		return _tagService.Update(request, cancellationToken);
	}

	[HttpDelete]
	public Task Delete([FromBody] DeleteTagRequest request, CancellationToken cancellationToken)
	{
		return _tagService.Delete(request, cancellationToken);
	}
}