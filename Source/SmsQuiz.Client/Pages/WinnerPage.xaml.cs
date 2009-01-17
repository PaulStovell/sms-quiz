using System.Windows;
using System.Windows.Controls;
using SmsQuiz.Client.Model;

namespace SmsQuiz.Client.Pages
{
    /// <summary>
    /// Interaction logic for WinnerPage.xaml
    /// </summary>
    public partial class WinnerPage : Page
    {
        public WinnerPage(Participant participant)
        {
            Winner = participant;
            InitializeComponent();
        }

        public static readonly DependencyProperty WinnerProperty = DependencyProperty.Register("Winner", typeof(Participant), typeof(WinnerPage), new UIPropertyMetadata(null));

        public Participant Winner
        {
            get { return (Participant)GetValue(WinnerProperty); }
            set { SetValue(WinnerProperty, value); }
        }
    }
}
