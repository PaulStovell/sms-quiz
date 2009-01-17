using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace SmsQuiz.Client.Model
{
    public class Quiz : BindableObject
    {
        public Quiz()
        {
            Participants = new ObservableCollection<Participant>();
        }

        public ObservableCollection<Participant> Participants { get; set; }
    }
}
