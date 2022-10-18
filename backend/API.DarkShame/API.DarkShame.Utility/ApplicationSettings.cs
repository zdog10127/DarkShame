using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Utility
{
    public class ApplicationSettings
    {
        public static string GetStringMongoConnection()
        {
            Settings settings = new Settings();
            return settings.Configuration["ConnectionStringMongoDB"];
        }
    }
}
