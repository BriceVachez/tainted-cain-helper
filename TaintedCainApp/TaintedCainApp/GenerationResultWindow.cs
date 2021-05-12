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

            resultPanel = new ResultPanel(root);
            resultPanel.Location = new Point(20, 12);
            resultPanel.Name = "resultPanel";
            resultPanel.Size = new Size(500, 208);
            resultPanel.TabIndex = 0;
            resultPanel.AutoScroll = true;
            Controls.Add(resultPanel);

            UpdatePageLabel();
            ChangeButtonState();
        }

        private void GenerationResultWindow_Load(object sender, EventArgs e)
        {

        }

        private void firstPage_Click(object sender, EventArgs e)
        {
            resultPanel.FirstPage();
            UpdatePageLabel();
            ChangeButtonState();
        }

        private void previousPage_Click(object sender, EventArgs e)
        {
            resultPanel.PreviousPage();
            UpdatePageLabel();
            ChangeButtonState();
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            resultPanel.NextPage();
            UpdatePageLabel();
            ChangeButtonState();
        }

        private void lastPage_Click(object sender, EventArgs e)
        {
            resultPanel.LastPage();
            UpdatePageLabel();
            ChangeButtonState();
        }

        private void UpdatePageLabel()
        {
            int page = resultPanel.CurrentPage + 1;
            int maxPage = resultPanel.MaxPage + 1;
            pageLabel.Text = "Page " +
                page.ToString() +
                "/" +
                maxPage.ToString();
        }

        private void ChangeButtonState()
        {
            Tuple<bool, bool> buttonStates = resultPanel.GetButtonActivationState();
            firstPage.Enabled = buttonStates.Item1;
            previousPage.Enabled = buttonStates.Item1;
            nextPage.Enabled = buttonStates.Item2;
            lastPage.Enabled = buttonStates.Item2;
        }
    }
}
