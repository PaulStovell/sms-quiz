using System.ComponentModel;

namespace SmsQuiz.Client.Model
{
    public class ParticipantAnswer : BindableObject
    {
        private Answer _answer;
        private bool? _wasCorrect;

        public ParticipantAnswer(Participant participant)
        {
            Participant = participant;
        }

        public Participant Participant { get; set; }

        public Answer Answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Answer"));
                OnPropertyChanged(new PropertyChangedEventArgs("HasAnswered"));
                OnPropertyChanged(new PropertyChangedEventArgs("WasCorrect"));
            }
        }

        public bool HasAnswered
        {
            get { return _answer != null; }
        }

        public bool? WasCorrect
        {
            get { return _wasCorrect; }
            set
            {
                _wasCorrect = value;
                OnPropertyChanged(new PropertyChangedEventArgs("WasCorrect"));
            }
        }
    }
}
