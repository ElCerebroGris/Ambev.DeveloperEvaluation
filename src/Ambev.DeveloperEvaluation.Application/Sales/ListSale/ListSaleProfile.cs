using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale
{
    /// <summary>
    /// Profile for mapping between Sale entity and GetSaleResponse
    /// </summary>
    public class ListSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for ListSale operation
        /// </summary>
        public ListSaleProfile()
        {
            CreateMap<ListSaleCommand, ListSaleFilter>();

            // Map Sale -> GetSaleResult, including Items
            CreateMap<Sale, GetSaleResult>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            // Map SaleItem -> GetSaleItemResult
            CreateMap<SaleItem, GetSaleItemResult>();
        }
    }
}
