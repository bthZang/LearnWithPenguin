using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWithPenguin.Models
{
    public class WrongAnswer
    {
        public string Question { get; set; }
        public string SelectedAnswer {  get; set; }
        public string RightAnswer { get; set; }

        public WrongAnswer()
        {
            Question = "";
            SelectedAnswer = "";
            RightAnswer = "";
        }

        public WrongAnswer(string question, string selectedAnswer, string rightAnswer)
        {
            Question = question;
            SelectedAnswer = selectedAnswer;
            RightAnswer = rightAnswer;
        }
    }
}
