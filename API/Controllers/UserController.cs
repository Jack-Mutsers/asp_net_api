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
using API.External;
using API.Filters;

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        CurlConnector connector = new CurlConnector();
        
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public UserController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [ApiKeyAuth]
        [HttpPost]
        public IActionResult CreateUser([FromBody]UserForCreationDto user)
        {
            try
            {
                if (user == null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var userEntity = _mapper.Map<User>(user);

                var result = connector.AddUser(userEntity);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [Route("login")]
        [HttpPost]
        public IActionResult login([FromBody]UserForCreationDto user)
        {
            try
            {
                if (user == null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var userEntity = _mapper.Map<User>(user);

                var result = connector.Login(userEntity);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        
        [Route("extend")]
        [HttpPut]
        public IActionResult extend([FromBody]ValidationDto validation)
        {
            try
            {
                if (validation == null)
                {
                    _logger.LogError("id object sent from client is null.");
                    return BadRequest("id object is null");
                }

                var result = connector.extendTimer(validation.access_token);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }



        [Route("logout")]
        [ApiKeyAuth]
        [HttpPost]
        public IActionResult logout([FromBody]string item)
        {
            try
            {
                Guid token = Guid.Parse(item);
                if (token.GetType() != typeof(Guid))
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }

                var result = connector.Logout(token);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside logout action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        [ApiKeyAuth]
        public IActionResult UpdateUser([FromBody]UserForUpdateDto user)
        {
            try
            {
                if (user == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var response = connector.UpdateUser(user.password, user.id); 

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        [ApiKeyAuth]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                var response = connector.DeleteUser(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}

