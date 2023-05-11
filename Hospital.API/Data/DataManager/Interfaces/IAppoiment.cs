using Hospital.API.Models.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface IAppoiment
    {
        IEnumerable<Appoiment> appoiments { get; }

        void addAppoiment(Appoiment appoiment);

        void removeAppoiment(Appoiment appoiment);


    }
}
