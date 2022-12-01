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
    public partial class AddEditTask : Form
    {

        private bool isEditMode;
        private readonly WinAppEntities _db;


        // ako addedittask ne poluchi obekt task
        public AddEditTask()
        {
            InitializeComponent();
            labelTitle.Text = "Add new Task";
            isEditMode = false;
            _db = new WinAppEntities();
        }
        // ako poluchi obekt task
        public AddEditTask(Task taskToEdit)
        {
            InitializeComponent();
            labelTitle.Text = "Edit existing Task";
            isEditMode = true;
            _db = new WinAppEntities();
            //izpulva formata s dannite na  podadeniq task
            PopulateFields(taskToEdit);
        }
        //zaqvka za bd // Select tochno opredeleniq task
        private void PopulateFields(Task task)
        {
            labelId.Text = task.id.ToString();
            textBox1.Text = task.name;
            textBox2.Text = task.timer;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //save button
        private void button1_Click(object sender, EventArgs e)
        {

            // ako e v rejim na editvane
            if (isEditMode)
            {
                //vzima id-to na opredeleniq task
                var id = int.Parse(labelId.Text);
                var task = _db.Tasks.FirstOrDefault(q => q.id == id);
                //updeitva dannite s novovuvedenite
                task.name = textBox1.Text;
                task.timer = textBox2.Text;
                //zapis v bd
                _db.SaveChanges();
                MessageBox.Show("Please close the window and refresh the listing");
            }
            //ako e v rejim !edit toest dobavqne na novb
            else {
                //suzdava nov obekt task
                var newTask = new Task
                {
                    name = textBox1.Text,
                    timer = textBox2.Text
                };
                //dobavq noviq obekt kum BD
                _db.Tasks.Add(newTask);
                //zapis
                _db.SaveChanges();
                MessageBox.Show("Please close the window and refresh the listing");
            }
        }

        private void AddEditTask_Load(object sender, EventArgs e)
        {

        }
    }
}
