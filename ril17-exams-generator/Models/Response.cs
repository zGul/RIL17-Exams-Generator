using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ril17ExamsGenerator.Models
{
    public class Response
    {
        public int ID { set; get; }

        [Required]
        public string response { get; set; }

        [Required] 
        public bool isCorrect { get; set; }

        [Required]
        public Question question { get; set; }
    }
}
