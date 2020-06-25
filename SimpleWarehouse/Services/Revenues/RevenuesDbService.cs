using System;
using System.Collections.Generic;
using System.Linq;
using SimpleWarehouse.Model;
using SimpleWarehouse.Util;
using static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Revenues
{
    internal class RevenuesDbService : IRevenueStreamDbService
    {
        private const string CannotCreateRevenueStream = "Имаше проблем със създаването";

        public void Archive()
        {
            foreach (var revenue in Database.Revenues.Where(e => !e.IsRevised).ToList())
                revenue.IsRevised = true;
            Database.SaveChanges();
        }

        public RevenueStream CreateRevenueStream(RevenueStream revenueStream)
        {
            try
            {
                var revenue = new ModelMerger().Merge(revenueStream, new Revenue());
                Database.Revenues.Add(revenue);
                Database.SaveChanges();
                return revenue;
            }
            catch (Exception)
            {
                throw new ArgumentException(CannotCreateRevenueStream);
            }
        }

        public List<RevenueStream> FindAll()
        {
            return new List<RevenueStream>(Database.Revenues);
        }

        public List<RevenueStream> FindAllNonRevised(string comment)
        {
            return new List<RevenueStream>(Database.Revenues
                .Where(r => r.IsRevised == false && r.Comment.ToLower().Contains(comment.ToLower()))
                .OrderBy(e => e.Date));
        }

        public List<RevenueStream> FindAllArchived()
        {
            return new List<RevenueStream>(Database.Revenues.Where(r => r.IsRevised));
        }

        public List<RevenueStream> FindAllArchived(DateTime start, DateTime end, string comment)
        {
            return new List<RevenueStream>(
                Database.Revenues.Where(e => e.IsRevised 
                                             && e.Date >= start 
                                             && e.Date <= end 
                                             && e.Comment.ToLower().Contains(comment.ToLower())));
        }
    }
}