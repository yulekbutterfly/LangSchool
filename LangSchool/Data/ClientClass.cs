using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSchool.Data
{
     public partial class Client
    {
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
