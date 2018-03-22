﻿using Microsoft.AspNetCore.Mvc;
using Querying.Infra.Dto;
using Querying.Infra.Repositories;
using System.Threading.Tasks;
using Tnf.Dto;

namespace Querying.Web
{
    [Route("api/order")]
    public class OrderController : TnfController
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, [FromQuery]RequestDto requestDto)
        {
            if (id <= 0) return BadRequest();

            requestDto.WithId(id);

            var response = await orderRepository.GetOrder(requestDto);

            return CreateResponseOnGetAll(response);
        }

        [HttpGet("{orderId}/customer")]
        public async Task<IActionResult> GetCustomerFromOrder(int orderId, [FromQuery]RequestDto requestDto)
        {
            if (orderId <= 0) return BadRequest();

            requestDto.WithId(orderId);

            var response = await orderRepository.GetCustomerFromOrder(requestDto);

            return CreateResponseOnGet(response);
        }

        [HttpPost("sumarized")]
        public async Task<IActionResult> GetSumarizedOrderFromProduct([FromBody]SumarizedOrderRequestAllDto param)
        {
            if (param == null) return BadRequest();

            var response = await orderRepository.GetSumarizedOrderFromProduct(param);

            return CreateResponseOnGet(response);
        }
    }
}