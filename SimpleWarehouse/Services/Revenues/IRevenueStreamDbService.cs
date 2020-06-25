using System;
using System.Collections.Generic;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Revenues
{
    public interface IRevenueStreamDbService
    {
        void Archive();

        RevenueStream CreateRevenueStream(RevenueStream revenue);

        List<RevenueStream> FindAll();

        List<RevenueStream> FindAllNonRevised();

        List<RevenueStream> FindAllArchived();

        List<RevenueStream> FindAllArchived(DateTime start, DateTime end, string comment);
    }
}