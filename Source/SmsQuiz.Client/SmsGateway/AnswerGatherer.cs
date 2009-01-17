using GsmComm.GsmCommunication;
using SmsQuiz.Client.Model;
using GsmComm.PduConverter;

namespace SmsQuiz.Client.SmsGateway
{
    public class AnswerGatherer
    {
        private readonly Round _round;
        private MessageListener _messageListener;

        public AnswerGatherer(Round round)
        {
            _round = round;
        }

        public void GatherAnswers()
        {
            _messageListener = new MessageListener(MessageReceived);
            _messageListener.StartListening();
        }

        private void MessageReceived(DecodedShortMessage message)
        {
            var data = message.Data as SmsDeliverPdu;
            foreach (var participantAnswer in _round.ParticipantAnswers)
            {
                if (participantAnswer.Participant.PhoneNumber == data.OriginatingAddress)
                {
                    string messageText = message.Data.UserDataText;
                    foreach (var answer in _round.Question.AvailableAnswers)
                    {
                        if (string.Compare(answer.Letter, messageText, true) == 0)
                        {
                            participantAnswer.Answer = answer;
                            break;
                        }
                    }
                }
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