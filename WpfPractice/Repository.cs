using System.Collections.Generic;

namespace WpfPractice
{
    //najjednostavniji repo - u memoriji
    static class Repository
    {
        public static List<Student> Students { get; } = new List<Student>();
    }
}
