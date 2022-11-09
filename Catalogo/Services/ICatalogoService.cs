
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Services
{
    public interface ICatalogoService
    {
        public IEnumerable<Domain.Models.Catalogo> GetList();
        public IActionResult AddCatalogo(Domain.Models.Catalogo catalogo);
        public IActionResult UpdateCatalogo(Domain.Models.Catalogo catalogo);
        public IActionResult DeleteCatalogo(int IdCatalogo);
    }
}
