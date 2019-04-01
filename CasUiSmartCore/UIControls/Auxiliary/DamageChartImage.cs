using System.Drawing;

namespace CAS.UI.UIControls.Auxiliary
{
    class DamageChartImage
    {
        public string ChartName { get; set; }
        public string ImagePath { get; set; }
        public Image Image { get; set; }
        public int CountColumns { get; set; }

        public int CountRows { get; set; }

        public Point SelectedPoint { get; set; }

        public DamageChartImage(string chartName, Image image, int countColumns, int countRows)
        {
            ChartName = chartName;
            Image = image;
            CountColumns = countColumns;
            CountRows = countRows;
        }

        public override string ToString()
        {
            return ChartName;
        }
    }
}
