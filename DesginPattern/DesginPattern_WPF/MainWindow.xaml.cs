using DesginPatternCL.Actions;
using DesginPatternCL.Models;
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
    Point? dragStart = null;
    private Shape SelectedShape = null;
    private Size SelectedShapeSize;
    private DesginPatternCL.Models.Shapes.Shape head = ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, ActionFactory.Build(ActionFactory.ActionType.Noise), new Citation());
    private List<ShapeFactory.ShapeType> Shapes = new List<ShapeFactory.ShapeType>();
    private List<ActionFactory.ActionType> Actions = new List<ActionFactory.ActionType>();
    private Citation Citation;
    private DesginPatternCL.Models.Shapes.Shape Container;
    private Dictionary<Shape, DesginPatternCL.Models.Shapes.Shape> dict = new Dictionary<Shape, DesginPatternCL.Models.Shapes.Shape>();

    public Random rand { get; set; } = new Random();

    public MainWindow()
    {
      InitializeComponent();
      Shapes = Enum.GetValues(typeof(ShapeFactory.ShapeType)).Cast<ShapeFactory.ShapeType>().ToList();
      Actions = Enum.GetValues(typeof(ActionFactory.ActionType)).Cast<ActionFactory.ActionType>().ToList();
      ShapesCombobox.ItemsSource = Shapes;
      ActionsCombobox.ItemsSource = Actions;
    }

    private void AddShapeBtn_Click(object sender, RoutedEventArgs e)
    {
      DesginPatternCL.Models.Shapes.Shape shape = null;
      switch (Shapes[ShapesCombobox.SelectedIndex])
      {
        case ShapeFactory.ShapeType.Rectangle:
          shape = ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, Container.Action, Citation);
          shape.SystemShape = CreateRectangle(Color.FromRgb(Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255))));
          break;
        case ShapeFactory.ShapeType.Circle:
          shape = ShapeFactory.Build(ShapeFactory.ShapeType.Circle, Container.Action, Citation);
          shape.SystemShape = CreateEllipse(Color.FromRgb(Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255))));
          break;
        case ShapeFactory.ShapeType.Square:
          shape = ShapeFactory.Build(ShapeFactory.ShapeType.Square, Container.Action, Citation);
          shape.SystemShape = CreateSquare(Color.FromRgb(Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255)), Convert.ToByte(rand.Next(255))));
          break;
        default:
          break;
      }
      var s = dict[SelectedShape];
      if(s!= null && s.GetType() == ShapeFactory.ShapeType.Rectangle)
      {
        ((DesginPatternCL.Models.Shapes.Rectangle)s).Shapes.Add(shape);
        canvas.Children.Add(shape.SystemShape);
        Details.Text = Container.Details();
        dict.Add(shape.SystemShape, shape);
      }else{
        MessageBox.Show($"We can't add shape to {s?.GetType().ToString()}");
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
      var s = dict[SelectedShape];
      s = null;
    }

    private void SetOnTopBtn_Click(object sender, RoutedEventArgs e)
    {
      canvas.Children.Remove(SelectedShape);
      canvas.Children.Add(SelectedShape);
    }

    private void Draw(DesginPatternCL.Models.Shapes.Shape container)
    {
      canvas.Children.Add(container.SystemShape);
      try
      {
        if (container.GetType() == ShapeFactory.ShapeType.Rectangle)
        {
          foreach (var shape in ((DesginPatternCL.Models.Shapes.Rectangle)container).Shapes)
            Draw(shape);
        }
      }
      catch
      {

      }
    }

    #region Create Shapes

    Rectangle CreateRectangle(Color color, double h = 0, double w = 0)
    {
      int size = rand.Next(50) + 50;
      var rect = new Rectangle()
      {
        Width = w == 0 ? rand.Next(100) + size : w,
        Height = h == 0 ? rand.Next(100) + size : h,
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
        //Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"C:\Users\saibi\OneDrive\Images\Saved Pictures\Square.JPG")) },
        Fill = new SolidColorBrush(color),
        Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
        StrokeThickness = 3,
      };
      enableDrag(ellipse);
      return ellipse;
    }

    Rectangle CreateSquare(Color color)
    {
      var size = rand.Next(100) + 100;
      var rect = new Rectangle()
      {
        Width = size,
        Height = size,
        Fill = new SolidColorBrush(color),
        Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
        StrokeThickness = 3,
      };
      enableDrag(rect);
      return rect;
    }

    #endregion 

    #region Drag & Drop 

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
      SelectedShapeTextBlock.Text = SelectedShape.GetHashCode().ToString();
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

    #endregion

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      Citation = new Citation(ActionFactory.Build(ActionFactory.ActionType.Music));
      Container = ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, ActionFactory.Build(ActionFactory.ActionType.Music), Citation);
      Container.SystemShape = CreateRectangle(Colors.White, canvas.ActualHeight, canvas.ActualWidth);
      canvas.Children.Add(Container.SystemShape);
      dict.Add(Container.SystemShape, Container);
      SelectedShape = Container.SystemShape;
      SelectedShapeSize.Height = SelectedShape.Height;
      SelectedShapeSize.Width = SelectedShape.Width;
    }

    private DesginPatternCL.Models.Shapes.Shape GetModelFromShape(DesginPatternCL.Models.Shapes.Shape _Container, Shape shape)
    {
      if (shape.GetHashCode() == _Container.SystemShape.GetHashCode())
        return _Container;
      else if (_Container is DesginPatternCL.Models.Shapes.Rectangle)
        foreach (var s in ((DesginPatternCL.Models.Shapes.Rectangle)_Container).Shapes)
          return GetModelFromShape(s, shape);
      return null;
    }
  }
}
