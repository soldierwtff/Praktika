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
    public partial class loginForm : Form
    {
        //osushtestvqva vruzka s db
        private readonly WinAppEntities _db;
        public loginForm()
        {
            InitializeComponent();
            _db = new WinAppEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var username = textBox1.Text;
                var password = textBox2.Text;

                var user = _db.Users.FirstOrDefault(q => q.username == username && q.password == password);
                if(user==null)
                {
                    MessageBox.Show("Please provide valid credentials");
                }
                else
                {
                    var role = user.UserRoles.FirstOrDefault();
                    var roleName = role.Role.name;
                    var MainWindow = new MainWindow(this, roleName);
                    MainWindow.Show();
                    this.Hide();
                    MessageBox.Show($"Successful login, {user.username} {roleName}");
                }
            }
            catch  (Exception)
            {
                MessageBox.Show("Something went wrong please try again!");
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
