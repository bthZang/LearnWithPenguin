using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWithPenguin.Models
{
    [DelimitedRecord(",")]
    [IgnoreEmptyLines()]
    [IgnoreFirst()]

    public class History
    {
        // Properties
        public string AppTitle { get; set; }
        public int DBID { get; set; }
        public int QuestionaireID { get; set; }
        public int QuestionaireLength { get; set; }
        public decimal QuestionairePercentage { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }
        public int CorrectAnswer { get; set; }
        public History()
        {
            AppTitle = "";
            DBID = -1;
            QuestionaireID = -1;
            QuestionaireLength = -1;
            QuestionairePercentage = -1;
            QuestionID = -1;
            AnswerID = -1;
            CorrectAnswer = -1;
        }
        public History(string appTitle, int dbID, int questionaireID, int questionaireLength, decimal questionairePercentage, int questionID, int answerID, int correctAnswer)
        {
            AppTitle = appTitle;
            DBID = dbID;
            QuestionaireID = questionaireID;
            QuestionaireLength = questionaireLength;
            QuestionairePercentage = questionairePercentage;
            QuestionID = questionID;
            AnswerID = answerID;
            CorrectAnswer = correctAnswer;
        }
        public string CSVHeaders()
        {
            return "AppTitle,DBID,QuestionaireID,QuestionaireLength,QuestionairePercentage,QuestionID,AnswerID,CorrectAnswer";
        }
        new public string ToString()
        {
            return AppTitle + "," + DBID + "," + QuestionaireID + "," + QuestionaireLength + "," + QuestionairePercentage + "," + QuestionID + "," + AnswerID + "," + CorrectAnswer;
        }

    }
}
