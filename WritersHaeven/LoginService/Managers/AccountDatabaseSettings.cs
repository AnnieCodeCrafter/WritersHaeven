using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Managers
{
    public class AccountDatabaseSettings : IAccountDbSettings
    {
       
        public string AccountCollectionName { get; set; }
       public string ConnectionString { get; set; }
       // string IAccountDbSettings.ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DatabaseName { get; set; }
       // string IAccountDbSettings.DatabaseName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public interface IAccountDbSettings
    {
        string AccountCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
