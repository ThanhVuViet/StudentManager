using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaiTap.Student;

namespace BaiTap.StudentService
{
    internal class StudentManageService
    {
        static int maxStudents = 10;
        Student[] students = new Student[maxStudents];
        int currentNumberOfStudents = 0;
        List<Student> ArrayListStudents = new List<Student>();
        Dictionary<String, float> PhanTramHocLuc = new Dictionary<String, float>();
        Dictionary<float, float> PhanTramDiem = new Dictionary<float, float>();
        Dictionary<String, List<Student>> XepHocLuc = new Dictionary<string, List<Student>>();


        public void createStudent()
        {
            if (currentNumberOfStudents >= maxStudents)
            {
               
                Console.WriteLine("Cannot add more students. Maximum capacity reached.");
                return;
            }

            try
            {
               
                Console.WriteLine("Enter name of student:");
                string name = Console.ReadLine();

                
                Console.WriteLine("Enter birth date (yyyy-mm-dd):");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());

               
                Console.WriteLine("Enter address:");
                string address = Console.ReadLine();

               
                Console.WriteLine("Enter height (cm):");
                double height = double.Parse(Console.ReadLine());

               
                Console.WriteLine("Enter weight (kg):");
                double weight = double.Parse(Console.ReadLine());

              
                Console.WriteLine("Enter student ID:");
                string studentId = Console.ReadLine();

              
                Console.WriteLine("Enter university:");
                string university = Console.ReadLine();

               
                Console.WriteLine("Enter year started:");
                int yearStarted = int.Parse(Console.ReadLine());

              
                Console.WriteLine("Enter GPA:");
                float gpa = float.Parse(Console.ReadLine());

               
                Student newStudent = new Student(
                    currentNumberOfStudents + 1, 
                    name, birthDate, address, height, weight,
                    studentId, university, yearStarted, gpa);

                
                students[currentNumberOfStudents] = newStudent;
                currentNumberOfStudents++;

                Console.WriteLine("Student added successfully:");
                Console.WriteLine(newStudent.ToString());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please try again.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        public void readStudentById(int id)
        {
            for (int i = 0; i < currentNumberOfStudents; i++)
            {
                if (students[i].Id == id)
                {
                    Console.WriteLine("Student found:");
                    Console.WriteLine(students[i].ToString());
                    return;
                }
            }
            Console.WriteLine("No student with the given ID was found.");
        }
        public void updateStudentById(int id)
        {
            for (int i = 0; i < currentNumberOfStudents; i++)
            {
                if (students[i].Id == id)
                {
                    Console.WriteLine("Student found. Enter new details:");

                    try
                    {
                    
                        Console.WriteLine("Enter new name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter new birth date (yyyy-mm-dd):");
                        DateTime birthDate = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Enter new address:");
                        string address = Console.ReadLine();

                        Console.WriteLine("Enter new height (cm):");
                        double height = double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter new weight (kg):");
                        double weight = double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter new student ID:");
                        string studentId = Console.ReadLine();

                        Console.WriteLine("Enter new university:");
                        string university = Console.ReadLine();

                        Console.WriteLine("Enter new year started:");
                        int yearStarted = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter new GPA:");
                        float gpa = float.Parse(Console.ReadLine());

                      
                        students[i].Name = name;
                        students[i].DateOfBirth = birthDate;
                        students[i].Address = address;
                        students[i].Height = height;
                        students[i].Weight = weight;
                        students[i].StudentId = studentId;
                        students[i].University = university;
                        students[i].YearStarted = yearStarted;
                        students[i].GPA = gpa;

                      
                        Console.WriteLine("Student updated successfully:");
                        Console.WriteLine(students[i].ToString());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Invalid input format. Please try again.");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }

                    return;
                }
            }
            Console.WriteLine("No student with the given ID was found.");
        }
        public void deleteStudentById(int id)
        {
            bool found = false;
            for (int i = 0; i < currentNumberOfStudents; i++)
            {
                if (students[i].Id == id)
                {
                    found = true;
                  
                    for (int j = i; j < currentNumberOfStudents - 1; j++)
                    {
                        students[j] = students[j + 1];
                    }
                  
                    students[currentNumberOfStudents - 1] = null;
                    currentNumberOfStudents--;  
                    Console.WriteLine($"Student with ID {id} has been deleted.");
                    return;
                }
            }
            if (!found)
            {
                Console.WriteLine("No student with the given ID was found.");
            }
        }
        public void createStudentFlexible ()
        {
            if (ArrayListStudents.Count >= maxStudents)
            {

                Console.WriteLine("Cannot add more students. Maximum capacity reached.");
                return;
            }
            try
            {
              
                Console.WriteLine("Enter name of student:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter birth date (yyyy-mm-dd):");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter address:");
                string address = Console.ReadLine();

                Console.WriteLine("Enter height (cm):");
                double height = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter weight (kg):");
                double weight = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter student ID:");
                string studentId = Console.ReadLine();

                Console.WriteLine("Enter university:");
                string university = Console.ReadLine();

                Console.WriteLine("Enter year started:");
                int yearStarted = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter GPA:");
                float gpa = float.Parse(Console.ReadLine());

               
                Student newStudent = new Student(
                    ArrayListStudents.Count + 1, 
                    name, birthDate, address, height, weight,
                    studentId, university, yearStarted, gpa
                );

                ArrayListStudents.Add(newStudent);  

                Console.WriteLine("Student added successfully:");
                Console.WriteLine(newStudent.ToString());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please try again.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        public void deleteStudentByIdFlexible(int id)
        {
            bool found = false;

            for (int i = 0; i < ArrayListStudents.Count; i++)
            {
                Student student = (Student)ArrayListStudents[i];
                if (student.Id == id)
                {
                    found = true;
                    ArrayListStudents.RemoveAt(i);  
                    Console.WriteLine($"Student with ID {id} has been deleted.");
                    return;
                }
            }

            if (!found)
            {
                Console.WriteLine("No student with the given ID was found.");
            }
        }
        public void xepHocLuc()
        {
            
           List<Student> students = GetStudents();
            int NumberOfStudent = students.Count;
           foreach (var student in students) {
                string HocLuc = student.GetHocLuc().ToString();
                if (!PhanTramHocLuc.ContainsKey(HocLuc))
                {
                    PhanTramHocLuc[HocLuc] = 0;
                }
                else
                {
                    PhanTramHocLuc[HocLuc] += 1/ NumberOfStudent * 100;
                }
            }
            Console.WriteLine("Phần trăm học lực:");
            foreach (var entry in PhanTramHocLuc)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}%");
            }
        }
        public Dictionary<float,float> xepDiem ()
        {
            List<Student> students = GetStudents();
            int NumberOfStudent = students.Count;
            foreach(var student in students)
            {
                float diem = student.GPA;
                if (!PhanTramDiem.ContainsKey(diem))
                {
                    PhanTramDiem[diem] = 0;
                }
                else
                {
                    PhanTramDiem[diem] += 1 / NumberOfStudent * 100;
                }

            }
            var sortedPhanTramDiem = PhanTramDiem.OrderByDescending(x => x.Value)
                                        .ToDictionary(x => x.Key, x => x.Value);
            return PhanTramDiem;
        }
        public List<Student> GetStudents () { 
            return ArrayListStudents;
        }
        public void XepSinhVienHocLuc()
        {
            List<Student> studens = GetStudents();
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
        public void SaveStudentsToFile(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var student in ArrayListStudents)
                    {
                        
                        sw.WriteLine(student.ToString());
                    }
                }
                Console.WriteLine("Student list has been saved to the file.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving to file: " + e.Message);
            }
        }
    }
        


    }

