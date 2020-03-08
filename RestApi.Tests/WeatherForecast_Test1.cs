using Xunit;
using RestApi.Controllers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RestApi.UnitTests
{

    public class WeatherForecast_Test1
    {
        private readonly WeatherForecastController _controller;

        public WeatherForecast_Test1()
        {
            _controller = new WeatherForecastController(null);
        }

        [Fact]
        public void TestName()
        {
        //Given
            List<WeatherForecast> forecast = _controller.Get().ToList();
            DateTime tomorrow = DateTime.Now.AddDays(1);      
        //When
            DateTime dt = forecast.FirstOrDefault().Date;
        //Then
        Assert.True(dt.Day == tomorrow.Day);
        Assert.True(dt.Month == tomorrow.Month);
        Assert.True(dt.Year == tomorrow.Year);

        }
    }
}