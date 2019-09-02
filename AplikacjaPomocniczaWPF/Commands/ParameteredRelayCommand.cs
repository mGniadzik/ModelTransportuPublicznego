using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AplikacjaPomocniczaWPF.Commands
{
    class ParameteredRelayCommand<T> : ICommand where T : class, new()
    {
        private Action<T> action;

        public ParameteredRelayCommand(Action<T> action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (parameter is T)
            {
                action(parameter as T);
            }
        }
    }
}
