using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ril17ExamsGenerator.Models
{
    public class Exam
    {
        /*public Exam(string name, string nombre, string duree)
        {
            this.name = name;
            this.nombre = int.Parse(nombre);
            this.duree = int.Parse(duree);
        }*/
        public int ID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int duree { get; set; }

        [Required]
        public int nombreQuestion { get; set; }

        [Required]
        public List<Question> questions { get; set; }

        //public List<User> users { get; set; }
 }
}
