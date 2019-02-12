using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Refactored;

namespace ECS.Test.Unit
{
   public class FakeWindow : IRegulator
   {
      public bool OnWasCalled = false;
      public bool OffWasCalled = false;
      public void TurnOn()
      {
         OnWasCalled = true;
      }

      public void TurnOff()
      {
         OffWasCalled = true;
      }

      public bool RunSelfTest()
      {
         throw new NotImplementedException();
      }
   }
}
