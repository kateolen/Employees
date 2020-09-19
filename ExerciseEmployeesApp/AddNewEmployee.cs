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
    public partial class AddNewEmployee : Form
    {
        private DbHandler db;
        private Employee emp;

        public AddNewEmployee()
        {
            InitializeComponent();
            db = new DbHandler();
            emp = new Employee();

        }

        private void btnSaveNewEmployee_Click(object sender, EventArgs e)
        {
            Employee employees = new Employee();
            employees.Name = txtFirstName.Text + " " + txtLastName.Text;
            employees.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
            employees.ProjectId = Convert.ToInt32(cmbDepartment.SelectedValue);
            employees.Job = txtJob.Text;
            db.SaveEmployee(employees);

            MessageBox.Show("New Employee Was Saved Succesfully!");
            this.Close();


        }

        private void AddNewEmployee_Load(object sender, EventArgs e)
        {
            txtFirstName.Select();
            List<Project> projects = db.GetProjects();
            cmbProject.DisplayMember = "ProjectName";
            cmbProject.ValueMember = "ProjectId";
            cmbProject.DataSource = projects;
            cmbProject.SelectedValue = emp.ProjectId;

            List<Department> dept = db.GetDepartments();
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentId";
            cmbDepartment.DataSource = dept;
            cmbDepartment.SelectedValue = emp.DepartmentId;

        }

        private void AddNewEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
    }
}
