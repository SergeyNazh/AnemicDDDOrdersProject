using AutoMapper;
using Domain.Commands;
using Domain.Entities;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;
        public OrdersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] Models.Orders.CreateOrder.OrderModel orderModel)
        {
            CreateOrderCommand createOrderCommand = _mapper.Map<CreateOrderCommand>(orderModel);
            Result<Guid> createOrderResult = await _mediator.Send(createOrderCommand);
            if (!createOrderResult.IsSuccess)
            {
                return BadRequest(createOrderResult.ErrorMessage);
            }
            return Ok(createOrderResult.Value);
        }
        [HttpGet]
        public async Task<ActionResult> GetOrders([FromQuery] Models.Orders.GetOrders.GetOrdersModel getOrdersModel)
        {
            GetOrdersQuery getOrdersQuery = _mapper.Map<GetOrdersQuery>(getOrdersModel);
            Result<IReadOnlyCollection<Order>> createOrderResult = await _mediator.Send(getOrdersQuery);
            if (!createOrderResult.IsSuccess)
            {
                return BadRequest(createOrderResult.ErrorMessage);
            }
            IReadOnlyCollection<Models.Orders.GetOrders.OrderModel> orders = _mapper.Map<IReadOnlyCollection<Models.Orders.GetOrders.OrderModel>>(createOrderResult.Value);
            return Ok(orders);
        }
    }
}
