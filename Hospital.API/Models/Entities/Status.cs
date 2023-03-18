using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Models.Entities
{
    //Статус для лікаря в лікарні
    public class Status
    {
        [Key]
        public int id { get; set; }
        public string status { get; set; }
    }
}
