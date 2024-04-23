using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSM.Task.Application.Services.Tags;
using TSM.Task.Application.Services.Tags.Models.Requests;
using TSM.Task.Application.Services.Tags.Models.Responses;

namespace TSM.Task.Api.Controllers;

[ApiController]
[Route("tags")]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public async Task<List<TagResponse>> GetAll(CancellationToken cancellationToken)
    {
        return await _tagService.GetAll(cancellationToken);
    }

    [HttpPost]
    public async Task<CreateTagResponse> Create([FromBody] CreateTagRequest request, CancellationToken cancellationToken)
    {
        return await _tagService.Create(request, cancellationToken);
    }

    [HttpPut("{id:guid}")]
    public async Task<UpdateTagResponse> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateTagRequest request,
        CancellationToken cancellationToken)
    {
        request.Id = id;

        return await _tagService.Update(request, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async System.Threading.Tasks.Task Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteTagRequest
        {
            Id = id
        };

        await _tagService.Delete(request, cancellationToken);
    }
}