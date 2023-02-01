using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWithPenguin.Utils
{
    [FirestoreData]
    public class UserInfo
    {
        [FirestoreProperty]
        public string birthday { get; set; }
        [FirestoreProperty]
        public bool gender { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public int score_1 { get; set; }
        [FirestoreProperty]
        public int score_2 { get; set; }
        [FirestoreProperty]
        public int score_3 { get; set; }
        [FirestoreProperty]
        public int score_4 { get; set; }
    }
}
