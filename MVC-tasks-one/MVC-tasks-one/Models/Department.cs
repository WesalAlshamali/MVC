using MVC_tasks_one.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcv_task1.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [MaxLength(100, ErrorMessage = "Department name cannot exceed 100 characters")]
        [Required(ErrorMessage = "Department name is required")]
        public string DepartmentName { get; set; }

        public int NumberOfEmployees { get; set; }

        [MaxLength(255, ErrorMessage = "Location cannot exceed 255 characters")]
        public string Location { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Employees> Employees { get; set; }
        public Managers Manager { get; set; }


    }
}
