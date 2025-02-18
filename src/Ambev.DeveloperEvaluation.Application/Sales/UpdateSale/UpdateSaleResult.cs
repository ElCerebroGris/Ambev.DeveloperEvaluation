using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Represents the response returned after successfully updating a new sale.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly updated sale,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class UpdateSaleResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the updated sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created sale in the system.</value>
        public Guid Id { get; set; }
    }
}
