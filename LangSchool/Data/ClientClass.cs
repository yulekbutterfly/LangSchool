using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LangSchool.Data.DataEntities;

namespace LangSchool.Data
{
     public partial class Client
    {
        public static object Context { get; internal set; }

        public DateTime? LastVisit
        {
            get
            {
                return ClientService.LastOrDefault()?.DateStart;
            }
      
       }
        public int CountVisit
        {
            get
            {
                return ClientService.Count();
            }
        }
        public List<Tag> Tags
        {
            get
            {
                return Tag.ToList();
            }
        }

    }  
}
