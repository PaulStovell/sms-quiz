using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmsQuiz.Client.Model
{
    public class Answer : BindableObject
    {
        public string Letter { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
