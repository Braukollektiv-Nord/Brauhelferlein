using System;
using System.Collections.Generic;
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
using BKNBrauhelferKonverter.ViewModels;

namespace BKNBrauhelferKonverter.Views
{
    /// <summary>
    /// Interaction logic for EinstellungenView.xaml
    /// </summary>
    public partial class EinstellungenView : UserControl
    {
        public EinstellungenView()
        {
            InitializeComponent();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((EinstellungenViewModel)DataContext).Password = ((PasswordBox)sender).SecurePassword.ToString();
            }
        }

        private void OnSqlPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((EinstellungenViewModel)DataContext).SqlPassword = ((PasswordBox)sender).SecurePassword.ToString();
            }
        }
    }
}
