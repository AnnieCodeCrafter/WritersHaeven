using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Context;
using LoginService.Managers;
using LoginService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Configuration;
using System.Text;
using MongoDB.Bson;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        //rabbitMQ
        private static string url = ConfigurationManager.AppSettings["CLOUDAMQP_URL"];
        //  static readonly ConnectionFactory connFactory = new ConnectionFactory();
        ConnectionFactory factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://hpeysrar:qR_JEOczB4M30m8zN4M4qhwiSijJDHuw@turkey.rmq.cloudamqp.com/hpeysrar")

        };
    
        
        //mongoDB
        private readonly MongoAccountManager _context;

        public AccountController(MongoAccountManager context)
        {
            _context = context;
        }


        //GET: api/account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> getAccounts()
        {

            return await Task.FromResult(_context.Get());

        }

        //POST: api/account
        [HttpPost]
        public ActionResult<Account> postAccount(Account account)
        {

            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                _context.Create(account);
                var data = Encoding.UTF8.GetBytes(account.ToString());
                channel.QueueDeclare("queue1", false, false, false, null);
                // publish to the "default exchange", with the queue name as the routing key
                channel.BasicPublish("", "queue1", null, data);
            }




            return CreatedAtAction("GetAccount", new { id = account.UserId }, account);

        }

        //GET: api/account/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(string username)
        {


            var account = await Task.FromResult(_context.Get(username));

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        //GET: api/account/queue
        //Testing getting stuff out of the queue
        [HttpGet("queue")]
        public ActionResult<Account> GetQueue()
        {
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                // ensure that the queue exists before we access it
                channel.QueueDeclare("queue1", false, false, false, null);
                // do a simple poll of the queue 
                var data = channel.BasicGet("queue1", false);
                // the message is null if the queue was empty 

                if (data == null)
                {
                    return NotFound();
                }

                // convert the message back from byte[] to a string
                var message = Encoding.UTF8.GetString(data.Body.Span);
                // ack the message, ie. confirm that we have processed it
                // otherwise it will be requeued a bit later
                channel.BasicAck(data.DeliveryTag, false);
                return toAccount(message.ToString());
            }

        }



        public Account toAccount(string Str)
        {
            String[] split = Str.Split(",");
            string splot0 = split[0];
            ObjectId split0 = MongoDB.Bson.ObjectId.Parse(splot0);
            string split1 = split[1];
            string split2 = split[2];

            return new Account
            {
                UserId = split0,
                Name = split1,
                PssWord = split2
        };
        }
    }
}
    




