using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TSM.Task.Application.Services.Tags.Models.Requests;
using TSM.Task.Application.Services.Tags.Models.Responses;

namespace TSM.Task.Application.Services.Tags;

public interface ITagService
{
    public Task<List<TagResponse>> GetAll(CancellationToken cancellationToken = default);
    public Task<CreateTagResponse> Create(CreateTagRequest request, CancellationToken cancellationToken = default);
    public Task<UpdateTagResponse> Update(UpdateTagRequest request, CancellationToken cancellationToken = default);
    public System.Threading.Tasks.Task Delete(DeleteTagRequest request, CancellationToken cancellationToken = default);
}