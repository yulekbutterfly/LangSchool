using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSchool.Data
{
    class DataEntities
    {
        public static Data.Entities context { get; } =new Data.Entities();
    }
}
