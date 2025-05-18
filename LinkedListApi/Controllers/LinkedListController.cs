using LinkedListApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkedListApi.Controllers
{
    [ApiController]
    [Route("linked-list")]
    public class LinkedListController : ControllerBase
    {
        private readonly LinkedListService _service;

        public LinkedListController(LinkedListService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _service.GetAll();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Dictionary<string, string> body)
        {
            if (!body.TryGetValue("value", out var value))
                return BadRequest(new { message = "Falta el campo 'value'" });

            var id = _service.Add(value);
            return Ok(new { id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound(new { message = "Nodo no encontrado" });

            return Ok(new { message = "Nodo eliminado correctamente" });
        }
    }
}
