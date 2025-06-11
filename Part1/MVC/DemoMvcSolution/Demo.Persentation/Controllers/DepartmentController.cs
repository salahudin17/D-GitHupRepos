//using Demo.BusniessLogicLayer.Services;
using Demo.BusniessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Models;
using Demo.DataAccessLayer.Rebositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Persentation.Controllers
{
    public class DepartmentController :Controller
    {
        //private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
           // _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }
        #region Actions
        public async Task<IActionResult> Index()
        {
            var department = await _unitOfWork.DepartmentRepository.GetALLAsync();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)//Server Side Validation
            {
                 await _unitOfWork.DepartmentRepository.AddAsync(department);
                int res = await _unitOfWork.CompleteAsync();
                if (res > 0)
                {
                    TempData["Message"] = "Department Is Created";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        public async Task <IActionResult> Details(int?id,string ViewName="Details")
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(id.Value);
            _unitOfWork.CompleteAsync();
            if (department is null)
            {
                return NotFound();
            }
            return View(ViewName,department);
        }
        [HttpGet]
        public async Task <IActionResult> Edit(int? id)
        {

            return await Details(id, "Edit");
            
        }
        [HttpPost]
        public  IActionResult Edit(Department department, [FromRoute]int id)
        {
            if (ModelState.IsValid)
                try
                {
                    _unitOfWork.DepartmentRepository.Update(department);
                    _unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            return View(department);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            return  await Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(Department department,int? id)
        {
            if (id!=department.Id)
            {
                return BadRequest();

            }
            try 
            {
                _unitOfWork.DepartmentRepository.Delete(department);
                _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(department);
            }

        }
        #endregion
    }
}
