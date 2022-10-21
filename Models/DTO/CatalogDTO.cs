using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorRRHH_BackEnd_Api.Models.DTO
{
    /// <summary>
    /// Response for a catalog
    /// </summary>
    public class CatalogDTO: BaseRetorno
    {
        /// <summary>
        /// the catalog series
        /// </summary>
        public List<CatalogValue> items { get; set; }
    }
    /// <summary>
    /// Each value of the catalog
    /// </summary>
    public class CatalogValue {
        /// <summary>
        /// value
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// description
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// if its enabled or not
        /// </summary>
        public bool enabled { get; set; }
    }
}
