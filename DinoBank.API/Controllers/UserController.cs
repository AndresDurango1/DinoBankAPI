using DinoBank.Domain.User;
using DinoBank.Persistence.Database;
using Microsoft.AspNetCore.Mvc;

namespace DinoBank.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        public UserController(IDatabaseService databaseService)
        {
            _databaseService = databaseService; //Se hace la inyeccion de dependencias en el método contructor
        }
        //GET - Obtener los usuarios del JSON
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            //Get All
            var data = _databaseService.GetAll();
            if (data != null && data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay datos");
            }
            return StatusCode(StatusCodes.Status200OK, data);
        }
        //GET BY ID - Obtener un usurio por ID del JSON
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int Id)
        {
            //Get By Id
            var data = _databaseService.GetAll();
            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay datos");
            }
            var user = data.FirstOrDefault(x => x.Id == Id);
            return StatusCode(StatusCodes.Status200OK, user);
        }
        //POST - Crear un nuevo usuario en el JSON
        [HttpPost("create")]
        public IActionResult Create([FromBody] UserEntity user)
        {
            //Create
            if (string.IsNullOrEmpty(user.UserName) ||
                string.IsNullOrEmpty(user.Password) ||
                string.IsNullOrEmpty(user.Type))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Faltan datos de usuario");
            }
            var data = _databaseService.Create(user);
            if (!data)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el usuario");
            }
            return StatusCode(StatusCodes.Status200OK, data);
        }
        //PUT - Actualizar un usuario en el JSON
        [HttpPut("update")]
        public IActionResult Update([FromBody] UserEntity user)
        {
            //Update
            if (user.Id == 0 ||
                string.IsNullOrEmpty(user.UserName) ||
                string.IsNullOrEmpty(user.Password) ||
                string.IsNullOrEmpty(user.Type))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Faltan datos de usuario");
            }
            var data = _databaseService.Update(user);
            if (!data)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el usuario");
            }
            return StatusCode(StatusCodes.Status200OK, data);
        }
        //DELETE - Eliminar un usuario en el JSON
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            //Delete
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Id no válido");
            }
            var data = _databaseService.Delete(id);
            if (!data)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el usuario");
            }
            return StatusCode(StatusCodes.Status200OK, data);
        }
    }
}
