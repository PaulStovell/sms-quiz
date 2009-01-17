using System.ComponentModel;

namespace SmsQuiz.Client.Model
{
    public class Participant : BindableObject
    {
        public static readonly PropertyChangedEventArgs PhoneNumberPropertyChangedEventArgs = new PropertyChangedEventArgs("PhoneNumber");
        public static readonly PropertyChangedEventArgs NamePropertyChangedEventArgs = new PropertyChangedEventArgs("Name");
        
        private string _phoneNumber;
        private string _name;

        public Participant()
        {

        }
        
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(PhoneNumberPropertyChangedEventArgs);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(NamePropertyChangedEventArgs);
            }
        }
    }
}
