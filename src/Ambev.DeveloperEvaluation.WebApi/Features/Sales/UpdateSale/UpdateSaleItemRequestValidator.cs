﻿using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
    {
        public UpdateSaleItemRequestValidator()
        {
            RuleFor(item => item.Id).NotEmpty();
            RuleFor(item => item.ProductId).NotEmpty();
            RuleFor(item => item.ProductName).NotEmpty();
            RuleFor(item => item.Quantity).InclusiveBetween(1, 20);
            RuleFor(item => item.UnitPrice).GreaterThan(0);
        }
    }
}
