using Microsoft.AspNetCore.Mvc;
using StudentManagement.Core.IService;
using StudentManagement.Core.Model;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class StudentAPIController : Controller
    {
        #region Declaration
        private readonly IStudentServices studentServices;
        #endregion

        #region Constructor
        public StudentAPIController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }
        #endregion

        #region Create new student detail
        [HttpPost]
        public IActionResult Create(StudentModel studentModel)
        {
            studentServices.CreateDetail(studentModel);
            return Ok(studentModel);
        }
        #endregion

        #region Read(List) details of students
        [HttpGet]
        public IActionResult List()
        {
            var Read=studentServices.ListDetail();
            return Ok(Read);

        }
        #endregion

        #region Update(Edit) details of students
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Update = studentServices.EditDetail(id);
            return Ok(Update);
        }
        #endregion

        #region Delete details of students
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            studentServices.DeleteDetail(id);
            return Ok();
        }
        #endregion
    }
}
