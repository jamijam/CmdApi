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
        [HttpGet("{id:length(24)}")]
        public ActionResult<Command> GetCommand(string id)
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
        public ActionResult<Command> Create(Command command)
        {
            _collection.Create(command);

            return CreatedAtAction("GetCommand", new { id = command.Id.ToString() }, command);
        }

        //PUT: api/commands/id
        [HttpPut("{id}")]
        public ActionResult<Command> Update(string id, Command commandIn)
        {
            var command = _collection.Get(id);

            if (command == null)
            {
                return NotFound();
            }

            _collection.Update(id, commandIn);

            return NoContent();
        }

        //PUT: api/commands
        [HttpPut]
        public ActionResult<Command> UpdateViaId(Command commandIn)
        {
            var command = _collection.Get(commandIn.Id);

            if (command == null)
            {
                return NotFound();
            }

            _collection.Update(commandIn.Id, commandIn);

            return Ok(commandIn);
        }

        //DELETE: api/commands/id
        [HttpDelete("{id}")]
        public ActionResult<Command> Delete(string id)
        {
            var command = _collection.Get(id);

            if (command == null)
            {
                return NotFound();
            }

            _collection.Remove(command);

            return Ok(command);
        }
    }
}