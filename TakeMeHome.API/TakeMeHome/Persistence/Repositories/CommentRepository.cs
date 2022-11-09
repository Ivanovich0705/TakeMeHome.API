using Microsoft.EntityFrameworkCore;
using TakeMeHome.API.TakeMeHome.Domain.Models;
using TakeMeHome.API.TakeMeHome.Domain.Repositories;
using TakeMeHome.API.TakeMeHome.Persistence.Contexts;

namespace TakeMeHome.API.TakeMeHome.Persistence.Repositories;

public class CommentRepository : BaseRepository, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Comment>> ListAsync()
    {
        return await _context.Comments
            .Include(p => p.Order)
            .ThenInclude(p=>p.OrderStatus)
            .ToListAsync();
    }

    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
    }

    public async Task<Comment> FindByIdAsync(int id)
    {
        return await _context.Comments
            .Include(p => p.Order)
            .FirstOrDefaultAsync(p => p.Id == id);

    }

    public async Task<IEnumerable<Comment>> FindyByUserId(int userId)
    {
        return await _context.Comments
            .Where(p => p.Order.ClientId == userId)
            .Include(p => p.Order.UserId)
            .ToListAsync();
    }

    public void Update(Comment comment)
    {
        _context.Comments.Update(comment);
    }

    public void Remove(Comment comment)
    {
        _context.Comments.Remove(comment);
    }
}