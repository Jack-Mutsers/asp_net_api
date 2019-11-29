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
    [Route("api/component")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ComponentController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllComponents()
        {
            try
            {
                var users = _repository.Component.GetAllComponents();

                _logger.LogInfo($"Returned all users from database.");

                var usersResult = _mapper.Map<IEnumerable<UserDto>>(users);
                return Ok(usersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUsers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ComponentById")]
        public IActionResult GetComponentById(int id)
        {
            try
            {
                var comp = _repository.Component.GetComponentById(id);

                if (comp == null)
                {
                    _logger.LogError($"Component with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Component with id: {id}");

                    var componentResult = _mapper.Map<ComponentDto>(comp);
                    return Ok(componentResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("categorie/{id}")]
        public IActionResult GetComponentsWithCategorie(int id)
        {
            try
            {
                var comps = _repository.Component.GetComponentsWithCategorie(id);

                if (comps == null)
                {
                    _logger.LogError($"components with categorie id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned components with categorie id: {id}");

                    var componentResult = _mapper.Map<ComponentDto>(comps);
                    return Ok(componentResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateComponent([FromBody]ComponentForCreationDto comp)
        {
            try
            {
                if (comp == null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var compEntity = _mapper.Map<Component>(comp);

                _repository.Component.CreateComponent(compEntity);
                _repository.Save();

                var createdComponent = _mapper.Map<UserDto>(compEntity);

                return CreatedAtRoute("ComponentById", new { id = createdComponent.id }, createdComponent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}