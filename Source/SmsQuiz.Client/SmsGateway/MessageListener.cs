using System;
using System.ComponentModel;
using System.Threading;
using GsmComm.GsmCommunication;
using SmsQuiz.Client.Properties;

namespace SmsQuiz.Client.SmsGateway
{
    public class MessageListener
    {
        private static readonly object _commPortLock = new object();
        private readonly Action<DecodedShortMessage> _receivedMessageCallback;
        private int _communicationsPort = Settings.Default.CommPort;
        private int _baudRate = Settings.Default.CommPortBaudRate;
        private string _storage = PhoneStorageType.Sim;
        private int _timeout = 300;
        private BackgroundWorker _backgroundWorker;
        
        public MessageListener(Action<DecodedShortMessage> messageReceived)
        {
            _receivedMessageCallback = messageReceived;
        }

        public void StartListening()
        {
            if (_backgroundWorker != null)
            {
                _backgroundWorker.CancelAsync();
            }
            
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (_commPortLock)
            {
                var communications = new GsmCommMain(_communicationsPort, _baudRate, _timeout);
                communications.Open();
                communications.DeleteMessages(DeleteScope.All, _storage);
                communications.Close();
            }

            while (!_backgroundWorker.CancellationPending)
            {
                DecodedShortMessage[] messages = null;
                lock (_commPortLock) 
                {
                    var communications = new GsmCommMain(_communicationsPort, _baudRate, _timeout);
                    communications.Open();
                    messages = communications.ReadMessages(PhoneMessageStatus.ReceivedUnread, _storage);
                    communications.Close();
                }
                foreach (var message in messages)
                {
                    _backgroundWorker.ReportProgress(0, message);
                }
                Thread.Sleep(1000);
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var message = e.UserState as DecodedShortMessage;
            if (message != null)
            {
                _receivedMessageCallback(message);
            }
        }

        public void StopListening()
        {
            if (_backgroundWorker != null)
            {
                _backgroundWorker.CancelAsync();
            }
        }
    }
}
