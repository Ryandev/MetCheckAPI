[![Build Status](https://circleci.com/gh/Ryandev/MetCheckAPI.svg?style=svg)](https://circleci.com/gh/Ryandev/MetCheckAPI) 
[circleci build artifact (nupkg)](https://11-262746358-gh.circle-artifacts.com/0/MetCheck.API.nupkg)
[circleci build artifact (dll)](https://4-262746358-gh.circle-artifacts.com/0/MetCheckAPI/bin/Release/netstandard2.1/MetCheckAPI.dll)

# MetCheck.com API
Strongly typed responses for data fetched from MetCheck.com
Definitions of values can be found at both MetCheck.com API & documented in Response.cs

# Nuget
```
Install-Package MetCheck.API
```

# Example
Example usage also included in Example.csproj

Call (get basic results)
```
    using MetCheckAPI;
    ...
    ForecastBody? forecast = await Forecaster.Fetch(50.9, -1);
    Console.WriteLine(forecast?.ToString() ?? "Forecast fetch failed");
```

Response
```
<ResponseBody Date=10/05/2020 08:59:50 MetData=
  <ResponseMetData ForeCast=
    <ResponseForecast ForeCasts:
      <ForecastSnapshot 
        Temperature=13, 
        DewPoint=8, 
        Rain=0.1, 
        FreezingLevel=2515, 
        UVIndex=0, 
        CloudCoverageTotal=93, 
        CloudCoverageHigh=89, 
        CloudCoverageMid=54, 
        CloudCoverageLow=45, 
        Humidity=74, 
        WindSpeed=11, 
        PressureAtSeaLevel=1005.92, 
        WindGustSpeed=13, 
        WindDirection=19, 
        WindLetter=NNE, 
        Icon=RO, 
        IconName=Intermittent Rain, 
        ChanceOfRain=23, 
        ChanceOfSnow=0, 
        Sunrise=10/05/2020 05:52:00, 
        Sunset=10/05/2020 17:59:00, 
        TimeStamp=10/05/2020 07:00:00, 
        SunriseOffset=05:52:00, 
        SunsetOffset=17:59:00, 
        SeeingIndex=None, 
        PickeringIndex=None, 
        TransIndex=None, 
        CumulusBaseHeight=None, 
        StratusBaseHeight=None, 
        FishingIndex=None, 
        EvapoTranspiration=None, 
        SoilMoisture10mm=None, 
        SoilMoisture100mm=None, 
        SoilMoisture400mm=None, 
        StormRisk=None, 
        TornadoRisk=None, 
        DryingTimeLight=None, 
        DryingTimeHeavy=None, 
        IsDayTime=True, 
        IsNightTime=False, >, 
      ...100+ results
>>
```

Call (get aviation specific results with above)
```
    using MetCheckAPI;
    ...
    ForecastBody? forecast = await Forecaster.Fetch(50.9, -1, ForecastRequestType.Aviation);
    Console.WriteLine(forecast?.ToString() ?? "Forecast fetch failed");
```

Response (Note CumulusBaseHeight & StatusBaseHeight are now set)
```
<ResponseBody Date=10/05/2020 09:03:05 MetData=
  <ResponseMetData ForeCast=
    <ResponseForecast ForeCasts:
      <ForecastSnapshot 
        Temperature=14, 
        DewPoint=9, 
        Rain=0.1, 
        FreezingLevel=2484, 
        UVIndex=1, 
        CloudCoverageTotal=99, 
        CloudCoverageHigh=93, 
        CloudCoverageMid=55, 
        CloudCoverageLow=26, 
        Humidity=76, 
        WindSpeed=11, 
        PressureAtSeaLevel=1006.12, 
        WindGustSpeed=13, 
        WindDirection=30, 
        WindLetter=NNE, 
        Icon=RO, 
        IconName=Intermittent Rain, 
        ChanceOfRain=23, 
        ChanceOfSnow=0, 
        Sunrise=10/05/2020 05:52:00, 
        Sunset=10/05/2020 17:59:00, 
        TimeStamp=10/05/2020 08:00:00, 
        SunriseOffset=05:52:00, 
        SunsetOffset=17:59:00, 
        SeeingIndex=None, 
        PickeringIndex=None, 
        TransIndex=None, 
        CumulusBaseHeight=552, 
        StratusBaseHeight=561, 
        FishingIndex=None, 
        EvapoTranspiration=None, 
        SoilMoisture10mm=None, 
        SoilMoisture100mm=None, 
        SoilMoisture400mm=None, 
        StormRisk=None, 
        TornadoRisk=None, 
        DryingTimeLight=None, 
        DryingTimeHeavy=None, 
        IsDayTime=True, 
        IsNightTime=False, >, 
      ...100+ results
>>

```

# MetCheck.com JSON API
https://www.metcheck.com/OTHER/json_data.asp

# License
MIT
