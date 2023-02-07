using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWithPenguin.Utils
{
    public class Firestore
    {
        public static FirestoreDb db;

        public static void initFireStore()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"test-firebase.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("learn-with-penguin");
        }
    }
}