using CQRS_MediatR.CQRS.Queries.Request;
using CQRS_MediatR.CQRS.Queries.Response;
using CQRS_MediatR.Model;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace CQRS_MediatR.CQRS.Handlers.QueryHandler
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly Context _context;
        public GetByIdProductQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == request.Id);
            return new GetByIdProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
