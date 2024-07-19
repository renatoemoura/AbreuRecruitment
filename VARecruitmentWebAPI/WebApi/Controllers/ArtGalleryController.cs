using System.Reflection.Metadata.Ecma335;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VAArtGalleryWebAPI.Application.Queries;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.WebApi.Models;

namespace VAArtGalleryWebAPI.WebApi.Controllers
{
    [Route("api/art-galleries")]
    [ApiController]
    public class ArtGalleryController(IMediator mediator) : ControllerBase
    {        
        [HttpGet]
        public async Task<ActionResult<List<GetAllArtGalleriesResult>>> GetAllGalleries()
        {
            var galleries = await mediator.Send(new GetAllArtGalleriesQuery());

            var result = galleries.Select(g => new GetAllArtGalleriesResult(g.Id, g.Name, g.City, g.Manager, g.ArtWorksOnDisplay?.Count ?? 0)).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreateArtGalleryResult>> Create([FromBody] CreateArtGalleryRequest request)
        {
            try
            {
                var newGallery = new ArtGallery(request.Name, request.City, request.Manager);
                var gallery = await mediator.Send(new CreateArtGalleryQuery(newGallery));

                return StatusCode(StatusCodes.Status201Created, gallery);
            }
            catch (System.Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro tentando Criar um novo registro");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var gallery = await mediator.Send(new DeleteArtGalleryQuery(id));

                if (gallery == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "Sem conteudo para apagar.");
                }
            return StatusCode(StatusCodes.Status200OK, gallery);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro apagando o registro.");
            }
        }
    }
}
