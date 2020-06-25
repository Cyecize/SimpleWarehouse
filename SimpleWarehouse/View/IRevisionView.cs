namespace SimpleWarehouse.View
{
    public interface IRevisionView
    {
        string RevisionRevenue { get; set; }

        string RevisionExpenses { get; set; }

        string RevisionSalesRevenue { get; set; }

        string RevisionSubTotal { get; set; }

        string RevisionStartDate { get; set; }

        string RevisonSubTotalPlusSalesRevenue { get; set; }
    }
}