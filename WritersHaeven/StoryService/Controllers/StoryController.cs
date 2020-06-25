using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using RabbitMQ.Client;
using StoryService.Models;

namespace StoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        ConnectionFactory factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://hpeysrar:qR_JEOczB4M30m8zN4M4qhwiSijJDHuw@turkey.rmq.cloudamqp.com/hpeysrar")

        };

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
