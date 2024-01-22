using HMS_v1._0.models;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.Messages
{
    public class AppointmentUpdated
    {
        public RegistrationModel RegistrationModel { get; }

        public AppointmentUpdated(RegistrationModel model)
        {
            RegistrationModel = model;
        }
    }
}
