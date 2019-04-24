using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmdApi.Models;
using CmdApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandService _collection;

        public CommandsController(CommandService collection) => _collection = collection;
        //GET: api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _collection.Get();
        }

        //GET: api/commands/id
        [HttpGet("{id:length(24)}", Name = "GetCommand")]
        public ActionResult<Command> GetACommand(string id)
        {
            var command = _collection.Get(id);

            if (command == null)
            {
                return NotFound();
            }

            return command;
        }

        //POST: api/commands/
        [HttpPost]
        public ActionResult<Command> Create([FromBody]Command command)
        {
            _collection.Create(command);
            return CreatedAtAction("GetCommand", new { id = command.Id.ToString() }, command);
        }

        //PUT: api/commands
    }
}