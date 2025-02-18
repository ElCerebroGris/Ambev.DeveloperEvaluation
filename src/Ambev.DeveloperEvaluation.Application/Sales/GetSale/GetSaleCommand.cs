﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleCommand
    {
        /// <summary>
        /// The unique identifier of the sale to retrieve
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of GetSaleCommand
        /// </summary>
        /// <param name="id">The ID of the sale to retrieve</param>
        public GetSaleCommand(Guid id)
        {
            Id = id;
        }
    }
}
