using System.ComponentModel.DataAnnotations;

public class Todo
{
  [Required]
  public string Libelle { get; set; }
  public string Description { get; set; }
  [Required]
  public State State { get; set; }
  [Required]
  public DateTime DateLimit { get; set; }
}