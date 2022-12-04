using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LearnWithPenguin.Models
{
    public class Questionaire
    {
        private int answeredCorrectly;

        public int ID { get; set; }
        decimal Results { get; set; }
        public List<Question> Questions { get; set; }
        public string EvalMessage { get; set; }
        int[] questionIDs;
        int dbID;

        public int AnsweredCorrectly
        {
            get
            {
                answeredCorrectly = CountCorrect();
                return answeredCorrectly;
            }
            set
            {
                answeredCorrectly = CountCorrect();
            }
        }
        public Questionaire(int dbID, int id)
        {
            ID = id;
            this.dbID = dbID;
            Results = 0;
            Questions = new List<Question>();
            questionIDs = ShuffleIDs(DataReader.GetQuestionIds(dbID, id));
            foreach (int shuffledID in questionIDs)
                AddQuestion();
        }
        public Questionaire(int dbID, int id, int limit)
        {
            ID = id;
            this.dbID = dbID;
            Results = 0;
            Questions = new List<Question>();
            questionIDs = ShuffleIDs(DataReader.GetQuestionIds(dbID, id));
            List<int> limitedIDs = new List<int>();
            for (int i = 0; i < limit; i++)
            {
                limitedIDs.Add(questionIDs[i]);
            }
            questionIDs = limitedIDs.ToArray();
            foreach (int shuffledID in questionIDs)
                AddQuestion();
        }
        public int CountCorrect()
        {
            int i = 0;
            foreach (Question question in Questions)
                if (question.Solve())
                    i++;

            return i;
        }
        //public string EvaluateMessage(bool result)
        //{
        //    if (result)
        //        return "Xin chúc mừng, bạn đã vượt qua.";
        //    else
        //        return "Tiếc quá, bạn bị kẹt lại rồi.";
        //}
        int[] ShuffleIDs(int[] unshuffledQuestionIDs)
        {
            return unshuffledQuestionIDs;
        }
        int SelectNextQuestion()
        {
            return questionIDs[Questions.Count];
        }

        void AddQuestion()
        {
            if (Questions.Count < questionIDs.Length)
            {
                Questions.Add(DataReader.GetQuestion(dbID, SelectNextQuestion()));
            }
        }
        //public bool Evaluate(decimal passThreshhold)
        //{
        //    int i = CountCorrect();
        //    Results = (((decimal)i / (decimal)Questions.Count) * 100);
        //    Trace.WriteLine("You answered " + i + "/" + (decimal)Questions.Count + " correctly. Thats " + Results + "%.");   // Debug
        //    if (Results >= passThreshhold)
        //    {
        //        Trace.WriteLine("You passed since you got more than " + passThreshhold + "% correctly");            // Debug
        //        EvalMessage = EvaluateMessage(true);
        //        return true;
        //    }
        //    else
        //    {
        //        Trace.WriteLine("You failed since you got less than " + passThreshhold + "% correctly");            // Debug
        //        EvalMessage = EvaluateMessage(false);
        //        return false;
        //    }
        //}
    }
}
