using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface ICase
    {
        IEnumerable<Case> cases { get; }

        Case getCaseById(Guid id);
    }
}
