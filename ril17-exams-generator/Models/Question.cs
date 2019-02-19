using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ril17ExamsGenerator.Models
{
    public abstract class Question
    {
        public int ID { set; get; }

        [Required]
        public string question { set; get; }
    }
}
