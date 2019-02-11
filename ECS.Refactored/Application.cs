using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Refactored
{
   public class Application
   {
      static void Main(string[] args)
      {
         IRegulator regulator = new Heater();
         ISensor sensor = new TempSensor();

         var ecs = new ECS(28, sensor, regulator);

         ecs.Regulate();

         ecs.SetThreshold(20);

         ecs.Regulate();

         Console.ReadKey();
      }
   }
}
