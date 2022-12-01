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
    public partial class AddEditUser : Form
    {   // proverka ako e editmode
        private bool isEditMode;
        private readonly WinAppEntities _db;
        public AddEditUser()
        {   //dobavqne na nov zashtoto ne poluchava user
            InitializeComponent();
            labelTitle.Text = "Add new User";
            isEditMode = false;
            _db = new WinAppEntities();
        }

        // redaktirane na izbran user  zashtoto poluchava sushtestvuvasht user
        public AddEditUser(User userToEdit)
        {
            InitializeComponent();
            labelTitle.Text = "Edit existing User";
            isEditMode = true;
            _db = new WinAppEntities();
            PopulateFields(userToEdit);
        }
        // izpulvane na formata s tochno izbran user
        public void PopulateFields(User user)
        {
            labelid.Text = user.id.ToString();
            textBox1.Text = user.username;
            textBox2.Text = user.password;
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //ako e v rejim na editvane 
            if (isEditMode)
            {
                var id = int.Parse(labelid.Text);
                var user = _db.Users.FirstOrDefault(q => q.id == id);
                user.username = textBox1.Text;
                user.password = textBox2.Text;
                //prosto updeitva polucheniq user
                _db.SaveChanges();
                MessageBox.Show("Please close the window and refresh the listing");
            }
            //ako !rejim na editvane
            else
            {
                //suzdavane na nov obekt
                var newUser = new User
                {
                    username = textBox1.Text,
                    password = textBox2.Text
                };
                // dobavqne na noviq obekt kum BD
                _db.Users.Add(newUser);
                _db.SaveChanges();
                MessageBox.Show("Please close the window and refresh the listing");
            }
        }
    }
}
