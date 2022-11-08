using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using StudentManagement.Core.Model;
using StudentManagement.Entity;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        Student_ManagementContext student = new Student_ManagementContext();

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
     
        public IActionResult Create(StudentModel studentModel)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7162/api/StudentAPI/Create");
                var create = client.PostAsJsonAsync<StudentModel>(client.BaseAddress, studentModel);
                create.Wait();
                var check = create.Result;
                if (check.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }

            }
            return RedirectToAction("List");
        }
        #endregion

        #region Read(List)
        public IActionResult List()
        {
            IList<StudentModel>? student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7162/api/StudentAPI/List");
                var List = client.GetAsync(client.BaseAddress);
                List.Wait();
                var check = List.Result;
                if (check.IsSuccessStatusCode)
                {
                    var list = check.Content.ReadFromJsonAsync<IList<StudentModel>>();
                    list.Wait();
                    student = list.Result;
                }
                List<StudentModel> SortedDetail = student.OrderBy(sort => sort.FirstName).ToList();
                return View(SortedDetail);
            }
        }
        #endregion

        #region Update(Edit)
        public IActionResult Edit(int StudentID)
        {
            StudentModel? studentModel = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7162/api/StudentAPI/Edit?id=");
                var Edit = client.GetAsync(client.BaseAddress+StudentID.ToString());
                Edit.Wait();
                var check = Edit.Result;
                if (check.IsSuccessStatusCode)
                {
                    var edit = check.Content.ReadFromJsonAsync<StudentModel>();
                    edit.Wait();
                    studentModel = edit.Result;
                }
            }
            return View("Create", studentModel);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int StudentID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7162/api/StudentAPI/Delete?id=");
                var Delete= client.DeleteAsync(client.BaseAddress + StudentID.ToString());
                Delete.Wait();
                var delete = Delete.Result;
                if (delete.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
        #endregion
    }
}

