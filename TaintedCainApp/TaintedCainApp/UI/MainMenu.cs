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
            if(state == State.LoadingDataState)
            {
                Console.WriteLine("Loading data.");
                return;
            }
            state = State.UpdatingDataState;
            DataUpdater.GenerateItemsFromWiki();
            DataUpdater.GeneratePickupImages();
            state = State.InitialState;
        }

        private void launchApplication_Click(object sender, EventArgs e)
        {
            if(state == State.UpdatingDataState)
            {
                Console.WriteLine("Currently updating data.");
                return;
            }
            numberOfItems = ItemManager.GetTotalNumberOfItems();
            if(numberOfItems == 0)
            {
                Console.WriteLine("No items found.");
                return;
            }

            state = State.LoadingDataState;
            Thread displayThread = new Thread(new ThreadStart(DisplayLoadingState));
            displayThread.Start();
            ItemManager.ReadItemsFromFile();
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
