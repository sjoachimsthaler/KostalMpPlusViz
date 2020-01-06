using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvViz.Model
{
    public class Datum
    {
        public string Timestamp { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; }
        public List<long> Data { get; set; }
    }

    public class Dataset
    {
        public string Type { get; set; }
        public int Default { get; set; }
        public List<Datum> Data { get; set; }
    }

    public class DayCurves
    {
        public bool ShowVirtualDatasets { get; set; }
        public string Format { get; set; }
        public string Unit { get; set; }
        public string IncrementUnit { get; set; }
        public int IncrementStep { get; set; }
        public List<Dataset> Datasets { get; set; }
    }

    public class Datum2
    {
        public string Timestamp { get; set; }
        public List<int> Data { get; set; }
    }

    public class Dataset2
    {
        public string Type { get; set; }
        public List<Datum2> Data { get; set; }
    }

    public class MonthCurves
    {
        public bool ShowVirtualDatasets { get; set; }
        public string Format { get; set; }
        public string Unit { get; set; }
        public string IncrementUnit { get; set; }
        public int IncrementStep { get; set; }
        public List<Dataset2> Datasets { get; set; }
    }

    public class Datum3
    {
        public string Timestamp { get; set; }
        public List<int> Data { get; set; }
    }

    public class Dataset3
    {
        public string Type { get; set; }
        public List<Datum3> Data { get; set; }
    }

    public class YearCurves
    {
        public bool ShowVirtualDatasets { get; set; }
        public string Format { get; set; }
        public string Unit { get; set; }
        public string IncrementUnit { get; set; }
        public int IncrementStep { get; set; }
        public List<Dataset3> Datasets { get; set; }
    }

    public class Datum4
    {
        public string Timestamp { get; set; }
        public int Data { get; set; }
    }

    public class Dataset4
    {
        public string Type { get; set; }
        public List<Datum4> Data { get; set; }
    }

    public class TotalCurves
    {
        public bool ShowVirtualDatasets { get; set; }
        public string Format { get; set; }
        public string Unit { get; set; }
        public string IncrementUnit { get; set; }
        public int IncrementStep { get; set; }
        public List<Dataset4> Datasets { get; set; }
    }

    public class RootObject
    {
        public DayCurves DayCurves { get; set; }
        public MonthCurves MonthCurves { get; set; }
        public YearCurves YearCurves { get; set; }
        public TotalCurves TotalCurves { get; set; }
    }
}
