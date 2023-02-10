using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class ThreadPoolWorkClass : ThreadWorkClass
    {
       public void WritePlus(object state)
       {
           base.WritePlus();
       }

       public void WriteMinus(object state)
       {
            base.WriteMinus();
       }
    }
}
