using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SmsQuiz.Client.Model;
using SmsQuiz.Client.SmsGateway;
using System.Collections.Generic;

namespace SmsQuiz.Client.Pages
{
    /// <summary>
    /// Interaction logic for RoundPage.xaml
    /// </summary>
    public partial class RoundPage : Page
    {
        private AnswerGatherer _answerGatherer;

        public RoundPage(Round round)
        {
            Round = round;
            InitializeComponent();
            Loaded += Page_Loaded;
        }

        public static readonly DependencyProperty RoundProperty = DependencyProperty.Register("Round", typeof(Round), typeof(RoundPage), new UIPropertyMetadata(null));
        
        public Round Round
        {
            get { return (Round)GetValue(RoundProperty); }
            set { SetValue(RoundProperty, value); }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _answerGatherer = new AnswerGatherer(Round);
            _answerGatherer.GatherAnswers();
        }

        private void LockedInButton_Click(object sender, RoutedEventArgs e)
        {
            _answerGatherer.Finish();

            Round.LockIn();
        }

        private void NextRoundButton_Click(object sender, RoutedEventArgs e)
        {
            Page nextPage = null;
            List<Participant> correctParticipants = Round.ParticipantAnswers.Where(a => a.WasCorrect ?? false).Select(a => a.Participant).ToList();
            if (correctParticipants.Count == 1 && !Round.Question.TestQuestion)
            {
                nextPage = new WinnerPage(correctParticipants[0]);
            }
            else
            {
                List<Participant> participantsToCarryOver = correctParticipants;
                if (correctParticipants.Count == 0 || Round.Question.TestQuestion)
                {
                    participantsToCarryOver = Round.ParticipantAnswers.Select(a => a.Participant).ToList();
                }
                nextPage = new RoundPage(RoundGenerator.Next(participantsToCarryOver));
            }
            if (NavigationService != null)
            {
                NavigationService.Navigate(nextPage);
            }
        }
    }
}
