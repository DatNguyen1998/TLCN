using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;

namespace TLCN.Web
{
    public class DataInitializer
    {
        public static void Initializer(TLCNDatabaseContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
