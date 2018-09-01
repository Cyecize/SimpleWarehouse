using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Model;
using SimpleWarehouse.Util;
using static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Revenues
{
    class RevenuesDbService : IRevenueStreamDbService
    {
        private const string CannotCreateRevenueStream = "Имаше проблем със създаването";

        public RevenuesDbService()
        {

        }

        public void Archive()
        {
            foreach (var revenue in Database.Revenues.AsNoTracking().Where(e => !e.IsRevised).ToList())
                revenue.IsRevised = true;
            Database.SaveChanges();
        }

        public RevenueStream CreateRevenueStream(RevenueStream revenueStream)
        {
            try
            {
                Revenue revenue = new ModelMerger().Merge(revenueStream, new Revenue());
                Database.Revenues.Add(revenue);
                Database.SaveChanges();
                return revenue;
            }
            catch (Exception) { throw new ArgumentException(CannotCreateRevenueStream);}
        }

        public List<RevenueStream> FindAll()
        {
            return new List<RevenueStream>(Database.Revenues.AsNoTracking());
        }

        public List<RevenueStream> FindAllNonRevised()
        {
            return new List<RevenueStream>(Database.Revenues.AsNoTracking().Where(r=>r.IsRevised == false));
        }

        public List<RevenueStream> FindAllArchived()
        {
            return new List<RevenueStream>(Database.Revenues.Where(r=>r.IsRevised));
        }

        public List<RevenueStream> FindAllArchived(DateTime start, DateTime end)
        {
            return new List<RevenueStream>(Database.Revenues.Where(e => e.IsRevised && e.Date >= start && e.Date <= end));
        }
    }
}
