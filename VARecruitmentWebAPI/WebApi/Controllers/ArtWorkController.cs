using MediatR;
using Microsoft.AspNetCore.Mvc;
using VAArtGalleryWebAPI.Application.Queries;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.WebApi.Models;

namespace VAArtGalleryWebAPI.WebApi.Controllers
{
    [Route("api/art-works")]
    [ApiController]
    public class ArtWorkController(IMediator mediator) : ControllerBase
    {

        [HttpGet("{galleryId}")]
        public async Task<IActionResult> GetArtWorksByGallery(Guid galleryId)
        {
            var result = await mediator.Send(new GetArtGalleryArtWorksQuery(galleryId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateArtWorkRequest request)
        {
            try {
                var newWork = new ArtWork(request.Name, request.Author, request.CreationYear, request.AskPrice);
                var result = await mediator.Send( new CreateArtWorkQuery(request.GalleryId, newWork));
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro tentando Criar um novo registro");
            }
        }

        [HttpDelete("{workId}")]
        public async Task<IActionResult> Delete(Guid workId)
        {
            try
            {
                var result = await mediator.Send(new DeleteArtWorkQuery(workId));
                    return StatusCode(StatusCodes.Status204NoContent, "Sem conteudo para apagar.");
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro apagando o registro.");
            }
        }
    }
    
}