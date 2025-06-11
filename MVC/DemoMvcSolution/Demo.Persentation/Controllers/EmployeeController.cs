using AutoMapper;
using Demo.BusniessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Models;
using Demo.DataAccessLayer.Rebositories;
using Demo.Persentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Demo.Persentation.Controllers
{
    public class EmployeeController:Controller
    {
        //private readonly IEmployeeRepository _unitOfWork.EmployeeRepository;
        //private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            //_unitOfWork.EmployeeRepository = employeeRepository;
            //_departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #region Actions
        public async Task<IActionResult> Index(string SearchValue)
        {
            IEnumerable<Employee> employees;
           // var employee = _unitOfWork.EmployeeRepository.GetALLAsync();
            if (string.IsNullOrEmpty(SearchValue))
            {
                employees =  await _unitOfWork.EmployeeRepository.GetALLAsync();
               
            }
            else
            {
                employees = await _unitOfWork.EmployeeRepository.GetEmployeesByName(SearchValue);
            }

            var MappedEmployee = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(MappedEmployee);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var departments = await _unitOfWork.DepartmentRepository.GetALLAsync();
            ViewBag.Department = new SelectList(departments, "Id", "Name");
            return View();
        }


        [HttpPost]
        #region Another Way
        //public IActionResult Create(EmployeeViewModel employeeView)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
        //        // Debug: اطبعهم في اللوج أو راقبهم
        //    }

        //    ViewBag.Department = _unitOfWork.DepartmentRepository.GetALL();

        //    if (ModelState.IsValid)
        //    {
        //        var mappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeView);
        //        _unitOfWork.EmployeeRepository.Add(mappedEmployee);
        //        int result = _unitOfWork.Complete();

        //        if (result > 0)
        //        {
        //            TempData["Message"] = "Employee Is Created";
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }

        //    return View(employeeView);
        //}
        #endregion
        
        public async Task<IActionResult> Create(EmployeeViewModel employeeView)
        {
            if (ModelState.IsValid)
            {
                var MappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeView);
                await _unitOfWork.EmployeeRepository.AddAsync(MappedEmployee);
                int result = await _unitOfWork.CompleteAsync();
                if (result > 0)
                {
                    TempData["Message"] = "Employee Is Created";
                    return RedirectToAction(nameof(Index));
                }
            }
            var departments = await _unitOfWork.DepartmentRepository.GetALLAsync();
            ViewBag.Department = new SelectList(departments, "Id", "Name");
            return View(employeeView);


            //var departments = _unitOfWork.DepartmentRepository.GetALL();
            // ViewBag.Department = new SelectList(departments, "Id", "Name");
            //return View(employeeView);
        }
        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id.Value);
            if (employee is null)
                return NotFound();
            var MappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(ViewName, MappedEmployee);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            
            return await Details(id, "Edit");

        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeView, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeView);
                    _unitOfWork.EmployeeRepository.Update(MappedEmployee);
                    _unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            // 🔁 إعادة تحميل الأقسام
            var departments = await _unitOfWork.DepartmentRepository.GetALLAsync();
            if (ViewBag.Department != null)
            {
                 ViewBag.Department = new SelectList(departments, "Id", "Name");
               
            }
            
            return View(employeeView);
        }


        public async Task<IActionResult> Delete(int? id)
        {

            return await Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(EmployeeViewModel employeeView, [FromRoute]int? id)
        {
            if (id != employeeView.Id)
            {

                return BadRequest();

            }
            try
            {
                var MappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeView);
                _unitOfWork.EmployeeRepository.Delete(MappedEmployee);
                _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(employeeView);
            }

        }
        #endregion
    }
}
