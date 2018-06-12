using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using mybind.VIEWMODEL;

namespace mybind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel viewmodel { get; set;  }

        public Dados dados { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            rel();


            ObjectDataProvider o = Resources["dados"] as ObjectDataProvider;
            dados = o.Data as Dados;
            viewmodel = (ViewModel)Resources["vm"];
            viewmodel.dados = dados;

        }

        protected void rel()
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Interval = new TimeSpan(1000);
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() => txtrelogio.Text = DateTime.Now.ToString());
        }
    }//class window

    public class ConversorImg : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String caminho = "imagens/" + ((int)value).ToString() + ".png";
            BitmapImage img = new BitmapImage(new Uri(caminho, UriKind.Relative));
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


} //namespace
