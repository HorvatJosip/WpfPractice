using System.Windows;

namespace WpfPractice
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        private StudentViewModel studentVM;

        public AddStudent()
        {
            InitializeComponent();

            // Inicijalno cemo postaviti da podaci odgovaraju studentu
            // koji se kreira u "servisu"
            Student initialStudent = StudentService.GetStudent();

            // Kreiramo view model koji ce prikazivati podatke studenta na sucelju
            studentVM = new StudentViewModel(initialStudent);

            // Postavljamo prozoru kontekst u instancu klase StudentViewModel
            // Time ce sad na sucelju kad bindamo uvijek gledati property-je StudentViewModel klase
            // Zato na sucelju mozemo rec Text="{Binding Name}" jer je Name property koji se nalazi u
            // Klasi StudentViewModel. Kad mijenjamo taj Text u TextBox-u, on ce mijenjati vrijednosti
            // studenta kojeg enkapsuliramo u view model-u
            this.DataContext = studentVM;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            // Dohvati studenta kojeg smo na sucelju mijenjali
            Student student = studentVM.Student;

            // Spremi ga u repozitorij
            Repository.Students.Add(student);

            // Vrati se na glavni izbornik
            Close();
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            // Ovo je sve sto treba napraviti jer je StudentViewModel bind-an na sucelje preko DataContext-a
            // Bind property-ja se radi preko onog eventa PropertyChanged koji javlja sucelju da se
            // promijenila vrijednost property-ja koji se zove Age u ovom slucaju, pa ce se label-ov content
            // azurirat na novu vrijednost
            studentVM.Age--;
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            studentVM.Age++;
        }
    }
}
