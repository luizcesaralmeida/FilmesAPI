using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{
    private static List<FilmeDTO>  filmes = new List<FilmeDTO>();    

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] FilmeDTO filme)
    {
        filme.Id = filmes.Count + 1;
        filmes.Add(filme);
        return CreatedAtAction(nameof(ObterFilmePorId), new { id = filme.Id }, filme);
    }
    [HttpGet]
    public IEnumerable<FilmeDTO> ObterFilmes([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return filmes.Skip(skip).Take(take);

    }

    [HttpGet("{id}")]
    public IActionResult ObterFilmePorId(int id)
    {        
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        return filme is null ? NotFound() : Ok(filme);
    }
}
