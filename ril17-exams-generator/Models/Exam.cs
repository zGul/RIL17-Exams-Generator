using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ril17ExamsGenerator.Models
{
    public class Exam
    {
        public int ID { get; set; }

        [Required]
        private string name { get; set; }

        [Required]
        private int duree { get; set; }

        [Required]
        public List<Question> questions { get; set; }

        //public List<User> users { get; set; }
 }
}
