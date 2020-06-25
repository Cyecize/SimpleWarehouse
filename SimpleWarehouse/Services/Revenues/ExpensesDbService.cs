using System;
using System.Collections.Generic;
using System.Linq;
using SimpleWarehouse.Model;
using SimpleWarehouse.Util;
using static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Revenues
{
    public class ExpensesDbService : IRevenueStreamDbService
    {
        private const string CannotCreateRevenueStream = "Имаше проблем със създаването";

        public void Archive()
        {
            foreach (var expense in Database.Expenses.Where(e => !e.IsRevised).ToList())
                expense.IsRevised = true;
            Database.SaveChanges();
        }

        public RevenueStream CreateRevenueStream(RevenueStream revenue)
        {
            try
            {
                var expense = new ModelMerger().Merge(revenue, new Expense());
                Database.Expenses.Add(expense);
                Database.SaveChanges();
                return expense;
            }
            catch (Exception)
            {
                throw new ArgumentException(CannotCreateRevenueStream);
            }
        }

        public List<RevenueStream> FindAll()
        {
            return new List<RevenueStream>(Database.Expenses);
        }

        public List<RevenueStream> FindAllNonRevised(string comment)
        {
            return new List<RevenueStream>(Database.Expenses
                .Where(e => e.IsRevised == false && e.Comment.ToLower().Contains(comment.ToLower()))
                .OrderBy(e => e.Date));
        }

        public List<RevenueStream> FindAllArchived()
        {
            return new List<RevenueStream>(Database.Expenses.Where(e => e.IsRevised));
        }

        public List<RevenueStream> FindAllArchived(DateTime start, DateTime end, string comment)
        {
            return new List<RevenueStream>(
                Database.Expenses.Where(e => e.IsRevised
                                             && e.Date >= start
                                             && e.Date <= end
                                             && e.Comment.ToLower().Contains(comment.ToLower())));
        }
    }
}