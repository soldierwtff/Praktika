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
    public partial class ManageUsers : Form
    {
        // връзка с базата данни
        private readonly WinAppEntities _db;
        public ManageUsers()
        {
            InitializeComponent();
            _db = new WinAppEntities();
        }
        // данни за gridview
        public void PopulateGrid()
        {//ekvivalent na SELECT* from users
            var users = _db.Users.Select(q => new
            {
                username = q.username,
                password = q.password,
                q.id
            }).ToList();
            gvUsers.DataSource = users;
            gvUsers.Columns["id"].Visible = false;
        }

        //
        private void ManageUsers_Load(object sender, EventArgs e)
        {
            var users = _db.Users.Select(q => new
            {
                username = q.username,
                password = q.password,
                q.id
            }).ToList();
            gvUsers.DataSource = users;
            gvUsers.Columns[2].Visible = false;

        }
        // dobavqne nov zapis
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // suzdava prazen user i go izprashta kum sledvashtata forma
            var addEditUser = new AddEditUser();
            addEditUser.MdiParent = this.MdiParent;
            addEditUser.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //vzima id na selektiraniq user i go izprashta na sledvashtata forma s vuvedeni danni
            var id = (int)gvUsers.SelectedRows[0].Cells["id"].Value;
            var user = _db.Users.FirstOrDefault(q => q.id == id);
            var addEditUser = new AddEditUser(user);

            addEditUser.MdiParent = this.MdiParent;
            addEditUser.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //refreshvane na dannite
            PopulateGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //vzima id na selektiraniq red
            var id = (int)gvUsers.SelectedRows[0].Cells["id"].Value;
            var user = _db.Users.FirstOrDefault(q => q.id == id);

            //delete user ot db
            _db.Users.Remove(user);
            _db.SaveChanges();
            MessageBox.Show("Please refresh listing to see changes");
            gvUsers.Refresh();
        }
    }
}
