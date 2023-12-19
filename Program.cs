namespace Модуль
{
    public class Student
    {
        public string Name;
        public int Age;
        public string Specialnist;
        public int Year;
        public Mark mark;

        public Student ShallowCopy()
        {
            return (Student)this.MemberwiseClone();
        }

        public Student DeepCopy()
        {
            Student clone = (Student)this.MemberwiseClone();
            clone.Name = String.Copy(Name);
            clone.mark = new Mark(mark.MarkValue);

            return clone;
        }
    }
    public class Mark
    {
        public int MarkValue;

        public Mark(int markValue)
        {
            this.MarkValue = markValue;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.Age = 30;
            s1.Specialnist = "121";
            s1.Name = "Саймон \"Гоуст\" Райлі";
            s1.Year = 1;
            s1.mark = new Mark(100);

            Student s2 = s1.ShallowCopy();
            Student s3 = s1.DeepCopy();

            Console.WriteLine("Оригінальне значення студентів 1,2,3: \n");
            Console.WriteLine("ст1: ");
            DisplayValues(s1);
            Console.WriteLine("ст2: ");
            DisplayValues(s2);
            Console.WriteLine("ст3: ");
            DisplayValues(s3);

            s1.Age = 26;
            s1.Specialnist = "122";
            s1.Name = "Джон \"Соуп\" Мактавіш";
            s2.Year = 3;
            s1.mark.MarkValue = 100;

            Console.WriteLine("Нове значення студентів 1,2,3: \n");
            Console.WriteLine("ст1: ");
            DisplayValues(s1);
            Console.WriteLine("ст2 (змінилося орієнтоване значення): ");
            DisplayValues(s2);
            Console.WriteLine("ст3 (Все зилишилось як є): ");
            DisplayValues(s3);
        }
        public static void DisplayValues(Student p)
        {
            Console.WriteLine("      Ім'я: {0:s}, Вік: {1:d}, Спеціальність: {2:d}, Курс: {3:d}",
                p.Name, p.Age, p.Specialnist,p.Year);
            Console.WriteLine("      Оцінка: {0:d}", p.mark.MarkValue);
        }
    }
}