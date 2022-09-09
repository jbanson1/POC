using System;
using System.Collections.Generic;
using System.IO;

namespace TestingBaseImage
{
    internal class Program
    {
        // Use if statement to differenciate between the file types and limit the image
        //types on the front end. 

        static void Main(string[] args)
        {
            string base64String = File.ReadAllText(@"C:\samples\base64Image.txt");
            byte[] imgBytes = Convert.FromBase64String(base64String);

            using (var imageFile = new FileStream(@"C:\samples\sample.png", FileMode.Create))
            {
                imageFile.Write(imgBytes, 0, imgBytes.Length);
                imageFile.Flush();
            }
        }
    }
}
