using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface ITime
    {
        Time getTimeById(Guid id);

        IEnumerable<Time> getTimeTable { get; }

        IEnumerable<Times> getTimesTable { get;}
    }
}
