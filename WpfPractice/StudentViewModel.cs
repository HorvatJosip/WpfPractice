using System.ComponentModel;

namespace WpfPractice
{
    class StudentViewModel : INotifyPropertyChanged
    {
        public Student Student { get; } // set nam ne treba jer se vrijednost postavlja samo u konstruktoru

        // Ime koje se prikazuje na sucelju
        public string Name
        {
            get
            {
                // Kad se zatrazi ime, vrati ime studenta
                return Student.Name;
            }
            set
            {
                // Postavi ime studenta
                Student.Name = value;

                // Naziv property-ja dohvati pomocu nameof
                // (moze i samo "Name", ali to stvara problem kod refaktoriranja)
                string propertyName = nameof(Name);

                // Javi sucelju da se promijenio property koji se zove "Name"
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Surname
        {
            get
            {
                return Student.Surname;
            }
            set
            {
                Student.Surname = value;
                string propertyName = nameof(Surname);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int Age
        {
            get
            {
                return Student.Age;
            }
            set
            {
                // Dozvoli samo vrijednosti u intervalu [10, 150]
                if (value >= 10 && value <= 150)
                {
                    Student.Age = value;
                    string propertyName = nameof(Age);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        public bool Regular
        {
            get
            {
                return Student.Regular;
            }
            set
            {
                Student.Regular = value;
                string propertyName = nameof(Regular);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public StudentViewModel(Student student)
        {
            Student = student;
        }
    }
}
