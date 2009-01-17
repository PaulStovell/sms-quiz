using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmsQuiz.Client.Model
{
    public static class QuestionGenerator
    {
        private static readonly Question[] _questions = new Question[]
                                                   {
                                                       new Question("When you have a bug on a production server, what should you do?", true,
                                                           new Answer() { Letter = "A", Text = "Install Visual Studio" },
                                                           new Answer() { Letter = "B", Text = "Use WinDbg" },
                                                           new Answer() { Letter = "C", Text = "Reboot the machine" },
                                                           new Answer() { Letter = "D", Text = "Call Corneliu", IsCorrect = true }
                                                           ),
                                                       //new Question("Castle Windsor is:",
                                                       //    new Answer() { Letter = "A", Text = "A palace in England", IsCorrect = true },
                                                       //    new Answer() { Letter = "B", Text = "An Inversion of Control container" },
                                                       //    new Answer() { Letter = "C", Text = "An object-relational mapping tool" },
                                                       //    new Answer() { Letter = "D", Text = "A logging framework" }
                                                       //    ),
                                                       new Question("Which of the following is NOT an interface in ASP.NET MVC?",
                                                           new Answer() { Letter = "A", Text = "IViewEngine" },
                                                           new Answer() { Letter = "B", Text = "IControllerFactory" },
                                                           new Answer() { Letter = "C", Text = "IDatabase", IsCorrect = true },
                                                           new Answer() { Letter = "D", Text = "IRouteHandler" }
                                                           ),
                                                       new Question("Which of the following is NOT a SQL Server transaction isolation level?",
                                                           new Answer() { Letter = "A", Text = "Read Uncommitted" },
                                                           new Answer() { Letter = "B", Text = "Snapshot" },
                                                           new Answer() { Letter = "C", Text = "Repeatable Read" },
                                                           new Answer() { Letter = "D", Text = "Deadlocked", IsCorrect = true }
                                                           ),
                                                       new Question("Which of these events is NOT in the ASP.NET Page Lifecycle:",
                                                           new Answer() { Letter = "A", Text = "Init" },
                                                           new Answer() { Letter = "B", Text = "Load" },
                                                           new Answer() { Letter = "C", Text = "Save", IsCorrect = true },
                                                           new Answer() { Letter = "D", Text = "Render" }
                                                           ),
                                                       new Question("SharePoint web parts can be deployed by:",
                                                           new Answer() { Letter = "A", Text = "STSADM" },
                                                           new Answer() { Letter = "B", Text = "Gallery->Upload .webpart" },
                                                           new Answer() { Letter = "C", Text = "Deploy from Visual Studio", IsCorrect = true },
                                                           new Answer() { Letter = "D", Text = "Web Services" }
                                                           ),
                                                       new Question("Windows Presentation Foundation applications are rendered by:",
                                                           new Answer() { Letter = "A", Text = "DirectX", IsCorrect = true },
                                                           new Answer() { Letter = "B", Text = "OpenGL" },
                                                           new Answer() { Letter = "C", Text = "GDI+" },
                                                           new Answer() { Letter = "D", Text = "cmd.exe" }
                                                           ),
                                                       new Question("Which of the following is not a SQL lock type:",
                                                           new Answer() { Letter = "A", Text = "DEADLOCK", IsCorrect = true },
                                                           new Answer() { Letter = "B", Text = "ROWLOCK" },
                                                           new Answer() { Letter = "C", Text = "PAGLOCK" },
                                                           new Answer() { Letter = "D", Text = "XLOCK" }
                                                           ),
                                                       new Question("The .NET garbage collector looks after:",
                                                           new Answer() { Letter = "A", Text = "Managed memory", IsCorrect = true },
                                                           new Answer() { Letter = "B", Text = "Unmanaged memory" },
                                                           new Answer() { Letter = "C", Text = "Both" },
                                                           new Answer() { Letter = "D", Text = "Neither" }
                                                           ),
                                                       new Question("SQL's Deadlock Victim error code is:",
                                                           new Answer() { Letter = "A", Text = "404" },
                                                           new Answer() { Letter = "B", Text = "OWIE" },
                                                           new Answer() { Letter = "C", Text = "1205", IsCorrect = true },
                                                           new Answer() { Letter = "D", Text = "1502" }
                                                           ),
                                                       new Question("Eliminator: When is my birthday?",
                                                           new Answer() { Letter = "A", Text = "17th October", IsCorrect = true },
                                                           new Answer() { Letter = "B", Text = "10th July"},
                                                           new Answer() { Letter = "C", Text = "32nd September" },
                                                           new Answer() { Letter = "D", Text = "30th February" }
                                                           )
                                                   };

        private static int _questionIndex;

        public static Question Next()
        {
            if (_questionIndex + 1 < _questions.Length)
            {
                return _questions[_questionIndex++];
            }
            else
            {
                return _questions[_questions.Length - 1];
            }
        }
    }
}
