using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserCadastro.Data;
using UserCadastro.Models;
using System.Threading.Tasks;

namespace UserCadastro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroContext _context;

        public CadastroController(CadastroContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCadastro([FromBody] Cadastro cadastro)
        {
            if (cadastro == null)
            {
                return BadRequest("Cadastro inválido.");
            }

            _context.Cadastro.Add(cadastro);
            await _context.SaveChangesAsync();

            return Ok(cadastro);
        }

        [HttpGet]
        public async Task<IActionResult> GetCadastros()
        {
            var cadastros = await _context.Cadastro.ToListAsync();
            return Ok(cadastros);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadastro(int id)
        {
            var cadastro = await _context.Cadastro.FindAsync(id);

            if (cadastro == null)
            {
                return NotFound($"Cadastro com ID {id} não encontrado.");
            }

            _context.Cadastro.Remove(cadastro);
            await _context.SaveChangesAsync();

            return Ok($"Cadastro com ID {id} foi deletado.");
        }
    }
}
