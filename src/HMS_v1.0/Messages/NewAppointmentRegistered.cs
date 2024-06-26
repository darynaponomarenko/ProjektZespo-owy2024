using HMS_v1._0.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.Messages
{
    public class NewAppointmentRegistered
    {
        public RegistrationModel RegistrationModel { get;}

        public NewAppointmentRegistered(RegistrationModel model)
        {
            RegistrationModel = model;
        }
    }
}
