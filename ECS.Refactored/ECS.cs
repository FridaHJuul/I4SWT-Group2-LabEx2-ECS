namespace ECS.Refactored
{
    public class ECS
    {
        private int _threshold;
        private readonly ISensor _tempSensor;
        private readonly IRegulator _heater;

        public ECS(int thr, ISensor tempSensor, IRegulator heater)
        {
           _tempSensor = tempSensor;
           _heater = heater;
           SetThreshold(thr);
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
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
