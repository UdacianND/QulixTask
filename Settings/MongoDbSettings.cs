using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QulixTask.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string DatabaseName { get; set; }
        public string DbConnectionUrl { 
            get 
            {
                return $"mongodb://{Host}:{Port}";
            } 
        }

    }
}
