using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Centerparks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int[] _numberOfDays = new int[] { 1, 2, 5, 7, 8, 12, 14, 21 };
        private string[,] _houseWithPrice = new string[5, 2] {
                { "2 personen", "80" },
                { "4 personen", "120" } ,
                { "4 personen lux", "140" } ,
                { "6 personen", "180" },
                { "8 personen", "200"}
            };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (int number in _numberOfDays)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = number;
                daysComboBox.Items.Add(item);
            }

            for (int row = 0; row < _houseWithPrice.GetLength(0); row++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = _houseWithPrice[row,0];
                buildingComboBox.Items.Add(item);
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(daysComboBox.SelectedIndex != -1 && buildingComboBox.SelectedIndex != -1)
            {
                int numberOfDays = _numberOfDays[daysComboBox.SelectedIndex];
                int pricePerDay = int.Parse(_houseWithPrice[buildingComboBox.SelectedIndex, 1]);

                priceTextBox.Text = $"{numberOfDays * pricePerDay:c}";
            }
        }
    }
}