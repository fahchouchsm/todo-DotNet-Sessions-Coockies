using System.ComponentModel.DataAnnotations;

namespace todoV2.data
{
    public class Todo
    {
        public int id { get; set; } = 0;
        public string Libelle { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public DateTime DateLimit { get; set; }
        public DateTime AddedTime { get; set; } = DateTime.Now;
    }
}
