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

namespace Kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string display_content = string.Empty;
        string current_number = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }
        //Funkcja wywoła się gdy zostanie wprowadzona liczba
        private void button_num_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (display_content.Contains('E'))
            {
                current_number = String.Empty;
                display_content = String.Empty;
                text_block_display.Text = display_content;
            }
            if(current_number.Length<2 && current_number.Contains('0'))
            {
                
                current_number = current_number.Remove(current_number.Length-1,1);
                display_content = display_content.Remove(display_content.Length-1,1);
            }
            current_number += btn.Content.ToString();
            display_content += btn.Content.ToString();
            text_block_display.Text = display_content;
        }

        private void button_operator_Click(object sender, RoutedEventArgs e)
        {
            if (display_content.Contains('E'))
            {
                current_number = String.Empty;
                display_content = String.Empty;
                text_block_display.Text = display_content;
            }
            var btn = sender as Button;
            if(display_content != string.Empty)
            {
                button_eq_Click(sender, e);
                if (!display_content.Contains('E'))
                {
                    if (!int.TryParse(display_content[display_content.Length - 1].ToString(), out int value))
                    {
                        display_content = display_content.Replace(display_content[display_content.Length - 1], btn.Content.ToString().ToCharArray()[0]);
                    }
                    else
                    {
                        display_content += btn.Content.ToString();
                    }
                }                
                text_block_display.Text = display_content;
            }
            current_number = string.Empty;
        }

        private void button_eq_Click(object sender, RoutedEventArgs e)
        {
            
            if(display_content.Contains('E'))
            {
                current_number = String.Empty;
                display_content = String.Empty;
                text_block_display.Text = display_content;
            }
            var operation = display_content;
            //Jeśli operacja nie jest pusta i jeśli ostatni znak to cyfra
            if (operation != String.Empty && int.TryParse(operation[operation.Length - 1].ToString(), out int value))
            {
                string a = String.Empty, b = String.Empty, op = String.Empty, result = String.Empty;
                a = operation[0].ToString();
                int i = 1;
                while (i < operation.Length && (int.TryParse(operation[i].ToString(), out int value2) || operation[i] == ','))
                {
                    a += operation[i];
                    i++;
                }
                if(i < operation.Length)
                {
                    op = operation[i].ToString();
                    i++;
                }
                while(i < operation.Length)
                {
                    b += operation[i].ToString();
                    i++;
                }

                if(op != String.Empty)
                {
                    switch (op) //op - operator
                    {
                        case "+":
                            result = (double.Parse(a) + double.Parse(b)).ToString();
                            break;
                        case "-":
                            result = (double.Parse(a) - double.Parse(b)).ToString();
                            break;
                        case "*":
                            result = (double.Parse(a) * double.Parse(b)).ToString();
                            break;
                        case "/":
                            if (double.Parse(b) != 0)
                                result = (double.Parse(a) / double.Parse(b)).ToString();
                            else{
                                result = "ERROR";
                            }
                            break;
                    }
                    current_number = result.ToString();
                    display_content = result.ToString();
                    text_block_display.Text = display_content;
                }
            }
        }

        private void button_c_Click(object sender, RoutedEventArgs e)
        {
            current_number = string.Empty;
            display_content = string.Empty;
            text_block_display.Text = display_content;
        }

        private void button_sep_Click(object sender, RoutedEventArgs e)
        {
            if (!display_content.Contains('E'))
            {
                var btn = sender as Button;

                if (current_number == string.Empty)
                {
                    display_content += '0';
                }
                if (int.TryParse(display_content[display_content.Length - 1].ToString(), out int value) && !(current_number.Contains(',')))
                {
                    current_number += btn.Content.ToString();
                    display_content += btn.Content.ToString();
                }

                text_block_display.Text = display_content;
            }
                
        }

    }
}
