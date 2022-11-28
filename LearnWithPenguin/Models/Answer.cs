using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWithPenguin.Models
{
    internal class Answer
    {
        public int index { get; set; }
        public string text { get; set; }
        public bool correctAnswer { get; set; }
        public bool selectedAnswer { get; set; }

        public Answer(int index, string text, bool correctAnswer, bool selectedAnswer)
        {
            this.index = index;
            this.text = text;
            this.correctAnswer = correctAnswer;
            this.selectedAnswer = selectedAnswer;
        }
    }
}
