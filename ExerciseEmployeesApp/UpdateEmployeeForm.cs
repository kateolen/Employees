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
    public partial class UpdateEmployeeForm : Form
    {
        private Employee emp;
        private DbHandler db;


        public UpdateEmployeeForm(Employee employee)
        {
            InitializeComponent();
            db = new DbHandler();
            txtEmployeeId.Text = employee.EmployeeId.ToString();
            txtName.Text = employee.Name;
            txtJob.Text = employee.Job;
            emp = employee;
          
     
        }

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {

            Employee employee = new Employee();
            employee.Name = txtName.Text;
            employee.EmployeeId = Convert.ToInt32(txtEmployeeId.Text);
            employee.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
            employee.Job = txtJob.Text;
            employee.ProjectId = emp.ProjectId;

            db.UpdateEmployee(employee);

            MessageBox.Show("Data was saved succesfully");
            this.Close();




        }


        private void UpdateEmployeeForm_Load(object sender, EventArgs e)
        {
            
            List<Department> dept = db.GetDepartments();
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentId";
            cmbDepartment.DataSource = dept;
            cmbDepartment.SelectedValue = emp.DepartmentId;

        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            db.DeleteEmployee(emp.EmployeeId);
            MessageBox.Show("Deleted Succesfully");
            this.Close();
        }
    }
}
