using System;
using System.Threading;
using GrFamily.ExternalBoard;
using GrFamily.MainBoard;
using Microsoft.SPOT;

namespace TemperatureIntervalTest
{
    public class Program
    {
        private static Temperature _temperature;

        public static void Main()
        {
            var peach = new Peach();
            _temperature = (new SensorBoard((IMainBoard)peach)).Temperature;
            _temperature.MeasurementComplete += temperature_MeasurementComplete;
            _temperature.MeasurementInterval = new TimeSpan(0, 0, 3);

            Debug.Print("StartTakingMeasurements");
            _temperature.StartTakingMeasurements();

            Thread.Sleep(30000);

            _temperature.StopTakingMeasurements();
            Debug.Print("StopTakingMeasurements");
        }

        static void temperature_MeasurementComplete(Temperature sender, Temperature.MeasurementCompleteEventArgs e)
        {
            var temp = e.Temperature;
            Debug.Print(temp.ToString());
        }
    }
}
