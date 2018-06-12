using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace mybind.VIEWMODEL
{
    public class ViewModel
    {
        public CmdRolarDados cmdrolardados { get; set; }

        public CmdAppQuete cmdappquete { get; set; }

        public Dados dados { get; set; }

        public ViewModel()
        {
            cmdrolardados = new CmdRolarDados(this);
            cmdappquete = new CmdAppQuete(this);
        }

        public void vm_rolar(int aposta)
        {
            dados.rolar(ref aposta);
        }

        public void sair()
        {
            Application.Current.Shutdown();
        }

    }//class ViewModel
} //namespace
