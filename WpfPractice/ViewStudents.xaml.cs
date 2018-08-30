using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfPractice
{
    /// <summary>
    /// Interaction logic for ViewStudents.xaml
    /// </summary>
    public partial class ViewStudents : Window
    {
        public ViewStudents()
        {
            InitializeComponent();

            // Za svakog studenta u repozitoriju...
            foreach (Student student in Repository.Students)
            {
                // Dohvati pozadinu ovisno o tome je li redovan ili ne
                string resourceName;
                if (student.Regular == true)
                    resourceName = "brushRadialRegular";
                else
                    resourceName = "brushRadialNotRegular";

                Brush background = (Brush)FindResource(resourceName);

                // Napravi label koji ce predstavljati njegov prikaz
                Label studentDisplay = new Label
                {
                    Content = $"{student.Name} {student.Surname} ({student.Age})",
                    Background = background
                };

                // Dodaj ga u panel
                pnlStudents.Children.Add(studentDisplay);
            }
        }
    }
}
