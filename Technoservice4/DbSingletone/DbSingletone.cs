using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technoservice4.DbSingletone
{
    public static class DbSingletone
    {
        public static TecnoserviceEntities Db { get; set; } = new TecnoserviceEntities();
    }
}
