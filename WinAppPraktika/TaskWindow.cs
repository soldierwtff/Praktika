using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WinAppPraktika
{
    public partial class TaskWindow : Form
    {//vruzka s baza danni
        private readonly WinAppEntities _db;
        System.Timers.Timer t;
        int h, m, s;
        public TaskWindow()
        {
            InitializeComponent();
            _db = new WinAppEntities();
        }
        // pokazvane na zapisite na tasks ot baza danni
        public void PopulateGrid()
        {
            var tasks = _db.Tasks.Select(q => new
            {
                name = q.name,
                timer = q.timer,
                q.id
            }).ToList();
            //napulva gridview s gorevzetite tasks
            gvTasks.DataSource = tasks;
            //skriva id kolonata 
            gvTasks.Columns["id"].Visible = false;
        }
        //start na otchitane na vreme
        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();
        }
        // pauza na otchitane na vreme
        private void button2_Click(object sender, EventArgs e)
        {
            t.Stop();
        }
        // pri zatvarqne na prozoreca da spre otchitaneto i ne pravi zapis
        private void TaskWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
        }


        // izbirane na dadena zadacha vurhu koqto da se raboti
        private void btnChoose_Click(object sender, EventArgs e)
        {
            var id = (int)gvTasks.SelectedRows[0].Cells["id"].Value;
            var task = _db.Tasks.FirstOrDefault(q => q.id == id);
            // vzima vremeto ot baza danni i go prilaga na timera
            s = Int32.Parse(task.timer);
        }
        //pri izbor na buton za finish na zadachata da spre timera i da zapishe v BD
        private void btnfinish_Click(object sender, EventArgs e)
        {
            t.Stop();
            var id = (int)gvTasks.SelectedRows[0].Cells["id"].Value;
            var task = _db.Tasks.FirstOrDefault(q => q.id == id);
            task.timer = s.ToString();
            _db.SaveChanges();
            textBox1.Text = "";
        }
        //refresh na grid view
        private void button3_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        // inicializirane na cqlata forma  + zarejdane na timer i grid view
        private void TaskWindow_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;// 1 sekunda :D
            t.Elapsed += OnTimeEvents;

            var tasks = _db.Tasks.Select(q => new
            {
                name = q.name,
                timer = q.timer,
                q.id
            }).ToList();
            gvTasks.DataSource = tasks;
            gvTasks.Columns[2].Visible = false;
        }
        //Timer
        private void OnTimeEvents(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                // opit za prevrushtane na sekundite v minuti i chasove
               // if (s >= 60) { s = 0; m += 1; }
                //if (m >= 60) { m = 0; h += 1; }
                textBox1.Text = string.Format("{0}", s.ToString().PadLeft(2, '0'));
                //textBox1.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }));
        }
    }
}
