namespace EmployeeForm.Models
{
    public class EmployeeViewModel
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public float BasicSalary { get; set; }
        public float DearnessAllowance { get; set; }
        public float ConveyanceAllowance { get; set; }
        public float HouseRentAllowance { get; set; }
        public float PT { get; set; }
        public float TotalSalary { get; set; }
    }
}
