using LinXiDecorate.WPF.ViewModel;
using System;
using System.Collections.Generic;
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

namespace LinXiDecorate.WPF
{
    /// <summary>
    /// RoomCanvas.xaml 的交互逻辑
    /// </summary>
    public partial class RoomCanvas : Canvas
    {
        MainViewModel vm;
        public RoomCanvas()
        {
            InitializeComponent();
            this.Loaded += RoomCanvas_Loaded;

        }

        private void RoomCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as MainViewModel;
        }

        Border drawingBd = null;
        Point startPoint;
  
        private void Canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = Mouse.GetPosition(this);
        }
        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point currentPoint = Mouse.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double offsetX = currentPoint.X - startPoint.X;
                double offsetY = currentPoint.Y - startPoint.Y;
                if (Math.Abs(offsetX) > 2 || Math.Abs(offsetY) > 2)
                {
                    if (drawingBd == null)
                    {
                        drawingBd = new Border();
                        drawingBd.BorderThickness = new Thickness(2);
                        drawingBd.BorderBrush = new SolidColorBrush(Colors.Gray);
                        drawingBd.Background = new SolidColorBrush(Colors.Green);
                        drawingBd.PreviewMouseRightButtonDown += DrawingBd_PreviewMouseRightButtonDown;
                        drawingBd.Tag = "客厅";
                        this.Children.Add(drawingBd);
                        vm.Rooms.Add(drawingBd);
                        Canvas.SetLeft(drawingBd, startPoint.X);
                        Canvas.SetTop(drawingBd, startPoint.Y);
                    }
                    drawingBd.Width = Math.Abs(offsetX);
                    drawingBd.Height = Math.Abs(offsetY);
                    if (offsetX < 0)
                    {
                        Canvas.SetLeft(drawingBd, e.GetPosition(this).X);
                    }
                    if (offsetY < 0)
                    {
                        Canvas.SetTop(drawingBd, e.GetPosition(this).Y);
                    }
                }
            }
        }

        private void DrawingBd_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border bd = sender as Border;
            if (this.Children.Contains(bd))
            {
                this.Children.Remove(bd);
                if (vm != null)
                {
                    vm.Rooms.Remove(bd);
                }
            }
        }

        private void Canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            drawingBd = null;
        }

     
    }
}
