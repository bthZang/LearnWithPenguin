using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWithPenguin.Models
{
    public class Answer
    {
        public int Index { get; set; }
        public string Text { get; set; }
        public bool CorrectAnswer { get; set; }
        public bool SelectedAnswer { get; set; }

        public Answer(int index, string text, bool correct, bool selected)
        {
            Index = index;
            Text = text;
            CorrectAnswer = correct;
            SelectedAnswer = selected;
        }
    }
}
