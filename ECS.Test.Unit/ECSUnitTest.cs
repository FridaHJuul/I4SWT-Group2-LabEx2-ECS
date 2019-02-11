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
      private FakeHeater _regulator;

      [SetUp]
      public void SetUp()
      {
         _sensor = new FakeSensor();
         _regulator = new FakeHeater();
         uut = new Refactored.ECS(28, _sensor, _regulator);
      }

      [TestCase(-1)]
      [TestCase(0)]
      [TestCase(25)]
      [TestCase(27)]
      public void Regulate_TempIsLow_HeaterOn(int temp)
      {
         _sensor.Temp = temp;
         uut.Regulate();
         Assert.That(_regulator.OnWasCalled, Is.True);
      }

      [TestCase(-1)]
      [TestCase(0)]
      [TestCase(25)]
      [TestCase(27)]
      public void Regulate_TempIsLow_OffNotCalled(int temp)
      {
         _sensor.Temp = temp;
         uut.Regulate();
         Assert.That(_regulator.OffWasCalled, Is.False);
      }

      [TestCase(28)]
      [TestCase(29)]
      [TestCase(2500)]
      public void Regulate_TempIsHigh_OnNotCalled(int temp)
      {
         _sensor.Temp = temp;
         uut.Regulate();
         Assert.That(_regulator.OnWasCalled, Is.False);
      }

      [TestCase(28)]
      [TestCase(29)]
      [TestCase(2500)]
      public void Regulate_TempIsHigh_HeaterOff(int temp)
      {
         _sensor.Temp = temp;
         uut.Regulate();
         Assert.That(_regulator.OffWasCalled, Is.True);
      }

      [TestCase(28)]
      [TestCase(29)]
      [TestCase(2500)]
      public void SetThreshold_ThresholdIsA_returnsA(int A)
      {
         uut.SetThreshold(A);
         Assert.That(uut.GetThreshold(),Is.EqualTo(A));
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
