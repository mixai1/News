using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Commands.CommentsCommands
{
    public class AddCommentHandler : IRequestHandler<AddComment, bool>
    {
        private readonly WebApiDbContext _dbContext;
        private readonly IMapper _mapper;
        public AddCommentHandler(WebApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddComment request, CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.AddAsync(_mapper.Map<Comments>(request));
                await _dbContext.SaveChangesAsync(cancellationToken);
                //Logger
                return true;
            }
            catch (System.Exception ex)
            {

                //Logger.ex.masegge
                return false;
            }
           
           
           

        }
    }

}
