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

namespace NumbersToWords
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ConvertLanguage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            languageComboBox.ItemsSource = Enum.GetValues(typeof(ReplaceFormats));
            languageComboBox.SelectedIndex = 0;
        }

        private void TextChanged(object sender, RoutedEventArgs e)
        {
            string output = "";
            string input = textBoxInput.Text;

            if (input != "")
            {
                ReplaceFormats format = (ReplaceFormats) languageComboBox.SelectedItem;
                output = Replacer.Replace(input, format);
            }

            textBoxOutput.Text = output;
        }

        private void ComboBoxChanged(object sender, RoutedEventArgs e)
        {
            TextChanged(sender, e);
        }
    }
}
