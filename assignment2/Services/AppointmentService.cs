using assignment2.Data;
using assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2.Services
{


    public class AppointmentService
    {
        private UnitOfWork unitOfWork;

        public AppointmentService(AutoServiceDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }
        public bool Add(Appointment appointment)
        {
            var appRepository = unitOfWork.AppointmentRepository;

            bool alreadyExists = appRepository.Get().Any(a => a.date == appointment.date);

            Console.WriteLine(appointment.date);

            if (alreadyExists == false)
            {
                appRepository.Create(appointment);
                unitOfWork.Save();
            }
            else
            {
                return false;
            }
            return true;
        }
        public void Update(Appointment appointment)
        {
            var appointmentRep = unitOfWork.AppointmentRepository;
           
            appointmentRep.Update(appointment);
            unitOfWork.Save();
          
        }
        public void Delete(int id)
        {
            unitOfWork.AppointmentRepository.Delete(id);
            unitOfWork.Save();
        }
        private bool AppointmentExists(int id)
        {
            return unitOfWork.AppointmentRepository.Get().Any(e => e.id == id);
        }

        public IEnumerable<Appointment> Get(DateTime d1, DateTime d2)
        {
            var appRepository = unitOfWork.AppointmentRepository;
            return appRepository.Get().Where(entry => entry.date >= d1 && entry.date <= d2);
        }

        public IEnumerable<Appointment> Get(string searchString)
        {
            var appRepository = unitOfWork.AppointmentRepository;
            var appointments = appRepository.Get().Where(a => a.clientName.Contains(searchString));

            return appointments;
        }
        public IEnumerable<Appointment> Get()
        {
            var appRepository = unitOfWork.AppointmentRepository;
            var appointments = appRepository.Get();
            return appointments;
        }
        public Appointment Get(int id)
        {
            var appRepository = unitOfWork.AppointmentRepository;
            var appointment = appRepository.GetById(id);
            return appointment;
        }
    }

}
