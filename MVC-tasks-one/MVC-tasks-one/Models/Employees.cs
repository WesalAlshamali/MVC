
using mcv_task1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employees
{
    [Key]
    public int EmployeeId { get; set; }

    [MaxLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    [MaxLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }

    [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
    public string PhoneNumber { get; set; }

    [MaxLength(100, ErrorMessage = "Job title cannot exceed 100 characters")]
    [Required(ErrorMessage = "Job title is required")]
    public string JobTitle { get; set; }

    public decimal Salary { get; set; }

    [MaxLength(255, ErrorMessage = "Address cannot exceed 255 characters")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Department ID is required")]
    public int DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }
}

