using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace mybind
{
    public class Dados:DependencyObject, INotifyPropertyChanged
    {
        int[] _dados;
        public int Dado1
        {
            get { return _dados[0]; }
            set { if (value >= 1 && value <= 6) _dados[0] = value;
                onPropertyChanged("Dado1");
            }
        }

        public int Dado2
        {
            get { return _dados[1]; }
            set { if (value >= 1 && value <= 6) _dados[1] = value;
                onPropertyChanged("Dado2");
            }
        }

        string _jogador;

        public string Jogador
        {
            get { return _jogador; }
            set { _jogador = value;
                onPropertyChanged("Jogador");
            }
        }

        private int _montante;

        public event PropertyChangedEventHandler PropertyChanged;

        public void onPropertyChanged(string nome)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nome));
        }

        public int Montante
        {
            get { return _montante; }
            set { _montante = value;
                onPropertyChanged("Montante");
            }
        }

        public Dados() {
            _dados = new int[2] { 3, 6 };
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                this.Jogador = "Zé da Batota";
                this.Montante = 3000;
            }
        }

        public Dados(string jogador, int montante) : this()
        {
            this.Jogador = jogador;
            this.Montante = montante;
        }

        public void rolar(ref int aposta)
        {
            if (Montante >= aposta) Montante -= aposta;
            else
            {
                if (Montante > 0) { aposta = Montante; Montante = 0; }
                else aposta = 0;
            }

            if (aposta > 0)
            {
                Random r = new Random();
                Dado1 = r.Next(1,7);
                Dado2 = r.Next(1,7);
            }


        }


    } //fim class Dados
} //namespace
