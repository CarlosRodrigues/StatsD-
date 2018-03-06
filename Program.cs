using System;
using System.Threading;

namespace StatsDSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            var statsDConfiguration = new StatsDConfiguration
            {
                Port = 8125,
                Host = "10.168.1.12"
            };

            var statsDService = new StatsDMetricService(statsDConfiguration);

            var i = 0;
            while (i < 100)
            {
                var metric = new Metric
                {
                    Name = "StatsDSharp.test01.Metric1",
                    Value = i,
                    Type = MetricType.Timer
                };
                statsDService.SendMetric(metric);
                Thread.Sleep(5000);
                i+=3;
            }


        }
    }
}
