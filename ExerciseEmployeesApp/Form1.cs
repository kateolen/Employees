using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciseEmployeesApp
{
    public partial class Form1 : Form
    {
        DbHandler db;
        public Form1()
        {
            InitializeComponent();
            db = new DbHandler();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
               
                List<Employee> employees = db.GetEmployees();
                LoadEmployeesList(employees);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, DisplayErrorLog);
            }
           
        }

        public void DisplayErrorLog()
        {
            MessageBox.Show("Something went wrong!");
        }

        public void LoadEmployeesList(List<Employee> employees)
        {
            lstEmployees.DisplayMember = "EmployeeInfo";
            lstEmployees.ValueMember = "EmployeeId";
            lstEmployees.DataSource = employees;
        }

        private void lstEmployees_Click(object sender, EventArgs e)
        {
            /* Downcast */
            ListBox list = sender as ListBox;
            Employee selectedEmployee = (Employee)list.SelectedItem;
            this.Hide();
            UpdateEmployeeForm form = new UpdateEmployeeForm(selectedEmployee);
            form.FormClosed += (s, args) => {
                List<Employee> employees = db.GetEmployees();
                LoadEmployeesList(employees);
                this.Show();
            };
            form.Show();
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNewEmployee addNewEmployee = new AddNewEmployee();
            addNewEmployee.Show();
        }
    }
}
