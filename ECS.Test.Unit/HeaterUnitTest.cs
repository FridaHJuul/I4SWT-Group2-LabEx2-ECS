using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Refactored;
using NUnit.Framework;

namespace ECS.Test.Unit
{
   [TestFixture]
    public class HeaterUnitTest
   {
      private Heater uut;

      [SetUp]
      public void SetUp()
      {
         uut= new Heater();
      }
   }
}
