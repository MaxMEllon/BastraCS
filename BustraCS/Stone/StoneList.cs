using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BustraCS.Stone
{
    public class StoneList : Collection<Stone>
    {
        public StoneList()
        {
            new Collection<Stone>();
        }
    }
}