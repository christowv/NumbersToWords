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
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(textBox1.Text);
            TranslateLanguages lang = (TranslateLanguages) Enum.Parse(typeof(TranslateLanguages), ConvertLanguage);
            string words = Translator.ToWords(num, lang);

            textBox2.Text = words;
        }

        private void LanguageChecked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton) sender;
            ConvertLanguage = pressed.Content.ToString();
            button1.IsEnabled = true;
        }
    }
}
