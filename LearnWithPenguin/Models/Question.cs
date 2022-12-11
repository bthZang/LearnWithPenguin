using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWithPenguin.Models
{
    public class Question
    {
        public int ID { get; set; }
        public int DBID { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> AnswerList { get; set; }
        public string PathToImage { get; set; }

        public Question(int id, string questionText, string answers1, string answers2, string answers3, string answers4, byte? correntAnswer)
        {
            ID = id;
            QuestionText = CleanUpQuestion(questionText);
            AnswerList = new List<Answer>();
            AnswerList.Add(new Answer(0, answers1, false, false));
            AnswerList.Add(new Answer(1, answers2, false, false));
            AnswerList.Add(new Answer(2, answers3, false, false));
            AnswerList.Add(new Answer(3, answers4, false, false));
            foreach (Answer a in AnswerList)
            {
                if (a.Index == (int)correntAnswer - 1)
                {
                    a.CorrectAnswer = true;
                }
            }
        }
        string CleanUpQuestion(string questionText)
        {
            if (questionText.Contains("\\Within\\"))
            {
                string[] splitQuestion = questionText.Split('{');
                string lastPart = splitQuestion.Last().Replace("}", "");
                string[] temp = lastPart.Split('\\');
                lastPart = temp.Last();
                PathToImage = "images/Within/" + lastPart;
                return splitQuestion.First();
            }
            else
                return questionText;
        }
        public void AnswerClicked(int index)
        {
            foreach (Answer answer in AnswerList)
                if (answer.Index != index)
                    answer.SelectedAnswer = false;
                else
                    answer.SelectedAnswer = true;
        }

        public bool Solve()
        {
            bool correct = false;
            foreach (Answer answer in AnswerList)
                if (answer.CorrectAnswer && answer.SelectedAnswer)
                    correct = true;

            foreach (Answer answer in AnswerList)
                Trace.WriteLine("answer.SelectedAnswer = " + answer.SelectedAnswer + ", answer.CorrectAnswer = " + answer.CorrectAnswer);

            Trace.WriteLine("correct = " + correct);
            return correct;
        }
    }
}


