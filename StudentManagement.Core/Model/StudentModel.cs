using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Model
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Standard { get; set; }
        public DateTime YearOfJoining { get; set; }
        public string Location { get; set; }
        public string? year { get; set; }
    }
}
