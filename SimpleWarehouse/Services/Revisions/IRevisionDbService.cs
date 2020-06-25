using System;
using System.Collections.Generic;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Revisions
{
    public interface IRevisionDbService
    {
        void CreateRevision(Revision revision);

        Revision FindOneById(int id);

        List<Revision> FindAll();

        List<Revision> FindAfterDate(DateTime date);
    }
}