using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Entities;

public class Todo
{
    public Todo(string title, string comments)
    {
        Title = title;
        Comments = comments;
    }

    [Key] // Define esta propriedade como a chave primária
    public int Id { get; set; }

    public string Title { get; set; }
    public string Comments { get; set; }
}