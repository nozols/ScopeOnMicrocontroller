using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ScopeOnMicrocontroller
{
    class GraphDataPoint : DataPoint
    {
        public static double XShift = 0;
        public static double YShift = 0;

        private readonly double XLocal = 0;
        private readonly double YLocal = 0;

        public double XValue
        {
            get
            {
                return XLocal - XShift;
            }
        }

        public double YValue
        {
            get
            {
                return YLocal - YShift;
            }
        }

        public GraphDataPoint(double x, double y)
        {
            XLocal = x;
            YLocal = y;
        }

        public GraphDataPoint()
        {
        }

        public GraphDataPoint(Series series) : base(series)
        {
        }

        public GraphDataPoint(double xValue, double[] yValues) : base(xValue, yValues)
        {
        }

        public GraphDataPoint(double xValue, string yValues) : base(xValue, yValues)
        {
        }
    }
}
