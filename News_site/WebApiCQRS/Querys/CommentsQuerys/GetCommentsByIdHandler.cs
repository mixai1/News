using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.CommentsQuerys
{
    public class GetCommentsByIdHandler : IRequestHandler<GetCommentsById, Comments>
    {
        private readonly WebApiDbContext _dbContext;
        public GetCommentsByIdHandler(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Comments> Handle(GetCommentsById request, CancellationToken cancellationToken)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == request.CommentId);
                    
        }
    }
}
