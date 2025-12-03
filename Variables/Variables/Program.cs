using System;
using System.Globalization;

namespace Program
{
    public class Student
    {
        // NO private fields needed here. 
        // These are "Auto-Properties" - they handle their own internal storage.
        public int StuId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal LoanAmount { get; set; } // 'set' is public so you can update it later
        public char Gender { get; set; }
        public bool IsNew { get; set; }

        public Student(int stuId, string firstName, string lastName, decimal loanAmount, char gender, bool isNew)
        {
            StuId = stuId;
            FirstName = firstName;
            LastName = lastName;
            LoanAmount = loanAmount;
            Gender = gender;
            IsNew = isNew;
        }

        public string GetStudentData()
        {
            return $"stuId: {StuId}, firstName: {FirstName}, loan Amount: {LoanAmount}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Clean declaration + assignment in one step
            Console.WriteLine("Please enter the student Id");
            int stuId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the student's first name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Please enter the student's last name");
            string lastName = Console.ReadLine();

            Console.WriteLine("Please enter the student's loan amount");
            decimal loanAmount = Decimal.Parse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);

            Console.WriteLine("Please enter the student's gender ('f' = female, 'm' = male)");
            char gender = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("The student is new (true/false)");
            bool isNew = Convert.ToBoolean(Console.ReadLine());

            // Create the object
            Student student = new Student(stuId, firstName, lastName, loanAmount, gender, isNew);
            Console.WriteLine();

            string studentData = student.GetStudentData();
            Console.WriteLine(studentData);
        }
    }
}