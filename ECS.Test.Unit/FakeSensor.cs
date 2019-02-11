using System;
using ECS.Refactored;

namespace ECS.Test.Unit
{
   public class FakeSensor : ISensor
   {
      public bool WasCalled = false;
      public int Temp { get; set; }
      public int GetTemp()
      {
         WasCalled = true;
         return Temp;
      }

      public bool RunSelfTest()
      {
         throw new NotImplementedException();
      }
   }
}