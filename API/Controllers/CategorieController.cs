using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.Models;

namespace API.Controllers
{
    [Route("api/categorie")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public CategorieController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var cat = _repository.Categorie.GetAllCategories();

                _logger.LogInfo($"Returned all categories from database.");

                var categorieResult = _mapper.Map<IEnumerable<CategorieDto>>(cat);
                return Ok(categorieResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllCategories action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "CategorieById")]
        public IActionResult GetCategorieById(int id)
        {
            try
            {
                var cat = _repository.Categorie.GetCategorieById(id);

                if (cat == null)
                {
                    _logger.LogError($"categorie with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned categorie with id: {id}");

                    var categorieResult = _mapper.Map<CategorieDto>(cat);
                    return Ok(categorieResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateCategorie([FromBody]CategorieForCreationDto categorie)
        {
            try
            {
                if (categorie == null)
                {
                    _logger.LogError("categorie object sent from client is null.");
                    return BadRequest("categorie object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid categorie object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var categorieEntity = _mapper.Map<Categorie>(categorie);

                _repository.Categorie.CreateCategorie(categorieEntity);
                _repository.Save();

                var createdCategorie = _mapper.Map<CategorieDto>(categorieEntity);

                return CreatedAtRoute("CategorieById", new { id = createdCategorie.id }, createdCategorie);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCategorie action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}