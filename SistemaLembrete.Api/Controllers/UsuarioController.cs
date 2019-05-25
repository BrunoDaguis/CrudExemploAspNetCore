using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaLembrete.Api.ViewModel.Usuario;
using SistemaLembrete.Application.Interfaces;
using SistemaLembrete.Domain.Entities;
using SistemaLembrete.Domain.Interfaces;

namespace SistemaLembrete.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        /// <summary>
        /// Obtem todos os usuários ativos
        /// </summary>
        /// <returns>Retorna uma lista com todos os usuários ativos</returns>
        /// <response code="200">Lista de usuários</response>
        /// <response code="400">Bad Request</response>   
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioApplication.Get();

            var viewModel = UsuarioGetViewModel.Parse(usuarios);

            return Ok(viewModel);
        }

        /// <summary>
        /// Obtem um usuário especifico.
        /// </summary>
        /// <param name="id">Código de identificação do usuário</param>
        /// <returns>Dados de um usuário especifico</returns>
        /// <response code="200">Objeto com os dados de um usuário</response>
        /// <response code="404">Usuário não encontrado</response>          
        /// <response code="400">Bad Request</response>            
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioGetViewModel>> Get(int id)
        {
            var usuario = await _usuarioApplication.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            UsuarioGetViewModel viewModel = UsuarioGetViewModel.Parse(usuario);

            return viewModel;
        }

        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Todo
        ///     {
        ///        "nome": "Joaquim Neto",
        ///        "cpf": "9999999999",
        ///        "email": "a@b.c"
        ///     }
        ///
        /// </remarks>
        /// <param name="viewModel"></param>
        /// <returns>Um novo usuário cadastrado</returns>
        /// <response code="201">Retorna um objeto com os dados do novo usuário cadastrado</response>
        /// <response code="400">Bad Request</response>            
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<ActionResult<UsuarioGetViewModel>> Create([FromBody]UsuarioCreateViewModel viewModel)
        {
            UsuarioEntity usuario = viewModel;

            await _usuarioApplication.Add(usuario);

            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// Alterar dados de um usuário existente
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "nome": "Joaquim Neto",
        ///        "email": "a@b.c"
        ///     }
        /// </remarks>
        /// <param name="id">Código de identificação do usuário que irá ser alterado</param>
        /// <param name="viewModel">Objeto com os dados de alteração do usuário</param>
        /// <response code="204">Nenhum conteúdo é retornado</response>
        /// <response code="400">Bad Request</response>     
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            UsuarioEntity usuario = viewModel;

            await _usuarioApplication.Update(usuario);

            return NoContent();
        }

        /// <summary>
        /// Exclui um usuário especifico.
        /// </summary>
        /// <param name="id">Código de identificação do usuário</param>
        /// <response code="204">Operação realizada com sucesso</response>
        /// <response code="404">Usuário não encontrado</response>          
        /// <response code="400">Bad Request</response>            
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioApplication.Get(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await _usuarioApplication.Delete(usuario);

            return NoContent();
        }

    }
}