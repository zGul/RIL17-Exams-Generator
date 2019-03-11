using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ril17ExamsGenerator.Models
{
    public class Exam
    {
<<<<<<< HEAD
=======
        /*public Exam(string name, string nombre, string duree)
        {
            this.name = name;
            this.nombre = int.Parse(nombre);
            this.duree = int.Parse(duree);
        }*/
>>>>>>> a4de1205b264d6be37970faf149167c357dbc948
        public int ID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int duree { get; set; }

<<<<<<< HEAD
        public int nombre { get; set; }
=======
        [Required]
        private int nombreQuestion { get; set; }

>>>>>>> a4de1205b264d6be37970faf149167c357dbc948
        [Required]
        public List<Question> questions { get; set; }

        //public List<User> users { get; set; }
 }
}
