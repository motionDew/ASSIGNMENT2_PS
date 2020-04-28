using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment2.Data;
using assignment2.Models;
using Microsoft.AspNetCore.Authorization;
using assignment2.Services;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private AppointmentService _service;
        public AppointmentsController(AutoServiceDbContext context)
        {
            _service = new AppointmentService(context);
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var appointments = _service.Get();
            return View(appointments);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string SearchString, bool notUsed )
        {   
            var appointments = _service.Get(SearchString);

            if (String.IsNullOrEmpty(SearchString))
            {
                return View(Enumerable.Empty<Appointment>());
            }
            return View(appointments);
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = _service.Get(id);
              
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,date,clientName,telephoneNo,carBrand,description,status")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                if (_service.Add(appointment) == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"That time is already reserved");
                }
            }
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var appointment = _service.Get(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,date,clientName,telephoneNo,carBrand,description,status")] Appointment appointment)
        {

            if (id != appointment.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.Update(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = _service.Get(id);
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           Appointment  appointment = _service.Get(id);
            _service.Delete(appointment.id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Report(string date1 = "2020-03-01T11:11", string date2= "2020-12-01T11:11")
        {
            var dateAppointments = _service.Get(DateTime.Parse(date1), DateTime.Parse(date2));
            return View(dateAppointments);
        }
    }
}

