namespace SimpleWarehouse.Sections.Revenues
{
    public interface IRevenueStreamSection
    {
        void AddRevenueStreamAction();

        void DisplayArchivedRevenueStreams();

        void UpdateNonRevisedRevenueStreams(string comment);
    }
}