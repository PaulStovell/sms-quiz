using GsmComm.GsmCommunication;
using SmsQuiz.Client.Model;
using GsmComm.PduConverter;
using System.Text.RegularExpressions;

namespace SmsQuiz.Client.SmsGateway
{
    public class ParticipantRegister
    {
        private readonly Quiz _quiz;
        private MessageListener _messageListener;

        public ParticipantRegister(Quiz quiz)
        {
            _quiz = quiz;
        }

        public void SignupUsers()
        {
            _messageListener = new MessageListener(MessageReceived);
            _messageListener.StartListening();
        }

        private void MessageReceived(DecodedShortMessage message)
        {
            var data = message.Data as SmsDeliverPdu;

            bool found = false;
            foreach (var participant in _quiz.Participants)
            {
                if (participant.PhoneNumber == data.OriginatingAddress)
                {
                    found = true;
                    participant.Name = Regex.Replace(data.UserDataText, "\\s+", " ");
                }
            }
            if (!found)
            {
                var participant = new Participant();
                participant.Name = Regex.Replace(data.UserDataText, "\\s+", " ");
                participant.PhoneNumber = data.OriginatingAddress;
                _quiz.Participants.Add(participant);
            }
        }

        public void Finish()
        {
            if (_messageListener != null)
            {
                _messageListener.StopListening();
            }
        }
    }
}