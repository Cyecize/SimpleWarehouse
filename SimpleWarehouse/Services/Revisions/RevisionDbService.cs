using System;
using System.Collections.Generic;
using System.Linq;
using SimpleWarehouse.Model;
using static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Revisions
{
    public class RevisionDbService : IRevisionDbService
    {
        public void CreateRevision(Revision revision)
        {
            Database.Revisions.Add(revision);
        }

        public Revision FindOneById(int id)
        {
            return Database.Revisions.FirstOrDefault(r => r.Id == id);
        }

        public List<Revision> FindAll()
        {
            return new List<Revision>(Database.Revisions);
        }

        public List<Revision> FindAfterDate(DateTime date)
        {
            return new List<Revision>(Database.Revisions.Where(r => r.RevisionDate >= date));
        }
    }
}