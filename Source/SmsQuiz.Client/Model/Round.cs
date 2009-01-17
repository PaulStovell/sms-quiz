using System.Collections.Generic;
using System.ComponentModel;

namespace SmsQuiz.Client.Model
{
    public class Round : BindableObject
    {
        private bool _isLockedIn;

        public Round(int roundNumber)
        {
            ParticipantAnswers = new List<ParticipantAnswer>();
            RoundNumber = roundNumber;
        }

        public int RoundNumber { get; set; }
        public Question Question { get; set; }
        public List<ParticipantAnswer> ParticipantAnswers { get; set; }

        public bool IsLockedIn
        {
            get { return _isLockedIn; }
            private set
            {
                _isLockedIn = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsLockedIn"));
            }
        }

        public void LockIn()
        {
            IsLockedIn = true;
            foreach (var participantAnswer in ParticipantAnswers)
            {
                participantAnswer.WasCorrect = participantAnswer.Answer == Question.CorrectAnswer;
            }
        }
    }
}
