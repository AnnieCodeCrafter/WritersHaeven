using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Models;
using MongoDB.Driver;

namespace LoginService.Managers
{
    public class MongoAccountManager
    {
        private readonly IMongoCollection<Account> _account;

        public MongoAccountManager(IAccountDbSettings settings)
        {
            //var client = new MongoClient(settings.ConnectionString);
            // var database = client.GetDatabase(settings.DatabaseName);
            var client = new MongoClient("mongodb+srv://Admin:Admin@haeven-3jnii.azure.mongodb.net/haccount?retryWrites=true&w=majority");
            var database = client.GetDatabase("haccount");


            _account = database.GetCollection<Account>("account");
        }

        public List<Account> Get() =>
            _account.Find(account => true).ToList();

        public Account Get(string username) =>
            _account.Find(account => account.Name == username).FirstOrDefault();

        public Account Create(Account account)
        {
            _account.InsertOne(account);
            return account;
        }

        public void Update(string username, Account accountIn) =>
            _account.ReplaceOne(account => account.Name == username, accountIn);

        public void Remove(Account accountIn) =>
            _account.DeleteOne(account => account.UserId == accountIn.UserId);

        public void Remove(string username) =>
            _account.DeleteOne(a => a.Name == username);
    }
}
