
using System;
using System.IO;
using System.Text;

namespace MemoryStreamExample
{
    class Program
    {
        const int idOffset = 0;
        const int idLength = 16;

        const int firstNameOffset = 16;
        const int firstNameLength = 40;

        const int lastNameOffset = 56;
        const int lastNameLength = 40;

        const int salaryOffset = 96;
        const int salaryLength = 20;

        const int genderOffset = 116;
        const int genderLength = 4;

        const int isManagerOffset = 120;
        const int isManagerLength = 16;

        const int recordLength = idLength + firstNameLength + lastNameLength + salaryLength + genderLength + isManagerLength;
      
        static void Main(string[] args)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

            MemoryStream ms = new MemoryStream(recordLength);

            SeedData(unicodeEncoding, ms);

            ms.Seek(0,SeekOrigin.Begin);

            Console.WriteLine("Employee Record Before Promotion");
            Console.WriteLine("--------------------------------");

            Console.WriteLine($"ID: {GetField(unicodeEncoding,ms,idLength)}");
            Console.WriteLine($"FirstName: {GetField(unicodeEncoding, ms, firstNameLength)}");
            Console.WriteLine($"LastName: {GetField(unicodeEncoding, ms, lastNameLength)}");
            Console.WriteLine($"Salary: {GetField(unicodeEncoding, ms, salaryLength)}");
            Console.WriteLine($"Gender: {GetField(unicodeEncoding, ms, genderLength)}");
            Console.WriteLine($"Manager: {GetField(unicodeEncoding, ms, isManagerLength)}");

            Console.WriteLine("Press any key to update the employee's record");
            Console.ReadKey();
            Console.WriteLine("");

            ms.Seek(0,SeekOrigin.Begin);

            UpdateSalary(unicodeEncoding, ms, 80000);
            UpdateIsManager(unicodeEncoding, ms, true);

            ms.Seek(0,SeekOrigin.Begin);

            Console.WriteLine("Employee Record after Promotion");
            Console.WriteLine("--------------------------------");

            Console.WriteLine($"ID: {GetField(unicodeEncoding, ms, idLength)}");
            Console.WriteLine($"FirstName: {GetField(unicodeEncoding, ms, firstNameLength)}");
            Console.WriteLine($"LastName: {GetField(unicodeEncoding, ms, lastNameLength)}");
            Console.WriteLine($"Salary: {GetField(unicodeEncoding, ms, salaryLength)}");
            Console.WriteLine($"Gender: {GetField(unicodeEncoding, ms, genderLength)}");
            Console.WriteLine($"Manager: {GetField(unicodeEncoding, ms, isManagerLength)}");
        }

        private static void SeedData(UnicodeEncoding unicodeEncoding, MemoryStream ms) 
        {
            int id = 1003;
            string firstName = "John";
            string lastName = "Jenkins";
            decimal salary = 60000;
            char gender = 'm';
            bool isManager = false;

            string employeeRecord = id.ToString().PadRight(idLength / 2) + firstName.PadRight(firstNameLength/2) + lastName.PadRight(lastNameLength/2) + salary.ToString().PadRight(salaryLength/2) + gender.ToString().PadRight(genderLength/2) + isManager.ToString().PadRight(isManagerLength/2);

            byte[] employeeData = unicodeEncoding.GetBytes(employeeRecord);

            ms.Write(employeeData, 0, employeeRecord.Length * 2);
        }

        private static string GetField(UnicodeEncoding ue, MemoryStream ms, int length)
        {
            ms.Seek(0, SeekOrigin.Current);

            byte[] byteArray = new byte[length];

            int count = ms.Read(byteArray, 0, length);

            string fieldValue = new string(ReturnCharArrayFromBytrArray(ue, byteArray, count));

            return fieldValue.Trim();
        }

        private static char[] ReturnCharArrayFromBytrArray(UnicodeEncoding ue, byte[] byteArray, int count)
        {
            char[] charArray = new char[ue.GetCharCount(byteArray, 0, count)];

            ue.GetDecoder().GetChars(byteArray, 0, count, charArray, 0);

            return charArray;
        }

        private static void Updatefield(UnicodeEncoding ue, MemoryStream ms, int offSet, int length, string newValue)
        {
            byte[] data = ue.GetBytes(newValue);

            ms.Seek(offSet, SeekOrigin.Begin);
            ms.Write(data, 0, length);
        }

        private static void UpdateIsManager(UnicodeEncoding ue, MemoryStream ms, bool isManager)
        {
            string newValue = isManager.ToString().PadRight(salaryLength/2);

            Updatefield(ue, ms, isManagerOffset, isManagerLength, newValue);
        }

        private static void UpdateSalary(UnicodeEncoding ue, MemoryStream ms, decimal salary)
        {
            string newValue = salary.ToString().PadRight(salaryLength/2);

            Updatefield(ue,ms, salaryOffset, salaryLength, newValue);
        }
    }
}
