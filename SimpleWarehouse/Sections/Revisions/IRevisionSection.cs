namespace SimpleWarehouse.Sections.Revisions
{
    public interface IRevisionSection
    {
        void Initialize();

        void CancelOperation();

        void BeginRevision();

        void UpdateTotalPriceAction(int rowId);

        void RefreshGridAction();

        void CommitRevisionAction();
    }
}