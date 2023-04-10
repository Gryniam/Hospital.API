using Hospital.API.Models.Entities;
namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface IHospital
    {
        Models.Entities.Hospital getHospitalByCase(Case insertedCase);
    }
}
