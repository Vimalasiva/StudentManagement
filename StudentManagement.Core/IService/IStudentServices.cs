using StudentManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.IService
{
    public interface IStudentServices
    {
       public  void CreateDetail(StudentModel studentModel);
        List<StudentModel> ListDetail();
        public StudentModel EditDetail(int id);
        public void DeleteDetail(int id);
    }
}
