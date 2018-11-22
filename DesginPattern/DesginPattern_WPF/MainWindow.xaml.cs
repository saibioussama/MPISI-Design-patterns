using DesginPattern_TP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesginPattern_WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    Nullable<Point> dragStart = null;
    private Shape SelectedShape = null;
    private Size SelectedShapeSize;

    private List<ShapeFactory.ShapeType> Shapes = new List<ShapeFactory.ShapeType>();

    public Random rand { get; set; } = new Random();

    public MainWindow()
    {
      InitializeComponent();
      Shapes = Enum.GetValues(typeof(ShapeFactory.ShapeType)).Cast<ShapeFactory.ShapeType>().ToList();
      ShapesCombobox.ItemsSource = Shapes;
    }


    private void AddShapeBtn_Click(object sender, RoutedEventArgs e)
    {
      switch (Shapes[ShapesCombobox.SelectedIndex])
      {
        case ShapeFactory.ShapeType.Rectangle:
          canvas.Children.Add(CreateRectangle(Color.FromRgb(Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255)))));
          break;
        case ShapeFactory.ShapeType.Circle:
          canvas.Children.Add(CreateEllipse(Color.FromRgb(Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255)))));
          break;
        case ShapeFactory.ShapeType.Square:
          canvas.Children.Add(CreateRectangle(Color.FromRgb(Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255)))));
          break;
        default:
          break;
      }

    }

    Rectangle CreateRectangle(Color color)
    {
      var size = rand.Next(50) + 50;
      var rect = new Rectangle()
      {
        Width = rand.Next(100) + size,
        Height = rand.Next(100) + size,
        Fill = new SolidColorBrush(color),
        Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
        StrokeThickness = 3,
      };
      enableDrag(rect);
      return rect;
    }

    Ellipse CreateEllipse(Color color)
    {
      var size = rand.Next(150) + 50;

      var ellipse = new Ellipse()
      {
        Width = size,
        Height = size,
        Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"C:\Users\saibi\OneDrive\Images\Saved Pictures\Square.JPG")) },
        //Fill = new SolidColorBrush(color),
        Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
        StrokeThickness = 3,
      };
      enableDrag(ellipse);
      return ellipse;
    }

    private void Shape_MouseUp(object sender, MouseButtonEventArgs e)
    {
      var element = (UIElement)sender;
      dragStart = null;
      element.ReleaseMouseCapture();
    }

    private void Shape_MouseDown(object sender, MouseButtonEventArgs e)
    {
      var element = (UIElement)sender;
      dragStart = e.GetPosition(element);
      element.CaptureMouse();
      SelectedShape = (Shape)element;
      SelectedShapeSize.Height = SelectedShape.Height;
      SelectedShapeSize.Width = SelectedShape.Width;
    }

    private void enableDrag(Shape shape)
    {
      shape.MouseDown += Shape_MouseDown;
      shape.MouseUp += Shape_MouseUp;
      shape.MouseMove += Shape_MouseMove;
    }

    private void Shape_MouseMove(object sender, MouseEventArgs e)
    {
      if (dragStart != null && e.LeftButton == MouseButtonState.Pressed)
      {
        var element = (UIElement)sender;
        var p2 = e.GetPosition(canvas);
        Canvas.SetLeft(element, p2.X - dragStart.Value.X);
        Canvas.SetTop(element, p2.Y - dragStart.Value.Y);
      }
    }

    private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (SelectedShape != null)
      {
        SelectedShape.Height = SelectedShapeSize.Height * SizeSlider.Value / 100;
        SelectedShape.Width = SelectedShapeSize.Width * SizeSlider.Value / 100;
        SizeTextBlock.Text = SizeSlider.Value.ToString();
      }
    }

    private void RemoveBtn_Click(object sender, RoutedEventArgs e)
    {
      canvas.Children.Remove(SelectedShape);
    }

    private void SetOnTopBtn_Click(object sender, RoutedEventArgs e)
    {
      canvas.Children.Remove(SelectedShape);
      canvas.Children.Add(SelectedShape);
    }
  }
}
