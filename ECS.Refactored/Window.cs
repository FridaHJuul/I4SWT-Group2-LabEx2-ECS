using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Refactored
{
   public class Window : IRegulator
   {
      public void TurnOn()
      {
         Console.WriteLine("The windows is open");
      }

      public void TurnOff()
      {
         Console.WriteLine("The window is closed");
      }

      public bool RunSelfTest()
      {
         throw new NotImplementedException();
      }
   }
}
