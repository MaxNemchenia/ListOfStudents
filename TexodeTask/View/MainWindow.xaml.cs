using System.Windows;
using System.Windows.Controls;
using TexodeTask.ViewModel;

namespace TexodeTask.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedItems.Count > 0)
            {
                DeleteButton.IsEnabled = true;
                StackPanel.Visibility = Visibility.Visible;

            }
            else
            {
                StackPanel.Visibility = Visibility.Hidden;
                DeleteButton.IsEnabled = false;
            }

            if (ListBox.Items.Count == 0)
            {
                ListBox.Visibility = Visibility.Hidden;
                MessageBox.Show("Список пуст");
            }
            else
            {
                ListBox.Visibility = Visibility.Visible;
            }
        }
    }
}
