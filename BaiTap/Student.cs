using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap
{
    internal class Student: Person
    {
        public string StudentId { get; set; }
        public string University { get; set; }
        public int YearStarted { get; set; }
        public float GPA { get; set; }
        public HocLuc HanhKiem { get; set; }
        public enum HocLuc
        {
            Kem,
            Yeu,
            TrungBinh,
            Kha,
            Gioi,
            XuatSac

        }
        public HocLuc GetHocLuc()
        {
            return HanhKiem;
        }

        public Student(int id, string name, DateTime dateOfBirth, string address, double height, double weight,
                       string studentId, string university, int yearStarted, float gpa)
            : base(id, name, dateOfBirth, address, height, weight)
        {
            if (studentId.Length != 10)
                throw new ArgumentException("Student ID must be exactly 10 characters long.");
            this.StudentId = studentId;
            if (string.IsNullOrEmpty(university) || university.Length > 200)
                throw new ArgumentException("University name must be non-empty and less than 200 characters.");
            this.University = university;
            if (yearStarted < 1900)
                throw new ArgumentException("Year started must be after 1900.");
            this.YearStarted = yearStarted;
            if (gpa < 0.0f || gpa > 10.0f)
                throw new ArgumentException("GPA must be between 0.0 and 10.0.");
            this.GPA = gpa;
            HanhKiem = calculateHocluc(gpa);
        }

        public Student()
        {
        }
        public override string ToString()
        {
            return base.ToString() + $", Student [StudentID={StudentId}, University={University}, YearStarted={YearStarted}, GPA={GPA}, Học lực={GetHocLuc()}]";
        }
        public HocLuc calculateHocluc(float GPA)
        {
            if (GPA < 3) return HocLuc.Kem;
            else if (GPA >= 3 && GPA < 5) return HocLuc.Yeu;
            else if (GPA >= 5 && GPA < 6.5) return HocLuc.TrungBinh;
            else if (GPA >= 6.5 && GPA < 7.5) return HocLuc.Kha;
            else if (GPA >= 7.5 && GPA < 9) return HocLuc.Gioi;
            else return HocLuc.XuatSac;
        }

    }
}
