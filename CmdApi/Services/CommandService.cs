using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmdApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CmdApi.Services
{
    public class CommandService
    {
        private readonly IMongoCollection<Command> _commands;

        public CommandService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CommandAPIConnection"));
            var database = client.GetDatabase("CmdApi");
            _commands = database.GetCollection<Command>("Commands");
        }

        public List<Command> Get()
        {
            return _commands.Find(command => true).ToList();
        }

        public Command Get(string id)
        {
            return _commands.Find<Command>(command => command.Id == id).FirstOrDefault();
        }

        public Command Create(Command command)
        {
            _commands.InsertOne(command);
            return command;
        }

        public void Update(string id, Command commandIn)
        {
            _commands.ReplaceOne<Command>(command => command.Id == id, commandIn);
        }

        public void Remove(Command commandIn)
        {
            _commands.DeleteOne<Command>(command => command.Id == commandIn.Id);
        }

        public void Remove(string id)
        {
            _commands.DeleteOne<Command>(command => command.Id == id);
        }
    }
}