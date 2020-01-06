using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.BarChart;
using ChartJs.Blazor.ChartJS.BarChart.Axes;
using ChartJs.Blazor.ChartJS.Common.Axes;
using ChartJs.Blazor.ChartJS.Common.Axes.Ticks;
using ChartJs.Blazor.ChartJS.Common.Properties;
using ChartJs.Blazor.ChartJS.Common.Wrappers;
using ChartJs.Blazor.Charts;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;
using PvViz.Model;

namespace PvViz.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public HttpClient httpClient { get; set; }

        protected ChartJsBarChart _barChartJs;
        protected ChartJs.Blazor.ChartJS.BarChart.BarConfig _config;
        protected BarDataset<DoubleWrapper> _barDataSet;

        protected DateTime DateFrom = DateTime.Now.AddMonths(-1);
        protected DateTime DateTo = DateTime.Now;

        protected override async Task OnInitializedAsync()
        {
            _config = new BarConfig
            {
                Options = new BarOptions
                {
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Simple Bar Chart"
                    },
                    Scales = new BarScales
                    {
                        XAxes = new List<CartesianAxis>
                    {
                        new BarCategoryAxis
                        {
                            BarPercentage = 0.5,
                            BarThickness = BarThickness.Flex
                        }
                    },
                        YAxes = new List<CartesianAxis>
                    {
                        new BarLinearCartesianAxis
                        {
                            GridLines = new ChartJs.Blazor.ChartJS.Common.GridLines
                            {
                                
                            },
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true,
                                Precision = 1
                            }
                        }
                    }
                    }
                }
            };
            var x = await httpClient.GetJsonAsync<RootObject>("http://192.168.178.46/yields.json?month=1");

            var res = await httpClient.GetAsync("http://192.168.178.46/yields.json?month=1");
            var jsonString = await res.Content.ReadAsStringAsync();
            var pvJson = PvJson.FromJson(jsonString);


            foreach (var dataSet in pvJson.MonthCurves.Datasets)
            {
                
                var color = ColorUtil.RandomColorString();
                var dataOfDataSet = dataSet.Data.Where(x => x.Timestamp >= DateFrom.Date && x.Timestamp <= DateTo).ToArray();
                _barDataSet = new BarDataset<DoubleWrapper>
                {
                    Label = dataSet.Type,
                    BackgroundColor =  color,
                    BorderWidth = 0,
                    //HoverBackgroundColor = ColorUtil.FromDrawingColor(Color.LightBlue),
                    HoverBorderColor = ColorUtil.FromDrawingColor(Color.Black),
                    HoverBorderWidth = 1,
                    BorderColor = "#ffffff"
                };
                var data = dataOfDataSet.SelectMany(x => x.Data).ToArray();
                _barDataSet.AddRange(data.Select(x => (double)x / 1000).Wrap());
                _config.Data.Datasets.Add(_barDataSet);
                for (int i = 1; i <= data.Length; i++)
                {
                    _config.Data.Labels.Add($"{dataOfDataSet[0].Timestamp.ToString("yyyy-MM")}-{i}");
                }
                //_config.Data.Labels.AddRange(dataOfDataSet.Select(x => x.Timestamp.ToShortDateString()));
            }
        }
    }


}
