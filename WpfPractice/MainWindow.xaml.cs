using System;
using System.Windows;

namespace WpfPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Kraci nacin - ne zahtjeva 3 puta isti kod, samo je razilicit prozor
        private void Show<T>() where T : Window //ovaj where samo osigurava da je T klasa koja nasljeduje od klase Window, nije obavezan
        {
            // Napravi instancu prozora
            T window = Activator.CreateInstance<T>();

            // Sakrij trenutni prozor (opcionalno)
            this.Hide();

            // Prikazi novi prozor
            window.ShowDialog();

            // Prikazi trenutni prozor kad se novi zatvori (opcionalno)
            this.Show();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Show<AddStudent>();

            // Bez Generics-a bi bilo ovako:
            /*
            // Napravi instancu prozora
            AddStudent window = new AddStudent();

            // Sakrij trenutni prozor (opcionalno)
            this.Hide();

            // Prikazi novi prozor
            window.ShowDialog();

            // Prikazi trenutni prozor kad se novi zatvori (opcionalno)
            this.Show();
            */
        }

        private void btnViewStudents_Click(object sender, RoutedEventArgs e)
        {
            Show<ViewStudents>();
        }

        private void btnPlanner_Click(object sender, RoutedEventArgs e)
        {
            Show<Planner>();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            // Ugasi aplikaciju
            Close();
        }
    }
}
