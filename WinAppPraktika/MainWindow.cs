using System;
using System.Windows.Forms;

namespace WinAppPraktika
{
    public partial class MainWindow : Form
    {// vruzka s db i loggedUser proverka
        private loginForm _login;
        public string _roleName;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(loginForm login, string roleName)
        {
            //
            InitializeComponent();
            _login = login;
            _roleName = roleName;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {   //skriva nqkoi butoni ako lognatiqt user ne e admin
            if (_roleName != "admin")
            {
                tsManageTasks.Visible = false;
                tsManageUsers.Visible = false;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }
        // izprashtane kum formata za users
        private void tsManageUsers_Click(object sender, EventArgs e)
        {
            var manageUsers = new ManageUsers();
            manageUsers.MdiParent = this;
            manageUsers.Show();
        }
        //izprashtane kum formata za tasks
        private void tsManageTasks_Click(object sender, EventArgs e)
        {
            var manageTasks = new ManageTasks();
            manageTasks.MdiParent = this;
            manageTasks.Show();
        }

        //Tasks onclick
        private void timerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var showTask = new TaskWindow();
            showTask.MdiParent = this;
            showTask.Show();
        }
    }
}
