using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ril17ExamsGenerator.Models
{
    public enum QuestionType
    {
        M, U, Y
    }
    public class Question
    {
        public int ID { set; get; }

        [Required]
        public string question { set; get; }

        [Required]
        public List<Response> responses { set; get; }

        [Required]
        public QuestionType type { set; get; }

    }
}
