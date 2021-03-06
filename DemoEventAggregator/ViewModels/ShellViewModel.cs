using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEventAggregator.ViewModels
{
    public class ShellViewModel : PropertyChangedBase
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
                NotifyOfPropertyChange(() => CanChangeMessage);
            }
        }

        private int _pressCount;

        public ShellViewModel()
        {
            Message = "Hello World";
            _pressCount = 0;
        }

        public void ChangeMessage(int incrementBy)
        {
            _pressCount += incrementBy;

            Message = "Presses = " + _pressCount;
        }
        public bool CanChangeMessage
        {
            get { return _pressCount < 10; }
        }
    }
}
