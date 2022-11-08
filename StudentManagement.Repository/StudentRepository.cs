using StudentManagement.Core.IRepository;
using StudentManagement.Core.Model;
using StudentManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repository
{
    public  class StudentRepository:IStudentRepository
    {
        Student_ManagementContext entity= new Student_ManagementContext();

        #region Create and update(Edit)
        public void CreateDetail(StudentModel studentModel)
        {
            if(studentModel!=null)
            {
                if(studentModel.StudentID==0)
                {
                    StudentDetail_Table studentDetail_Table = new StudentDetail_Table();
                    studentDetail_Table.First_Name = studentModel.FirstName;
                    studentDetail_Table.Last_Name = studentModel.LastName;
                    studentDetail_Table.Student_Age = studentModel.Age; 
                    studentDetail_Table.Gender_of_Student = studentModel.Gender;
                    studentDetail_Table.Pursuing_Department = studentModel.Department;
                    studentDetail_Table.Student_Class = studentModel.Standard;
                    studentDetail_Table.Student_Location = studentModel.Location;
                    studentDetail_Table.Year_Of_Joining = DateTime.Parse(studentModel.year);
                    entity.Add(studentDetail_Table);
                    entity.SaveChanges();
                }
                else
                {
                    var edit=entity.StudentDetail_Table.Where(check=>check.Student_ID==studentModel.StudentID).FirstOrDefault();
                    if(edit!=null)
                    {
                        edit.First_Name = studentModel.FirstName;
                        edit.Last_Name = studentModel.LastName;
                        edit.Student_Age = studentModel.Age;
                        edit.Gender_of_Student = studentModel.Gender;
                        edit.Pursuing_Department = studentModel.Department;
                        edit.Student_Class = studentModel.Standard;
                        edit.Student_Location = studentModel.Location;
                        edit.Year_Of_Joining= DateTime.Parse(studentModel.year);
                        entity.SaveChanges();
                    }
                }

            }
        }
        #endregion

        #region Read(List)
        public List<StudentModel> ListDetail()
        {
            List<StudentModel> studentList = new List<StudentModel>();
            var List=entity.StudentDetail_Table.Where(detail=>detail.Is_Deleted==false).ToList();
            if(List!=null)
            {
                foreach(var i in List)
                {
                    StudentModel studentModel= new StudentModel();
                    studentModel.StudentID = i.Student_ID;
                    studentModel.FirstName = i.First_Name;
                    studentModel.LastName = i.Last_Name;
                    studentModel.Age = i.Student_Age;
                    studentModel.Gender = i.Gender_of_Student;
                    studentModel.Department = i.Pursuing_Department;
                    studentModel.Standard = i.Student_Class;
                    studentModel.Location = i.Student_Location;
                    studentModel.year= i.Year_Of_Joining.ToString("yyyy/MM/dd");
                    studentList.Add(studentModel);
                }
            }
            return studentList;
        }
        #endregion

        #region Save logic for update(edit)
        public StudentModel EditDetail(int studentID)
        {
            StudentModel model = new StudentModel();
            var Edit = entity.StudentDetail_Table.Where(edit => edit.Student_ID == studentID).SingleOrDefault();
            if(Edit!=null)
            {
                model.StudentID = Edit.Student_ID;
                model.FirstName = Edit.First_Name;
                model.LastName = Edit.Last_Name;
                model.Age = Edit.Student_Age;
                model.Gender = Edit.Gender_of_Student;
                model.Department = Edit.Pursuing_Department;
                model.Standard= Edit.Student_Class;
                model.Location = Edit.Student_Location;
                model.year = Edit.Year_Of_Joining.ToString("yyyy/MM/dd");
            }
            return model;
        }
        #endregion

        #region Delete
        public void DeleteDetail(int studentID)
        {
            var Delete = entity.StudentDetail_Table.Where(delete => delete.Student_ID == studentID).SingleOrDefault();
            if(Delete!=null)
            {
                Delete.Is_Deleted = true;
                entity.SaveChanges();
            }
        }
        #endregion
    }

}
