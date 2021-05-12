using System;
using System.Threading;
using System.Windows.Forms;

using TaintedCainApp.Util;

namespace TaintedCainApp.UI
{
    public partial class MainMenu : Form
    {
        private enum State
        {
            InitialState,
            UpdatingDataState,
            LoadingDataState,
            ReadyState
        }

        private State state;
        private int numberOfItems;

        public MainMenu()
        {
            state = State.InitialState;
            numberOfItems = 0;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void updateDataButton_Click(object sender, EventArgs e)
        {
            state = State.UpdatingDataState;
            DataUpdater.GenerateItemsFromWiki();
            DataUpdater.GeneratePickupImages();
            state = State.InitialState;
        }

        private void launchApplication_Click(object sender, EventArgs e)
        {
            numberOfItems = ItemManager.GetTotalNumberOfItems();
            if(numberOfItems == 0)
            {
                MessageBox.Show("No items to load. Update data first.");
                return;
            }

            state = State.LoadingDataState;
            Thread displayThread = new Thread(new ThreadStart(DisplayLoadingState));
            displayThread.Start();
            try
            {
                ItemManager.ReadItemsFromFile();
            } catch(Exception)
            {
                MessageBox.Show("An internal error occured. Try reloading data or post a message on GitHub.");
                return;
            }
            state = State.ReadyState;
            MainAppWindow mainWindow = new MainAppWindow(this);
            mainWindow.Show();
            this.Hide();
        }

        private void DisplayLoadingState()
        {
            while(state == State.LoadingDataState)
            {
                Thread.Sleep(150);
                UpdateLabel("Items loaded : " +
                    ItemManager.GetCurrentNumberOfItems().ToString() +
                    "/" +
                    numberOfItems.ToString());
            }
        }

        private void UpdateLabel(String newText)
        {
            if (this.loadedItems.InvokeRequired)
            {
                this.loadedItems.BeginInvoke((MethodInvoker)delegate () { this.loadedItems.Text = newText; ; });
            }
            else
            {
                this.loadedItems.Text = newText; ;
            }
        }
    }
}
