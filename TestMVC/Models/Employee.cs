using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Key]
    [Required(ErrorMessage = "Employee Code is required")]
    [StringLength(10, ErrorMessage = "Employee Code cannot exceed 10 characters")]
    [Display(Name = "Employee Code")]
    public string EmployeeCode { get; set; }

    [Required]
    [Display(Name = "Employee Name")]
    public string EmployeeName { get; set; }

    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; } // 👈 Make it nullable

    [Display(Name = "Gender")]
    public bool? Gender { get; set; } // 👈 Make it nullable

    [Display(Name = "Department")]
    public string Department { get; set; }

    [Display(Name = "Designation")]
    public string Designation { get; set; }

    [Display(Name = "Salary")]
    [Range(1, float.MaxValue, ErrorMessage = "Salary must be greater than 0")]
    public float? BasicSalary { get; set; } // 👈 Make it nullable
}
