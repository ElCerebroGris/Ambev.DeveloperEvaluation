﻿using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sale.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sale
{
    /// <summary>
    /// Contains unit tests for the <see cref="GetSaleHandler"/> class.
    /// </summary>
    public class GetSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly GetSaleHandler _handler;

        public GetSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetSaleHandler(_saleRepository, _mapper);
        }

        [Fact(DisplayName = "Given existing sale ID When getting sale Then returns sale data")]
        public async Task Handle_ExistingSaleId_ReturnsSaleData()
        {
            var sale = await SaleHandlerTestData.GenerateAndSaveSaleAsync(_saleRepository, CancellationToken.None);
            var command = new GetSaleCommand(sale.Id);
            var result = _mapper.Map<GetSaleResult>(sale);

            _saleRepository.GetByIdAsync(sale.Id, Arg.Any<CancellationToken>()).Returns(sale);
            _mapper.Map<GetSaleResult>(sale).Returns(result);

            var getSaleResult = await _handler.Handle(command, CancellationToken.None);

            getSaleResult.Should().NotBeNull();
            getSaleResult.Id.Should().Be(sale.Id);
            await _saleRepository.Received(1).GetByIdAsync(sale.Id, Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Given non-existing sale ID When getting sale Then throws KeyNotFoundException")]
        public async Task Handle_NonExistingSaleId_ThrowsException()
        {
            var command = new GetSaleCommand(Guid.NewGuid());
            _saleRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>()).Returns((Ambev.DeveloperEvaluation.Domain.Entities.Sale)null);

            var act = () => _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}
