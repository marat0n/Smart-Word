using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWord
{
    public partial class FormInfo : Form
    {
        List<dynamic> workElems = new List<dynamic>();

        public FormInfo()
        {
            InitializeComponent();
        }

        void buttonM_Click(object sender, EventArgs e) // M - main functions
        {
            panel.Location = new Point(0, buttonM.Height + 1);
        }

        void buttonO_Click(object sender, EventArgs e) // O - other functions
        {
            panel.Location = new Point(buttonM.Width, buttonO.Height + 1);
        }

        void mainFunctions()
        {
            
        }

        void otherFunctions()
        {

        }
    }
}
