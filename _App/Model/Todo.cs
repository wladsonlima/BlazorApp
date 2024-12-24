using System.ComponentModel.DataAnnotations;

namespace _App.Model;

public class Todo
{
    [Required] public string? Title { get; set; }

    [Required] public string? Comments { get; set; }
}