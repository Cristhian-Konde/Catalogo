using Domain;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Catalogo.Services;

namespace Catalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : ControllerBase
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ILogger<CatalogoController> logger,ICatalogoService catalogoService)
        {
            _logger = logger;
            _catalogoService = catalogoService;
        }

        [HttpGet(Name = "GetCatalogoList")]
        public IActionResult GetList() => Ok(_catalogoService.GetList());

        [HttpPost]
        public IActionResult AddCatalogo(Domain.Models.Catalogo catalogo)
        {
           return Ok(_catalogoService.AddCatalogo(catalogo));
        }

        [HttpPut]
        public IActionResult UpdateCatalogo(Domain.Models.Catalogo catalogo)
        {
            return Ok(_catalogoService.UpdateCatalogo(catalogo));
        }

        [HttpDelete]
        public IActionResult DeleteCatalogo(int  IdCatalogo)
        {
            return Ok(_catalogoService.DeleteCatalogo(IdCatalogo));
        }

    }
}