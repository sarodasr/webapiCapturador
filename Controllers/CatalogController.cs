using GestorRRHH_BackEnd_Api.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace GestorRRHH_BackEnd_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(Duration = 600, Location = ResponseCacheLocation.Any, NoStore = false)]
    public class CatalogController : ControllerBase
    {
        GestorRRHHContext _context;
        public CatalogController()
        {
            _context = new GestorRRHHContext();
        }

        [HttpGet]
        public CatalogDTO getCatalog(string CatalogCode, bool All) {
            CatalogDTO res = new CatalogDTO() { Codigo = 500, Mensaje="No es posible obtener los datos del catálogo" };
            try
            {
                var Catalogo = _context.Catalog.Include(d => d.CatalogDetail).Where(x => x.catalogCode == CatalogCode).FirstOrDefault();
                if (Catalogo != null) {
                    res.Codigo = 0;
                    res.Mensaje = "Catalogo encontrado";

                    var items = (from x in Catalogo.CatalogDetail
                                 select new CatalogValue { 
                                     value = x.valueDetail,
                                     description = x.valueDescription,
                                     enabled = x.enabled
                                 }).OrderBy(x => x.description).ToList();

                    if (All)
                    {
                        res.items = items;
                    }
                    else {
                        res.items = items.Where(x => x.enabled == true).ToList();
                    }
                }
                else
                {
                    res.Codigo = 404;
                    res.Mensaje = "El catálogo enviado no existe";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return res;
        }
    }
}
