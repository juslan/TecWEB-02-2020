using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutomovilesAPI.Exceptions;
using AutomovilesAPI.Models;
using AutomovilesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomovilesAPI.Controllers
{
    [Route("api/marcas/{marcaId:int}/[controller]")]
    public class AutomovilesController : ControllerBase
    {
        private IAutomovilesService _automovilService;

        public AutomovilesController(IAutomovilesService automovilService)
        {
            _automovilService = automovilService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<AutomovilModel>> GetAutomoviles(int marcaId)
        {
            try
            {
                return Ok(_automovilService.GetAutomoviles(marcaId));
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
        [HttpGet("{automovilId:int}", Name="GetAutomovil")]//nombre de la ruta Getautomovil
        public ActionResult<IEnumerable<AutomovilModel>> GetAutomovil(int marcaId, int automovilId)
        {
            try
            {
                return Ok(_automovilService.GetAutomovil(marcaId,automovilId));
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
        public ActionResult<AutomovilModel> CreateAutomovi(int marcaId,[FromBody] AutomovilModel automovil)
        {
            try
            {
                var automovilCreated = _automovilService.CreateAutomovil(marcaId, automovil);
                return CreatedAtRoute("GetAutomovil", new { marcaId = marcaId, automovilId = automovilCreated.Id}, automovilCreated);
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
        [HttpPut("{automovilId:int}")]
        public ActionResult<AutomovilModel> UpdateAutomovil(int marcaId, int automovilId,[FromBody] AutomovilModel automovilModel)
        {
            try
            {
                return Ok(_automovilService.UpdateAutomovil(marcaId,automovilId, automovilModel));
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
        [HttpDelete("{automovilId:int}")]
        public ActionResult<bool> DeleteAutomovil(int marcaId, int automovilId)
        {
            try
            {
                return Ok(_automovilService.DeleteAutomovil(marcaId, marcaId));
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
