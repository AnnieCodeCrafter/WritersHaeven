using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Context;
using LoginService.Models;
using LoginService.Repository;

namespace LoginService.Managers
{
    public class AccountManager : IDataRepository<Account>
    {
        private readonly AccountContext accountContext;

        public AccountManager(AccountContext context)
        {
            accountContext = context;
        }

        public void Add(Account entity)
        {
            accountContext.Accounts.Add(entity);
            accountContext.SaveChanges();
        }

        public void Delete(Account entity)
        {
            throw new NotImplementedException();
        }

        public Account Get(int id)
        {
            return accountContext.Accounts.FirstOrDefault(e => e.UserId == id);
        }

        public IEnumerable<Account> GetAll()
        {
            return accountContext.Accounts.ToList();
        }

        public void Update(Account dbEntity, Account entity)
        {
            throw new NotImplementedException();
        }

    }
}
