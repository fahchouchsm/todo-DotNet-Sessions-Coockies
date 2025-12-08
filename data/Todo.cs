using System.ComponentModel.DataAnnotations;

namespace todoV2.data
{
    public class Todo
    {
        public string Libelle { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public DateTime DateLimit { get; set; }
    }
}
