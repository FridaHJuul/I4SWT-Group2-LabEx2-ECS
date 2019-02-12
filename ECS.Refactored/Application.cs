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
         IRegulator heater = new Heater();
         IRegulator window = new Window();
         ISensor sensor = new TempSensor();

         var ecs = new ECS(28, 28, sensor, heater, window);

         ecs.Regulate();

         ecs.SetHeaterThreshold(20);

         ecs.Regulate();

         Console.ReadKey();
      }
   }
}
