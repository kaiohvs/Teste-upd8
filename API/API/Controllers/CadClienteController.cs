using API.Business.Interfaces;
using API.Infra.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CadClienteController : ControllerBase
    {
        public readonly ICadClienteService _service;
        public CadClienteController(ICadClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _service.Get();
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var GetId = await _service.Get(id);
                return Ok(GetId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [Route("api/{nome}")]
        [HttpGet]
        public async Task<IActionResult> GetName(string nome)
        {
            try
            {
                var getNome = await _service.Get(nome);
                return Ok(getNome);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CadCliente cadCliente)
        {
            try
            {
                var create = await _service.Create(cadCliente);

                return Ok(create);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CadCliente cadCliente)
        {
            try
            {             

                await _service.Update(cadCliente);

                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
