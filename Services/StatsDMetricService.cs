using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace StatsDSharp
{
    public class StatsDMetricService
    {

        private StatsDConfiguration _configuration;
        public StatsDMetricService(StatsDConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            this._configuration = configuration;
        }

        public void SendMetric(Metric metric)
        {
            var metricBody = this.GetMetricBody(metric);
            this.SendUDPMessage(metricBody);
        }

        private void SendUDPMessage(string datagram)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress serverAddr = IPAddress.Parse(this._configuration.IP);
            IPEndPoint endPoint = new IPEndPoint(serverAddr, this._configuration.Port);
            byte[] send_buffer = Encoding.ASCII.GetBytes(datagram);
            sock.SendTo(send_buffer, endPoint);
            Console.WriteLine($"Sent {datagram}");
        }


        private string GetMetricBody(Metric metric)
        {
            var body = $"{metric.Name}:{metric.Value}|{this.GetMetricType(metric.Type)}";
            if (metric.SampleRate > 0)
            {
                body += $"|@{metric.SampleRate}";
            }
            return body;
        }

        private string GetMetricType(MetricType type)
        {
            switch (type)
            {
                case MetricType.Counter: return "c";
                case MetricType.Gauge: return "g";
                case MetricType.Set: return "s";
                case MetricType.Timer: return "ms";
                default: throw new Exception($"Invalid metric type {type.ToString()}");
            }
        }
    }
}