using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tasks
{
    [Key]
    public int TaskID { get; set; }

    [Required]
    [StringLength(255)]
    public string Title { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }

    [Required]
    [StringLength(50)]
    public string LevelOfImportance { get; set; }

    [Required]
    [ForeignKey("AssignedEmployee")]
    public int AssignedEmployeeID { get; set; }

    public Employees AssignedEmployee { get; set; }
}
