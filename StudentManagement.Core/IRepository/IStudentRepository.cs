using StudentManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.IRepository
{
    public  interface IStudentRepository
    {
        public void CreateDetail(StudentModel studentModel);
        List<StudentModel> ListDetail();
        public StudentModel EditDetail(int studentID);
        public void DeleteDetail(int studentID);
    }
}
