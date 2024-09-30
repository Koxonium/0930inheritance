using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0930inheritance
{
    public partial class Form1 : Form
    {
        databaseHandler db;
        public Form1()
        {
            InitializeComponent();
            db = new databaseHandler();
            db.readAll();
            Car oneCar = new Car();
            oneCar.color = "piros";
            oneCar.hp = 500;
            oneCar.make = "VW";
            oneCar.model = "Bogár";
            oneCar.year = 1973;
            db.addOne(oneCar);
        }
    }
}
