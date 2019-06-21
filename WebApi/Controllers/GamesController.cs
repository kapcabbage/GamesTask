using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using DataAccess.Common;
using DataAccess.POCO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _service;

        public GamesController(IGamesService service)
        {
            _service = service;
        }
        #region Methods

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var serviceResult = _service.GetAllGames();
            if (serviceResult.Status == eOperationStatus.Success)
            {
                return Ok(serviceResult);
            }

            return NotFound();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id, string source = "API")
        {
            var serviceResult = _service.GetGame(id);
            if (serviceResult.Status == eOperationStatus.Success)
            {
                var eventServiceResult = _service.AddEvent(new Event
                {
                    GameId = id,
                    EventTypeId = (int)eEventType.Display,
                    TimeStamp = DateTime.Now,
                    Source = source
                });
   
                return Ok(serviceResult);
            }

            if (serviceResult.Status == eOperationStatus.NotFound)
            {
                return NotFound();
            }

            return BadRequest(serviceResult);
        }

        [HttpGet("{id}/events")]
        public ActionResult GetEvents(int id)
        {
            var serviceResult = _service.GetEvents(id);
            if (serviceResult.Status == eOperationStatus.Success)
            {
                return Ok(serviceResult);
            }

            if (serviceResult.Status == eOperationStatus.NotFound)
            {
                return NotFound();
            }

            return BadRequest(serviceResult);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Game value, string source = "API")
        {
            var result = _service.AddGame(value);
            if (result.Status == eOperationStatus.Success)
            {
                _service.AddEvent(new Event
                {
                    GameId = result.Data,
                    EventTypeId = (int)eEventType.Edit,
                    TimeStamp = DateTime.Now,
                    Source = source
                });
                return Ok(new {Success = result.Data});
            }

            return BadRequest(new {Message = result.ExceptionMessage});
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Game value, string source = "API")
        {
            value.GameId = id;
            var result = _service.UpdateGame(value);
            if (result.Status == eOperationStatus.Success)
            {
                _service.AddEvent(new Event
                {
                    GameId = result.Data,
                    EventTypeId = (int)eEventType.Edit,
                    TimeStamp = DateTime.Now,
                    Source = source
                });
                return Ok(new { Success = result.Data });
            }

            if (result.Status == eOperationStatus.NotFound)
            {
                return NotFound();
            }

            return BadRequest(new { Message = result.ExceptionMessage });
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _service.DeleteGame(id);
            if (result.Status == eOperationStatus.Success)
            {
                return Ok(new { Success = result.Data });
            }
            if (result.Status == eOperationStatus.NotFound)
            {
                return NotFound();
            }
            return BadRequest(new { Message = result.ExceptionMessage });
        }


        #endregion
    }
}