using StudentManagement.Core.IRepository;
using StudentManagement.Core.IService;
using StudentManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public class StudentServices:IStudentServices
    {
        #region Declaration 
        private readonly IStudentRepository studentRepository;
        #endregion

        #region constructor
        public StudentServices(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        #endregion

        #region Create
        public void CreateDetail(StudentModel studentModel)
        {
            studentRepository.CreateDetail(studentModel);
        }
        #endregion

        #region Read(List)
        public List<StudentModel>ListDetail()
        {
            return studentRepository.ListDetail();
        }
        #endregion

        #region Update(Edit)
        public StudentModel EditDetail(int StudentID)
        {
             return studentRepository.EditDetail(StudentID);
        }
        #endregion

        #region Delete
        public void DeleteDetail(int StudentID)
        {
            studentRepository.DeleteDetail(StudentID);
        }
        #endregion
    }
}
