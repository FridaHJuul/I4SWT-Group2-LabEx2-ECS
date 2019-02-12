using System;
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
      private FakeSensor _sensor;
      private FakeHeater _heater;
      private FakeWindow _window;

      [SetUp]
      public void SetUp()
      {
         _sensor = new FakeSensor();
         _heater = new FakeHeater();
         _window = new FakeWindow();
         uut = new Refactored.ECS(28,28, _sensor, _heater, _window);
      }

      [TestCase(-1)]
      [TestCase(0)]
      [TestCase(25)]
      [TestCase(27)]
      public void Regulate_TempIsLow_HeaterOn(int temp)
      {
         _sensor.Temp = temp;
         uut.Regulate();
         Assert.That(_heater.OnWasCalled, Is.True);
      }

      [TestCase(-1)]
      [TestCase(0)]
      [TestCase(25)]
      [TestCase(27)]
      public void Regulate_TempIsLow_OffNotCalled(int temp)
      {
         _sensor.Temp = temp;
         uut.Regulate();
         Assert.That(_heater.OffWasCalled, Is.False);
      }

      [TestCase(28)]
      [TestCase(29)]
      [TestCase(2500)]
      public void Regulate_TempIsHigh_OnNotCalled(int temp)
      {
         _sensor.Temp = temp;
         uut.Regulate();
         Assert.That(_heater.OnWasCalled, Is.False);
      }

      [TestCase(28)]
      [TestCase(29)]
      [TestCase(2500)]
      public void Regulate_TempIsHigh_HeaterOff(int temp)
      {
         _sensor.Temp = temp;
         uut.Regulate();
         Assert.That(_heater.OffWasCalled, Is.True);
      }

      [TestCase(28)]
      [TestCase(29)]
      [TestCase(2500)]
      public void SetThreshold_ThresholdIsA_returnsA(int A)
      {
         uut.SetHeaterThreshold(A);
         Assert.That(uut.GetHeaterThreshold(),Is.EqualTo(A));
      }

      [TestCase(-10)]
      [TestCase(0)]
      [TestCase(10)]
      public void GetCurTemp_TempIsA_ReturnsA(int A)
      {
         _sensor.Temp = A;
         Assert.That(uut.GetCurTemp(),Is.EqualTo(A));
      }

   }
}
