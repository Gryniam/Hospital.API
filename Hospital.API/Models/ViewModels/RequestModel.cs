using Microsoft.AspNetCore.Http;

namespace Hospital.API.Models.ViewModels
{
    public class RequestModel
    {
        public string specialityName { get; set; } 
        public IFormFile file { get; set; }
    }
}
