using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AverageCalculationApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(NTextBox.Text);
                int[] numbers = NumbersTextBox.Text.Split(' ').Select(int.Parse).ToArray();

                if (numbers.Length != n)
                {
                    MessageBox.Show("Количество чисел не совпадает с N.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var nonMultiplesOfThree = numbers.Where(x => x % 3 != 0).ToArray();

                if (nonMultiplesOfThree.Length == 0)
                {
                    MessageBox.Show("Нет чисел, не кратных 3.", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                double average = nonMultiplesOfThree.Average();
                ResultTextBlock.Text = $"Среднее арифметическое: {average:F2}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Ввод содержит некорректные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
