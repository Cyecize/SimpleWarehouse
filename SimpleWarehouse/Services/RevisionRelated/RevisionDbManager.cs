using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.RevisionRelated
{
    public class RevisionDbManager : IRevisionDbManager
    {
        private const string TABLE_NAME = "revisions";

        private IEntityRepository<Revision> RevisionRepo { get; set; }

        public IMySqlManager SqlManager { get; set; }

        public RevisionDbManager(IMySqlManager sqlManager)
        {
            this.SqlManager = sqlManager;
            this.RevisionRepo = new EntityRepo<Revision>(sqlManager, new ConsoleWriter());
        }

        public void CreateRevision(Revision revision)
        {
            string query = $"INSERT INTO {TABLE_NAME} VALUES " +
                $"(" +
                $"null, " +
                $"{revision.Expenses}, " +
                $"{revision.Revenue}, " +
                $"{revision.ActualRevenue}, " +
                $"'{revision.StartDate.ToString("yyyy-MM-dd hh:mm:ss")}', " +
                $"'{revision.Date.ToString("yyyy-MM-dd hh:mm:ss")}'" +
                $")";
            this.SqlManager.InsertQuery(query);
        }

        public List<Revision> FindAfterDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Revision> FindAll()
        {
            return this.RevisionRepo.FindManyByQuery($"SELECT * FROM {TABLE_NAME} ORDER BY revision_date"); 
        }

        public Revision FindOneById(int id)
        {
            return this.RevisionRepo.FindOneBy("id", id);
        }
    }
}
