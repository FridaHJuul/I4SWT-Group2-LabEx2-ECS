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

         Console.WriteLine("Press 'C' to change the thresholds");
         ConsoleKeyInfo key = Console.ReadKey(true);
         char _char = key.KeyChar;

         if (_char == 'C' || _char == 'c')
         {
            Console.WriteLine("Enter threshold for window: ");
            string thresholdWindow = Console.ReadLine();
            Console.WriteLine("Enter threshold for heater: ");
            string thresholdHeater = Console.ReadLine();

            var thrWindow = Convert.ToInt64(thresholdWindow);
            var thrHeater = Convert.ToInt64(thresholdHeater);
            

         }
         Console.ReadKey();
      }
   }
}
