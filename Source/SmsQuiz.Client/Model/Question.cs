using System.Collections.Generic;
using System.Linq;

namespace SmsQuiz.Client.Model
{
    public class Question
    {
        public Question(string text, params Answer[] answers)
        {
            Text = text;
            AvailableAnswers = new List<Answer>();
            AvailableAnswers.AddRange(answers);
        }

        public Question(string text, bool testQuestion, params Answer[] answers)
        {
            Text = text;
            TestQuestion = testQuestion;
            AvailableAnswers = new List<Answer>();
            AvailableAnswers.AddRange(answers);
        }

        public string Text { get; set; }

        public bool TestQuestion { get; set; }

        public Answer CorrectAnswer
        {
            get { return AvailableAnswers.Where(a => a.IsCorrect == true).First(); }
        }

        public List<Answer> AvailableAnswers { get; set; }
    }
}
