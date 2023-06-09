﻿using System;
using System.IO;

namespace Hospital.API.Models.ViewModels
{
    public class RegistrationModel
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string middleName { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public string gender { get; set; }
        public string birthDate { get; set; }
        public string phoneNumber { get; set; }

        public string settlementName { get; set; }
    }
}
