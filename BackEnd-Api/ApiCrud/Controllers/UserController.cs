using ApiCrud.InfraData;
using ApiCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserInfraData _userInfra;
        public UserController(IUserInfraData userInfra)
        {
            _userInfra = userInfra;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUsuarios()
        {
            var users = await _userInfra.GetUsers();
            return users.Any() ? Ok(users) : BadRequest("Usuario nao encontrado");
        }
/*
        [HttpGet("Usuario/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userInfra.GetUserById(id);
            return user != null ? Ok(user) : BadRequest("Usuario nao encontrado");
        }
*/
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {

            _userInfra.Add(user);
            return await _userInfra.SaveChangesAsync()
            ? Ok("Usuario adicionado")
            : BadRequest("O usuario não pode ser adicionado");
        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {

            var selectedUser = await _userInfra.GetUserById(id);
            if (selectedUser.Equals(null)) return BadRequest("Usuario não encontrado");

            _userInfra.Delete(selectedUser);
            return await _userInfra.SaveChangesAsync()
            ? Ok("Usuario removido")
            : BadRequest("O usuario não pode ser removido");
        }

        [HttpPut("Update{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] User user)
        {
            if (id == user.Id)
            {
                _userInfra.Update(user);
                return await _userInfra.SaveChangesAsync() ?
                Ok("Usuario Atualizado com sucesso") : BadRequest("Dados inconsistente");
            }
            else
                return BadRequest("Resquisição invalida");

        }
    }
}
