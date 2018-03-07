# Welcome to StatsD#
is an educational project that shows how to use UDP to create a lightweight service to send metrics to StatsD.

## Instantiating the Service

```
var statsDConfiguration = new StatsDConfiguration
{
    Port = 8125,
    IP = "10.168.1.12"
};

var statsDService = new StatsDMetricService(statsDConfiguration);
```
where port and host are the respective port and host of the statsD client

## Sending metrics to StatsD
```
var metric = new Metric
{
    Name = "StatsD#.test01.Metric1",
    Value = i,
    Type = MetricType.Timer,
    SampleRate=0.5 //optional
};
statsDService.SendMetric(metric);
```

## Requirements
To run this project you'll need .NET Core 2.0.

## Running the project

Running the small test as a console App

```dotnet run```

