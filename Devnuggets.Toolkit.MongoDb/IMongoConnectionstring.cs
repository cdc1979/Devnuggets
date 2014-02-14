using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devnuggets.Toolkit.MongoDb
{
    public interface IMongoConnectionstring
    {
        string GetConnectionstring();
    }

    public class MongoConnectionStringFromWebConfig : IMongoConnectionstring
    {
        public string GetConnectionstring()
        {
            return ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString;
        }
    }
}
