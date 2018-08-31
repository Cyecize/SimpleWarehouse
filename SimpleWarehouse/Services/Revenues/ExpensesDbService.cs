﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Model;
using SimpleWarehouse.Util;
using static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Revenues
{
    public class ExpensesDbService : IRevenueStreamDbService
    {
        private const string CannotCreateRevenueStream = "Имаше проблем със създаването";
        public ExpensesDbService()
        {

        }

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
                Expense expense = new ModelMerger().Merge(revenue, new Expense());
                Database.Expenses.Add(expense);
                Database.SaveChanges();
                return expense;
            }
            catch (Exception) { throw new ArgumentException(CannotCreateRevenueStream); }
        }

        public List<RevenueStream> FindAll()
        {
            return new List<RevenueStream>(Database.Expenses);
        }

        public List<RevenueStream> FindAllNonRevised()
        {
            return new List<RevenueStream>(Database.Expenses.Where(e => e.IsRevised == false));
        }

        public List<RevenueStream> FindAllArchived()
        {
            return new List<RevenueStream>(Database.Expenses.Where(e => e.IsRevised));
        }

        public List<RevenueStream> FindAllArchived(DateTime start, DateTime end)
        {
            return new List<RevenueStream>(Database.Expenses.Where(e => e.IsRevised && e.Date >= start && e.Date <= end));
        }
    }
}