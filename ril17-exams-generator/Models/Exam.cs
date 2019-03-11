using Microsoft.AspNetCore.Identity;
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
        public string name { get; set; }

        [Required]
        public int duree { get; set; }

        public int nombre { get; set; }
        [Required]
        public int nombreQuestion { get; set; }

        [Required]
        public List<Question> questions { get; set; }

 }
}
