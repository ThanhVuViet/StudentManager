
using BaiTap.StudentService;
using static BaiTap.Student;

namespace BaiTap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, float> PhanTramHocLuc = new Dictionary<String, float>();
            StudentManageService studentService = new StudentManageService();
            List<Student> students = new List<Student>
            {
                new Student(1, "Nguyen Van A", new DateTime(2000, 1, 15), "Hanoi", 170, 65, "1234567890", "Hanoi University", 2018, 8.5f),
                new Student(2, "Tran Thi B", new DateTime(1999, 4, 10), "Ho Chi Minh", 165, 55, "0987654321", "HCM University", 2017, 6.3f),
                new Student(3, "Le Van C", new DateTime(2001, 5, 25), "Da Nang", 175, 70, "1122334455", "Da Nang University", 2019, 4.8f),
                new Student(4, "Pham Thi D", new DateTime(2000, 7, 5), "Hue", 160, 50, "5566778899", "Hue University", 2018, 2.5f)
            };
            Dictionary<String, List<Student>> XepHocLuc = new Dictionary<string, List<Student>>();


            foreach (var studentq in students)
            {
                Console.WriteLine(studentq.GetHocLuc());
            }

            int NumberOfStudent = students.Count;
            foreach (var student in students)
            {
                string HocLuc = student.GetHocLuc().ToString();
                if (!PhanTramHocLuc.ContainsKey(HocLuc))
                {
                    PhanTramHocLuc[HocLuc] = 1.0f / NumberOfStudent * 100;  
                }
                else
                {
                    PhanTramHocLuc[HocLuc] += 1.0f / NumberOfStudent * 100;
                }
            }
            Console.WriteLine("Phần trăm học lực:");
            foreach (var entry in PhanTramHocLuc)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}%");
            }
            foreach (var student in students)
            {
                string HocLuc = student.GetHocLuc().ToString();
                if (!XepHocLuc.ContainsKey(HocLuc))
                {
                    XepHocLuc[HocLuc] = new List<Student>();
                }
                else
                {
                    XepHocLuc[HocLuc].Add(student);
                }
            }
            foreach (var entry in XepHocLuc)
            {
                Console.WriteLine($"Students with Học lực: {entry.Key}");
                foreach (var student in entry.Value)
                {
                    Console.WriteLine(student.ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
