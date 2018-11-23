using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class txtItem : Form
    {
        Dictionary<int, string> test = new Dictionary<int, string>();
        PriorityQueue queue = new PriorityQueue();
        enum priority {Low = 1, Normal = 2, High = 3, Critical = 4};

        public txtItem()
        {
            InitializeComponent();
            test.Add(1, "Low");
            test.Add(2, "Normal");
            test.Add(3, "High");
            test.Add(4, "Critical");
            cbPriority.DataSource = new BindingSource(test, null);
            cbPriority.DisplayMember = "Value";
            cbPriority.ValueMember = "Key";


            btnComplete.Visible = false;
            lblNext.Text = "Nothing to do!";
            cbPriority.SelectedIndex = 1;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbPriority.SelectedIndex = 1;
            txtTodo.Clear();
        }



        private void btnClearScedule_Click(object sender, EventArgs e)
        {
            queue.Clear();
            showNext();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtTodo.Text.ToString();
            int priority = ((KeyValuePair<int, string>)cbPriority.SelectedItem).Key;
            ToDo todo = new ToDo(name, priority);
            queue.Enqueue(todo);
            showNext();
            btnReset_Click(null, null);
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            queue.Dequeue();
            showNext();
        }

        private void showNext()
        {
            if (queue.Count != 0)
            {
                lblNext.Text = "Task: "+ queue.Peek().Task;
                lblPriority.Text ="Priority: "+ ((priority)queue.Peek().Priority).ToString();
                btnComplete.Visible = true;
            }
            else
            {
                btnComplete.Visible = false;
                lblNext.Text = "Nothing to do!";
                lblPriority.Text = "";
            }

            UpdateStats();
        }

        private void UpdateStats()
        {
            List<KeyValuePair<string, int>> stats = queue.Statistics();
            lblCritical.Text = stats.First(kvp => kvp.Key == "Critical").Value.ToString();
            lblHigh.Text = stats.First(kvp => kvp.Key == "High").Value.ToString();
            lblNormal.Text = stats.First(kvp => kvp.Key == "Normal").Value.ToString();
            lblLow.Text = stats.First(kvp => kvp.Key == "Low").Value.ToString();
            lblTotal.Text = stats.First(kvp => kvp.Key == "Total").Value.ToString();



        }
    }
}
