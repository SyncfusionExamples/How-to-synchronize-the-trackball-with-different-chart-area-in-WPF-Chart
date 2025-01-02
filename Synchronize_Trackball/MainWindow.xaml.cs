using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Charts;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Synchronize_Trackball
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Point MousePoint
        {
            get;
            set;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SfChart_MouseMove1(object sender, MouseEventArgs e)
        {
            // Taking the first chart position as reference to get the mouse point.
            MousePoint = Mouse.GetPosition(behavior1.AdorningCanvas);
            var chart1 = (sender as SfChart);

            if (chart1.SeriesClipRect.Contains(MousePoint))
            {
                // Generalizing position with respect to axis width.
                MousePoint = new Point(
                MousePoint.X - chart1.SeriesClipRect.Left,
                MousePoint.Y - chart1.SeriesClipRect.Top);

                behavior1.ActivateTrackball(MousePoint);
                behavior2.ActivateTrackball(MousePoint);
            }
            else
            {
                behavior1.DeactivateTrackball();
                behavior2.DeactivateTrackball();
            }
        }

        private void SfChart_MouseMove2(object sender, MouseEventArgs e)
        {
            // Taking the second chart position as reference to get the mouse point.
            MousePoint = Mouse.GetPosition(behavior2.AdorningCanvas);
            var chart2 = (sender as SfChart);

            if (chart2.SeriesClipRect.Contains(MousePoint))
            {
                // Generalizing position with respect to axis width.
                MousePoint = new Point(
                MousePoint.X - chart2.SeriesClipRect.Left,
                MousePoint.Y - chart2.SeriesClipRect.Top);

                behavior1.ActivateTrackball(MousePoint);
                behavior2.ActivateTrackball(MousePoint);
            }
            else
            {
                behavior1.DeactivateTrackball();
                behavior2.DeactivateTrackball();
            }
        }
    }

    public class CustomTrackBallBehavior : ChartTrackBallBehavior
    {
        public void ActivateTrackball(Point mousePoint)
        {
            IsActivated = true;
            OnPointerPositionChanged(mousePoint);
        }

        public void DeactivateTrackball()
        {
            IsActivated = false;
        }
    }
}