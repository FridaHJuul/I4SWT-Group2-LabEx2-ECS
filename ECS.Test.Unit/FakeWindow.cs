﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Refactored;

namespace ECS.Test.Unit
{
   public class FakeWindow : IRegulator
   {
      public void TurnOn()
      {
         throw new NotImplementedException();
      }

      public void TurnOff()
      {
         throw new NotImplementedException();
      }

      public bool RunSelfTest()
      {
         throw new NotImplementedException();
      }
   }
}
