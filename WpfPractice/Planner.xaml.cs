using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfPractice
{
    /// <summary>
    /// Interaction logic for Planner.xaml
    /// </summary>
    public partial class Planner : Window
    {
        public Planner()
        {
            InitializeComponent();

            // Postavi naslov planera u trenutni dan
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Proparsiraj vrijednosti, zanemari neispravan unos
            int.TryParse(txtHoursFrom.Text, out int hoursFrom);
            int.TryParse(txtMinutesFrom.Text, out int minutesFrom);
            int.TryParse(txtHoursTo.Text, out int hoursTo);
            int.TryParse(txtMinutesTo.Text, out int minutesTo);

            // Napravi string u formatu 15:00 - 16:00
            string timeString = $"{hoursFrom:00}:{minutesFrom:00} - {hoursTo:00}:{minutesTo:00}";

            // Pronadi predmet koji je odabran
            ListBoxItem selectedItem = (ListBoxItem)listSubjects.SelectedItem;
            string subject = selectedItem.Content.ToString();
            
            // Plan prikazuj kao label
            Label plan = new Label
            {
                Content = $"{subject}{Environment.NewLine}  {timeString}",
                FontSize = 18,
                Padding = new Thickness(15),
                Margin = new Thickness(5),
                Background = (Brush)FindResource("brushRadialNotRegular"),
                Foreground = Brushes.White
            };

            // Dodaj plan u WrapPanel
            pnlPlans.Children.Add(plan);
        }
    }
}
