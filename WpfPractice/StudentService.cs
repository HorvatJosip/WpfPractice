namespace WpfPractice
{
    static class StudentService
    {
        public static Student GetStudent()
        {
            return new Student
            {
                Name = "Milica",
                Surname = "Krmpotić",
                Age = 33,
                Regular = false
            };
        }
    }
}
