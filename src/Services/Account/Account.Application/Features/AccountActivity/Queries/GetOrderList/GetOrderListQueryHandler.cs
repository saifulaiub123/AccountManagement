using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Account.Application.Contracts.Persistence.IRepository;

namespace Account.Application.Features.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderVm>>
    {
        private readonly IAccountActivityRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrderListQueryHandler(IAccountActivityRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderVm>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            //var orderList = await _orderRepository.GetOrderByUsername(request.Username);
            return null;
        }
    }
}
