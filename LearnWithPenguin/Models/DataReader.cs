using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWithPenguin.Models
{
    internal class DataReader

    { 
        static Quizz_LearnWithPenguineEntities quizz = new Quizz_LearnWithPenguineEntities();

        static private Byte ConvertAnserToByte(string data)
        {
            switch (data)
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
