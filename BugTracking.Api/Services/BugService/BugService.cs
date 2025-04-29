using Azure.Core;
using BugTracking.Api.Common.Exceptions;
using BugTracking.Api.Data;
using BugTracking.Api.DTOs.BugReport;
using BugTracking.Api.Services.CurrentUserService;
using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BugTracking.Api.Services.BugService
{
    public class BugService : IBugService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public BugService(ApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<Result<string>> CreateAsync(CreateBug request)
        {
            var entity = request.MapToBug();
            entity.ReporterId = _currentUserService.UserId;

            if (request.File != null && request.File.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Bugs");
                Directory.CreateDirectory(uploadsFolder); 

                var fileName = $"{Guid.NewGuid()}_{request.File.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                }

                entity.FilePath = Path.Combine("Uploads", "Bugs", fileName).Replace("\\", "/");
            }

            await _context.Bugs.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Result.Ok("Bug Report Created Successfully");
        }

        public async Task<Result> Delete(int id)
        {
            var bug = await _context.Bugs.FirstOrDefaultAsync(b => b.Id == id);

            if (bug == null)
                return Result.Fail("Bug not found");

            _context.Bugs.Remove(bug);
            await _context.SaveChangesAsync();
            return Result.Ok().WithSuccess("Bug Report deleted successfully");
        }

        public async Task<Result<List<BugDto>>> GetAllBug()
        {
            var bugs = await _context.Bugs
                            .Include(b => b.Reporter)
                            .Include(b => b.Developer)
                            .ToListAsync();

            if (bugs == null || bugs.Count == 0)
                throw new BadRequestException("No bugs found");

            var bugDtos = bugs.Select(b => new BugDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                SeverityLevel = b.SeverityLevel,
                ReproductionSteps = b.ReproductionSteps,
                FilePath = b.FilePath,
                CreatedDate = b.CreatedDate,
                ReporterId = b.ReporterId,
                Reporter = b.Reporter?.Fullname,
                DeveloperId = b.DeveloperId,
                Developer = b.Developer?.Fullname
            }).ToList();

            return Result.Ok(bugDtos);
        }

        public async Task<Result<List<BugDto>>> GetBugByUser()
        {
            var loggedinUserId = _currentUserService.UserId;
            var bugs = await _context.Bugs
                            .Where(b => b.ReporterId == loggedinUserId)
                            .Include(b => b.Reporter)
                            .Include(b => b.Developer)
                            .ToListAsync();

            if (bugs == null || bugs.Count == 0)
                throw new BadRequestException("No bugs found");

            var bugDtos = bugs.Select(b => new BugDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                SeverityLevel = b.SeverityLevel,
                ReproductionSteps = b.ReproductionSteps,
                FilePath = b.FilePath,
                CreatedDate = b.CreatedDate,
                ReporterId = b.ReporterId,
                Reporter = b.Reporter?.Fullname,
                DeveloperId = b.DeveloperId,
                Developer = b.Developer?.Fullname
            }).ToList();

            return Result.Ok(bugDtos);
        }
    }
}
