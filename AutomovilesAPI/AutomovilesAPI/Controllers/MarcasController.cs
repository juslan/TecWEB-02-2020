using AutomovilesAPI.Exceptions;
using AutomovilesAPI.Models;
using AutomovilesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutomovilesAPI.Controllers
{
    [Route("api/[controller]")]
    public class MarcasController : Controller
    {
        public IMarcasService _marcaService;
        public MarcasController(IMarcasService marcaService)
        {
            this._marcaService = marcaService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MarcaModel>> GetMarcas(string orderBy = "Id"){
            try
            {
                return Ok(_marcaService.GetMarcas(orderBy));
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }

        }

        [HttpGet("{marcaId:int}", Name = "GetMarca")]
        public ActionResult<MarcaModel> GetMarca(int marcaId)
        {
            try
            {
                return Ok(_marcaService.GetMarca(marcaId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }


        }
        [HttpPost]
        public ActionResult<MarcaModel> CreateMarca([FromBody]MarcaModel marcaModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var url = HttpContext.Request.Host;
                var newMarca = _marcaService.CreateMarca(marcaModel);
                return CreatedAtRoute("GetMarca", new { marcaId = newMarca.Id }, newMarca);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpDelete("{marcaId:int}")] //generics
        public ActionResult<DeleteModel> DeleteMarca(int marcaId)
        {
            try
            {
                return Ok(_marcaService.DeleteMarca(marcaId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPut("{marcaId:int}")]
        public IActionResult UpdateMarca(int marcaId, [FromBody] MarcaModel marcaModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if(pair.Key == nameof(marcaModel.Founder) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }
                return Ok(_marcaService.UpdateMarca(marcaId, marcaModel));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }         

    }
}
