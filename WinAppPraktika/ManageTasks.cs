using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppPraktika
{
    public partial class ManageTasks : Form
    {
        // vruzka za BD
        private readonly WinAppEntities _db;

        public ManageTasks()
        {
            InitializeComponent();
            // nova vruzka
            _db = new WinAppEntities();
        }
        //izpulvane na gridview
        public void PopulateGrid()
        {
            var tasks = _db.Tasks.Select(q => new
            {
                name = q.name,
                timer = q.timer,
                q.id
            }).ToList();

            gvTasks.DataSource = tasks;
            gvTasks.Columns["id"].Visible = false;
        }
        //zarejdane na formata i gridview
        private void ManageTasks_Load(object sender, EventArgs e)
        {
            var tasks = _db.Tasks.Select(q => new
            {
                name = q.name,
                timer = q.timer,
                q.id
            }).ToList();
            gvTasks.DataSource = tasks;
            gvTasks.Columns[2].Visible = false;
        }

        private void gvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //delete button
        private void button3_Click(object sender, EventArgs e)
        {
            //vzima id na selektiraniq red
            var id = (int)gvTasks.SelectedRows[0].Cells["id"].Value;
            var task = _db.Tasks.FirstOrDefault(q => q.id == id);

            //delete task ot db
            _db.Tasks.Remove(task);
            _db.SaveChanges();
            MessageBox.Show("Please refresh listing to see changes");
            gvTasks.Refresh();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // dobavq prazen task i go izprashta na sledvashtata forma za vuvejdane
            var addEditTask = new AddEditTask();
            addEditTask.MdiParent = this.MdiParent;
            addEditTask.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //vzema id na izbraniq element i pravi casting kum int  za izpulnqvane na zaqvkata
            var id = (int)gvTasks.SelectedRows[0].Cells["id"].Value;
            //zaqvka za bd
            var task = _db.Tasks.FirstOrDefault(q => q.id == id);
            //otvarq formata za edit s podadeni parametri
            var addEditTask = new AddEditTask(task);

            addEditTask.MdiParent = this.MdiParent;
            addEditTask.Show();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
