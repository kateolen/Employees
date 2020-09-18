using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ExerciseEmployeesApp
{
    public class DbHandler
    {
        private string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Employee> GetEmployees()

        {
            List<Employee> employees = new List<Employee>();


            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetEmployees", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee();
                            emp.DepartmentName = reader["DepartmentName"].ToString();
                            emp.Name = reader["Name"].ToString();
                            emp.Job = reader["Job"].ToString();
                            emp.Location = reader["Location"].ToString();
                            emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                            emp.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                            emp.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                            emp.ProjectName = reader["ProjectName"].ToString();
                            employees.Add(emp);
                        }
                    }

                }
            }

            return employees;
        }

        internal void SaveEmployee(Employee employees)
        {
            string[] nameArray = employees.Name.Split(' ');
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AddEmployee", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@FirstName", nameArray[0]);
                    cmd.Parameters.AddWithValue("@LastName", nameArray[1]);
                    cmd.Parameters.AddWithValue("@DepartmentId", employees.DepartmentId);
                    cmd.Parameters.AddWithValue("@ProjectId", employees.ProjectId);
                    cmd.Parameters.AddWithValue("@Job", employees.Job);
                    cmd.Parameters.AddWithValue("@EmployeeId", employees.EmployeeId).Direction = System.Data.ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            string[] nameArray = employee.Name.Split(' ');
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@FirstName", nameArray[0]);
                    cmd.Parameters.AddWithValue("@LastName", nameArray[1]);
                    cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                    cmd.Parameters.AddWithValue("@ProjectId", employee.ProjectId);
                    cmd.Parameters.AddWithValue("@Job", employee.Job);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Department> GetDepartments()

        {
            List<Department> departments = new List<Department>();


            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDepartments", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Department dept = new Department();
                            dept.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                            dept.DepartmentName = reader["DepartmentName"].ToString();
                            departments.Add(dept);
                        }
                    }

                }
            }

            return departments;
        }

        public List<Project> GetProjects()

        {
            List<Project> projects = new List<Project>();


            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetProjects", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Project project = new Project();
                            project.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                            project.ProjectName = reader["ProjectName"].ToString();
                            projects.Add(project);

                        }
                    }

                }
            }

            return projects;
        }
    }
}
