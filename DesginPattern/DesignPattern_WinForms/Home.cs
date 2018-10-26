using DesginPattern_TP1.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DesginPattern_TP1.Models.ShapeFactory;

namespace DesignPattern_WinForms
{
    public partial class Home : Form
    {
         
        public Home()
        {
            InitializeComponent();
            List<ShapeType> shapes = Enum.GetValues(typeof(ShapeType)).Cast<ShapeType>().ToList();
        }
    }
}
