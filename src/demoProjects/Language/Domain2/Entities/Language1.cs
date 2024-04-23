using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain2.Entities
{
    public class Language1:Entity
    {
  
        public string Name { get; set; }

        public Language1()
        {

        }

        public Language1(int ıd,string name ):this() 
        {
            Id = ıd;
            Name = name;
        }
    }
}
