using System.Windows.Controls;
using BKNBrauhelferKonverter.ViewModels;

namespace BKNBrauhelferKonverter.Views
{
    /// <summary>
    /// Interaction logic for SudKonverterView.xaml
    /// </summary>
    public sealed partial class SudKonverterView : UserControl
    {
        public SudKonverterView()
        {
            InitializeComponent();

            DataContext = new SudKonverterViewModel();
        }
    }
}
