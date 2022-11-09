using Catalogo.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Services
{
    public class CatalogoService: ICatalogoService
    {
        private readonly DataContext _DataContext;
        public CatalogoService(DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        public IEnumerable<Domain.Models.Catalogo> GetList()
        {
            var list = _DataContext.Catalogo.ToArray();
            if (list.Length >= 1)
            {
                return list;
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult AddCatalogo(Domain.Models.Catalogo catalogo)
        {
            Domain.Response.Respuesta oRespuesta = new Domain.Response.Respuesta();
            
            try
            {
                if (string.IsNullOrEmpty(catalogo.Nombre))
                {
                    _DataContext.Catalogo.Add(catalogo);
                    _DataContext.SaveChanges();

                    oRespuesta.Exito = 1;

                    oRespuesta.Mensaje = "Insertado correctamente";
                }
                else
                {
                    oRespuesta.Exito = 0;

                    oRespuesta.Mensaje = "El nombre del Catalogo es obligatorio";
                }


            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }

            OkObjectResult okObject = new OkObjectResult(oRespuesta);

            return okObject;


        }

        public IActionResult UpdateCatalogo(Domain.Models.Catalogo catalogo)
        {
            Domain.Response.Respuesta oRespuesta = new Domain.Response.Respuesta();

            try
            {
                if (catalogo.Id != 0)
                {
                    _DataContext.Catalogo.Update(catalogo);
                    _DataContext.SaveChanges();

                    oRespuesta.Exito = 1;

                    oRespuesta.Mensaje = "Modificado correctamente";
                }
                else
                {
                    oRespuesta.Exito = 0;

                    oRespuesta.Mensaje = "El id del catalogo es obligatorio";

                }


            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }

            OkObjectResult okObject = new OkObjectResult(oRespuesta);

            return okObject;


        }

        public IActionResult DeleteCatalogo(int IdCatalogo)
        {
            Domain.Response.Respuesta oRespuesta = new Domain.Response.Respuesta();

            try
            {
                if (IdCatalogo != 0)
                {
                    var Catalogo = _DataContext.Catalogo.FirstOrDefault(x => x.Id.Equals(IdCatalogo));
                    if (Catalogo != null)
                    {
                        _DataContext.Catalogo.Remove(Catalogo);
                        _DataContext.SaveChanges();

                        oRespuesta.Exito = 1;

                        oRespuesta.Mensaje = "Elimininado correctamente";
                    }
                    else
                    {
                        oRespuesta.Exito = 0;

                        oRespuesta.Mensaje = "No se encontro ningun registro con ese id";
                    }


                }
                else
                {
                    oRespuesta.Exito = 0;

                    oRespuesta.Mensaje = "El id del catalogo es obligatorio";
                }


            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }

            OkObjectResult okObject = new OkObjectResult(oRespuesta);

            return okObject;


        }

        private IEnumerable<Domain.Models.Catalogo> NotFound()
        {
            throw new NotImplementedException("No hay datos que mostrar");
        }
    }
}
