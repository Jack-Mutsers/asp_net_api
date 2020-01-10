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
    [Route("api/arduino")]
    [ApiController]
    public class ArduinoController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ArduinoController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost]
        public void PerformAction([FromBody]ComponentDto component)
        {
            var comp = _repository.Component.GetComponentById(component.id);

            var testc = 1;

        }

        /*/
        [HttpGet]
        public IActionResult GetAllCategories()
        {

        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {

        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody]CategoryForCreationDto category)
        {

        }
        //*/
    }
}