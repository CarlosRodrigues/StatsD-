namespace StatsDSharp
{
    public class Metric
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public MetricType Type { get; set; }
        public float SampleRate { get; set; }
    }
}