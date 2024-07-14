using MVC_tasks_one.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Feedbacks
{
    [Key]
    public int FeedbackID { get; set; }

    [Required]
    [StringLength(255)]
    public string Title { get; set; }

    [Required]
    [ForeignKey("Manager")]
    public int ManagerID { get; set; }

    public bool Viewed { get; set; } = false;

    public string Message { get; set; }

    public DateTime? Date { get; set; }

    public Managers Manager { get; set; }
}
