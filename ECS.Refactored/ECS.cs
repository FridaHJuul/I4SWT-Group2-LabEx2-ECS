namespace ECS.Refactored
{
   public class ECS
   {
      private int _windowThreshold;
      private int _heaterThreshold;
      private readonly ISensor _tempSensor;
      private readonly IRegulator _heater;
      private readonly IRegulator _window;

      public ECS(int windowthr, int heaterthr, ISensor tempSensor, IRegulator heater, IRegulator window)
      {
         _tempSensor = tempSensor;
         _heater = heater;
         _window = window;
         SetHeaterThreshold(heaterthr);
         SetWindowThreshold(windowthr);
      }

      public void Regulate()
      {
         var t = _tempSensor.GetTemp();

         if (t < _heaterThreshold)
            _heater.TurnOn();
         else
            _heater.TurnOff();

         if (t < _windowThreshold)
            _window.TurnOff();
         else
            _window.TurnOn();
      }

      public void SetHeaterThreshold(int thr)
      {
         _heaterThreshold = thr;
      }

      public int GetHeaterThreshold()
      {
         return _heaterThreshold;
      }

      public void SetWindowThreshold(int thr)
      {
         _windowThreshold = thr;
      }

      public int GetWindowThreshold()
      {
         return _windowThreshold;
      }

      public int GetCurTemp()
      {
         return _tempSensor.GetTemp();
      }

      public bool RunSelfTest()
      {
         return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
      }
   }
}
