using DesignPatternCL.Actions;
using DesignPatternCL.Models;
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
    private DesignPatternCL.Models.Shapes.Shape head = ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, ActionFactory.Build(ActionFactory.ActionType.Noise), new Citation());
    private List<ShapeFactory.ShapeType> Shapes = new List<ShapeFactory.ShapeType>();
    private List<ActionFactory.ActionType> Actions = new List<ActionFactory.ActionType>();
    private Citation Citation;
    private DesignPatternCL.Models.Shapes.Shape Container;
    private Dictionary<Shape, Tuple<DesignPatternCL.Models.Shapes.Shape, DesignPatternCL.Models.Shapes.Shape>> dict = new Dictionary<Shape, Tuple<DesignPatternCL.Models.Shapes.Shape, DesignPatternCL.Models.Shapes.Shape>>();

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
      DesignPatternCL.Models.Shapes.Shape shape = null;
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
      if (s != null && s.Item2.GetType() == ShapeFactory.ShapeType.Rectangle)
      {
        ((DesignPatternCL.Models.Shapes.Rectangle)s.Item2).Shapes.Add(shape);
        canvas.Children.Add(shape.SystemShape);
        Details.Text = Container.Details();
        dict.Add(shape.SystemShape, new Tuple<DesignPatternCL.Models.Shapes.Shape, DesignPatternCL.Models.Shapes.Shape>(s.Item2, shape));
      }
      else
      {
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
      if (s != null && s.Item1 != null && s.Item2 != null)
      {
        removeChildren(s.Item2);
        ((DesignPatternCL.Models.Shapes.Rectangle)(s.Item1)).Remove(s.Item2);
      }
      Details.Text = Container.Details();
      SelectedShape = Container.SystemShape;
    }

    private void SetOnTopBtn_Click(object sender, RoutedEventArgs e)
    {
      canvas.Children.Remove(SelectedShape);
      canvas.Children.Add(SelectedShape);
    }

    private void Draw(DesignPatternCL.Models.Shapes.Shape container)
    {
      canvas.Children.Add(container.SystemShape);
      try
      {
        if (container.GetType() == ShapeFactory.ShapeType.Rectangle)
        {
          foreach (var shape in ((DesignPatternCL.Models.Shapes.Rectangle)container).Shapes)
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
        Width = SelectedShape != null ? SelectedShape.Width / 4 : size,
        Height = SelectedShape != null ? SelectedShape.Height / 4 : size,
        Fill = new SolidColorBrush(color),
        Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
        StrokeThickness = 3,
      };
      if (SelectedShape != null)
      {
        Canvas.SetLeft(rect, Canvas.GetLeft(SelectedShape) + 5);
        Canvas.SetTop(rect, Canvas.GetTop(SelectedShape) + 5);
      }
      enableDrag(rect);
      return rect;
    }

    Ellipse CreateEllipse(Color color)
    {
      int size = rand.Next(50) + 50;
      var ellipse = new Ellipse()
      {
        Width = SelectedShape != null ? SelectedShape.Height / 4 : size,
        Height = SelectedShape != null ? SelectedShape.Height / 4 : size,
        Fill = new SolidColorBrush(color),
        Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
        StrokeThickness = 3,
      };
      if (SelectedShape != null)
      {
        Canvas.SetLeft(ellipse, Canvas.GetLeft(SelectedShape) + 5);
        Canvas.SetTop(ellipse, Canvas.GetTop(SelectedShape) + 5);
      }
      enableDrag(ellipse);
      return ellipse;
    }

    Rectangle CreateSquare(Color color)
    {
      int size = rand.Next(50) + 50;
      var square = new Rectangle()
      {
        Width = SelectedShape != null ? SelectedShape.Width / 4 : size,
        Height = SelectedShape != null ? SelectedShape.Width / 4 : size,
        Fill = new SolidColorBrush(color),
        Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
        StrokeThickness = 3,
      };
      if (SelectedShape != null)
      {
        Canvas.SetLeft(square, Canvas.GetLeft(SelectedShape) + 5);
        Canvas.SetTop(square, Canvas.GetTop(SelectedShape) + 5);
      }
      enableDrag(square);
      return square;
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
        var p2 = e.GetPosition(canvas);
        var s = dict[(Shape)sender];
        var _x = p2.X - dragStart.Value.X;
        var _y = p2.Y - dragStart.Value.Y;
        if (s != null && s.Item2 != null)
        {
          Canvas.SetTop(s.Item2.SystemShape, _y);
          Canvas.SetLeft(s.Item2.SystemShape, _x);
          if (Canvas.GetLeft(s.Item2.SystemShape) < Canvas.GetLeft(s.Item1.SystemShape))
            Canvas.SetLeft(s.Item2.SystemShape, Canvas.GetLeft(s.Item1.SystemShape));
          else if (Canvas.GetLeft(s.Item2.SystemShape) > Canvas.GetLeft(s.Item1.SystemShape) + s.Item1.SystemShape.ActualWidth - ((Shape)sender).ActualWidth)
            Canvas.SetLeft(s.Item2.SystemShape, Canvas.GetLeft(s.Item1.SystemShape) + s.Item1.SystemShape.ActualWidth - ((Shape)sender).ActualWidth);

          if (Canvas.GetTop(s.Item2.SystemShape) < Canvas.GetTop(s.Item1.SystemShape))
            Canvas.SetTop(s.Item2.SystemShape, Canvas.GetTop(s.Item1.SystemShape));
          else if (Canvas.GetTop(s.Item2.SystemShape) > Canvas.GetTop(s.Item1.SystemShape) + s.Item1.SystemShape.ActualHeight - ((Shape)sender).ActualHeight)
            Canvas.SetTop(s.Item2.SystemShape, Canvas.GetTop(s.Item1.SystemShape) + s.Item1.SystemShape.ActualHeight - ((Shape)sender).ActualHeight);
        }
      }
    }

    #endregion

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      Citation = new Citation(ActionFactory.Build(ActionFactory.ActionType.Music));
      Container = ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, ActionFactory.Build(ActionFactory.ActionType.Music), Citation);
      Container.SystemShape = CreateRectangle(Colors.White, canvas.ActualHeight, canvas.ActualWidth);
      Container.SystemShape.Width = 3000;
      Container.SystemShape.Height = 2000;
      canvas.Children.Add(Container.SystemShape);
      dict.Add(Container.SystemShape, new Tuple<DesignPatternCL.Models.Shapes.Shape, DesignPatternCL.Models.Shapes.Shape>(null, Container));
      SelectedShape = Container.SystemShape;
      SelectedShapeSize.Height = SelectedShape.Height;
      SelectedShapeSize.Width = SelectedShape.Width;
    }

    private DesignPatternCL.Models.Shapes.Shape GetModelFromShape(DesignPatternCL.Models.Shapes.Shape _Container, Shape shape)
    {
      if (shape.GetHashCode() == _Container.SystemShape.GetHashCode())
        return _Container;
      else if (_Container is DesignPatternCL.Models.Shapes.Rectangle)
        foreach (var s in ((DesignPatternCL.Models.Shapes.Rectangle)_Container).Shapes)
          return GetModelFromShape(s, shape);
      return null;
    }

    private void removeChildren(DesignPatternCL.Models.Shapes.Shape _Container)
    {
      canvas.Children.Remove(_Container.SystemShape);
      if (_Container.GetType() == ShapeFactory.ShapeType.Rectangle)
        foreach (var rect in ((DesignPatternCL.Models.Shapes.Rectangle)_Container).Shapes)
          removeChildren(rect);
    }
  }
}
