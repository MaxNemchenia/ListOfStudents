using System.Collections.Generic;
using System.Xml.Linq;
using TexodeTask.Model;

namespace TexodeTask
{
    public static class XMlReader
    {
        public static IEnumerable<Student> readStudents(string path)
        {
            var xd = XDocument.Load(path);

            foreach (var xe in xd.Root.Elements("Student"))
            {
                var id = (int)xe.Attribute("Id");
                var firstName = (string)xe.Element("FirstName");
                var lastName = (string)xe.Element("Last");
                var age = (int)xe.Element("Age");
                var gender = (int)xe.Element("Gender");
                yield return new Student
                {
                    Id = id,
                    Age = age,
                    FirstName = firstName,
                    Last = lastName,
                    Gender = (Gender)gender
                };
            }
        }
    }
}
