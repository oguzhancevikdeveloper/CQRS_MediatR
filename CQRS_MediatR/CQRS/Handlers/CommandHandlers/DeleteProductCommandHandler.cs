using CQRS_MediatR.CQRS.Commands.Request;
using CQRS_MediatR.CQRS.Commands.Response;
using CQRS_MediatR.Model;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly Context _context;
        public DeleteProductCommandHandler(Context context)
        {
            _context= context;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteProduct = _context.Products.FirstOrDefault(p => p.Id == request.Id);
            _context.Products.Remove(deleteProduct);
            _context.SaveChanges();
            return new DeleteProductCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
