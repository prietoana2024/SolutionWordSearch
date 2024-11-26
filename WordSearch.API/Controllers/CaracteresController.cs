using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordSearch.API.Utility;
using WordSearch.DLL.Servicios.Contrato;
using WordSearch.MODELS;

namespace WordSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaracteresController : ControllerBase
    {
        private readonly ICaracteresService _caracteresServicio;

        public CaracteresController(ICaracteresService caracteresServicio)
        {
            _caracteresServicio = caracteresServicio;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<Caractere>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _caracteresServicio.Lista();
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }

        [HttpPost]
        [Route("Guardar")]

        public async Task<IActionResult> Guardar([FromBody] Caractere estado)
        {
            var rsp = new Response<Caractere>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _caracteresServicio.Crear(estado);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }
        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Caractere servicio)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _caracteresServicio.Editar(servicio);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _caracteresServicio.Eliminar(id);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }

    }
}
