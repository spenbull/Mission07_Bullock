using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mission06_Bullock.Models;

using System.ComponentModel.DataAnnotations;

public class Application
{
    [Key]
    [Required]
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Year is required.")]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1888.")]
    public int Year { get; set; }

    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category Category { get; set; }

    public string? Director { get; set; }
    public string? Rating { get; set; }

    [Required(ErrorMessage = "Edited status is required.")]
    public bool Edited { get; set; }

    public string? LentTo { get; set; }

    [Required(ErrorMessage = "CopiedToPlex status is required.")]
    public bool CopiedToPlex { get; set; }

    public string? Notes { get; set; }
}

