using System;

namespace ExerciseEmployeesApp
{
    public class Employee 
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public string Job { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public string EmployeeInfo
        {
            get
            {
                return $"{Name} - {DepartmentName} - {Location} - {Job}";
            }
        }
    }
}