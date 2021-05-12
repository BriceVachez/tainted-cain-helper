using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaintedCainApp
{
    public partial class GenerationResultWindow : Form
    {
        private ItemNode root;
        public GenerationResultWindow(ItemNode _root)
        {
            root = _root;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            InitializeComponent();
        }

        private void GenerationResultWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
