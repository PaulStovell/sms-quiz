using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmsQuiz.Client.Model
{
    public static class RoundGenerator
    {
        private static int _lastRoundNumber = 1;

        public static Round Next(IEnumerable<Participant> roundParticipants)
        {
            var result = new Round(_lastRoundNumber++);
            result.Question = QuestionGenerator.Next();
            result.ParticipantAnswers.AddRange(roundParticipants.Select(p => new ParticipantAnswer(p)));
            return result;
        }
    }
}
