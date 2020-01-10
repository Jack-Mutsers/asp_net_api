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
using API.Filters;

namespace API.Controllers
{

    [ApiKeyAuth]
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public CategoryController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
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
                var cat = _repository.Category.GetAllCategoriesWithComponents();

                _logger.LogInfo($"Returned all Categories from database.");

                var CategoryResult = _mapper.Map<IEnumerable<CategoryDto>>(cat);
                return Ok(CategoryResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllCategories action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "CategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var cat = _repository.Category.GetCategoryById(id);

                if (cat == null)
                {
                    _logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Category with id: {id}");

                    var CategoryResult = _mapper.Map<CategoryDto>(cat);
                    return Ok(CategoryResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody]CategoryForCreationDto category)
        {
            try
            {
                if (category == null)
                {
                    _logger.LogError("category object sent from client is null.");
                    return BadRequest("category object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid category object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var categoryEntity = _mapper.Map<Category>(category);

                _repository.Category.CreateCategory(categoryEntity);
                _repository.Save();

                var createdCategory = _mapper.Map<CategoryDto>(categoryEntity);

                return CreatedAtRoute("CategoryById", new { id = createdCategory.id }, createdCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody]CategoryForUpdateDto cat)
        {
            try
            {
                if (cat == null)
                {
                    _logger.LogError("Category object sent from client is null.");
                    return BadRequest("Category object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid category object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var CategoryEntity = _repository.Category.GetCategoryById(cat.id);
                if (CategoryEntity == null)
                {
                    _logger.LogError($"Category with id: {cat.id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(cat, CategoryEntity);

                _repository.Category.UpdateCategory(CategoryEntity);
                _repository.Save();

                return Ok("Category is updated");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var cat = _repository.Category.GetCategoryById(id);
                if (cat == null)
                {
                    _logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (_repository.Component.componentsByCategory(id).Any())
                {
                    _logger.LogError($"Cannot delete category with id: {id}. It has related components. Delete or alter them first");
                    return BadRequest("Cannot delete category. It has related components. Delete or alter them first");
                }

                _repository.Category.DeleteCategory(cat);
                _repository.Save();

                return Ok("Category is delted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}