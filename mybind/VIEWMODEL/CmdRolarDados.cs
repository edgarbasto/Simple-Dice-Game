using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mybind.VIEWMODEL
{
    public class CmdRolarDados : ICommand
    {

        public ViewModel viewmodel { get; set; }

        public CmdRolarDados(ViewModel vm)
        {
            viewmodel = vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null) return false;
            if (viewmodel.dados.Montante <= 0) return false;
            return true;
        }

        public void Execute(object parameter)
        {
            int aposta = int.Parse(parameter.ToString());
            viewmodel.vm_rolar(aposta);
        }
    }


    public class CmdAppQuete : ICommand
    {
        public ViewModel viewmodel { get; set; }

        public CmdAppQuete(ViewModel vm)
        {
            viewmodel = vm;

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewmodel.sair();
        }
    }



}
