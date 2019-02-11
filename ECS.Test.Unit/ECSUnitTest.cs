using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Refactored;
using NUnit.Framework;

namespace ECS.Test.Unit
{
   [TestFixture]
   public class ECSUnitTest
   {
      private Refactored.ECS uut;
      private ISensor _sensor;
      private IRegulator _regulator;

      [SetUp]
      public void SetUp()
      {
         _sensor = new FakeSensor();
         _regulator = new FakeHeater();
         uut = new Refactored.ECS(28, _sensor, _regulator);
      }

      [Test]
      public void Regulate_TempIsLow_HeaterOn()
      {
         
      }
   }
}
