using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale
{
    public class ListSaleValidator : AbstractValidator<ListSaleCommand>
    {
        /// <summary>
        /// Initializes validation rules for ListSalesRequest
        /// </summary>
        public ListSaleValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0);
            RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate).When(x => x.StartDate.HasValue);
        }
    }
}
