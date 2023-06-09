﻿using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace Hospital.API.Models.ViewModels
{
    public class UserProfileModel
    {
        public Guid patientId { get; set; }
        public string surName { get; set; }

        public string name { get; set; }

        public string middleName { get; set; }

        public int age { get; set; }

        public string gender { get; set; }

        public bool isAdmin { get; set; }

        public string base64StringPhoto { get; set; }

    }

}
