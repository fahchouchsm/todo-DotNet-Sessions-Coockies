using System.ComponentModel.DataAnnotations;

namespace todoV2.ViewModels
{
    public class TodoAddVm
    {
        [Required]
        public string Libelle { get; set; }
        public string? Description { get; set; }
        [Required]
        public State State { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime DateLimit { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime AddedTime { get; set; } = DateTime.Now;
    }
}
