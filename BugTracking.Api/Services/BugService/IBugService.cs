using BugTracking.Api.DTOs.BugReport;
using FluentResults;

namespace BugTracking.Api.Services.BugService
{
    public interface IBugService
    {
        Task<Result<List<BugDto>>> GetBugByUser();
        Task<Result<List<BugDto>>> GetAllBug();
        Task<Result<string>> CreateAsync(CreateBug bug);
        Task<Result> Delete(int id);
        Task<Result<string>> UpdateAsync(UpdateBugDto updateDto);
    }
}
