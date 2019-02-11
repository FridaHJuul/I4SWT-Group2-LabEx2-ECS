using System;
using ECS.Refactored;

namespace ECS.Test.Unit
{
   public class FakeHeater : IRegulator
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