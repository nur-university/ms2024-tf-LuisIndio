using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain.Abstractions;

namespace Domain.Model
{
    public class Consultation : AggregateRoot
    {
        public Guid AppointmentId { get; private set; }
        public Guid PatientId { get; private set; }
        public String Status { get; private set; }
        public DateTime Date { get; private set; }
        public Guid Nutritionist { get; private set; }

        public Consultation(Guid id, Guid appointmentId, Guid patientId, string status, DateTime date, Guid nutritionist)
        {
            Id = id;
            AppointmentId = appointmentId;
            PatientId = patientId;
            Status = status;
            Date = date;
            Nutritionist = nutritionist;
        }
    }
}
