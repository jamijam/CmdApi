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
            var database = client.GetDatabase("")
        }

    }
}
