using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using SmsQuiz.Client.Model;
using SmsQuiz.Client.SmsGateway;

namespace SmsQuiz.Client.Pages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        private ParticipantRegister _participantRegister;

        public StartPage(Quiz quiz)
        {
            Quiz = quiz;
            InitializeComponent();
            Loaded += Page_Loaded;
            Unloaded += Page_Unloaded;
        }

        public static readonly DependencyProperty QuizProperty = DependencyProperty.Register("Quiz", typeof(Quiz), typeof(StartPage), new UIPropertyMetadata(null));

        public Quiz Quiz
        {
            get { return (Quiz)GetValue(QuizProperty); }
            set { SetValue(QuizProperty, value); }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _participantRegister = new ParticipantRegister(Quiz);
            _participantRegister.SignupUsers();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null)
            {
                NavigationService.Navigate(new RoundPage(RoundGenerator.Next(Quiz.Participants)));
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _participantRegister.Finish();
        }
    }
}
