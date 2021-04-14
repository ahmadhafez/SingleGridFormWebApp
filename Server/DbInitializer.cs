using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleGridFormWebApp.Server
{
    public class DbInitializer
    {
        public static void Initialize(FormContext context)
        {
            context.Database.EnsureCreated();

        }
    }
}
