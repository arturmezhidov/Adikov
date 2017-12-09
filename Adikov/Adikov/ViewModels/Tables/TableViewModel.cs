namespace Adikov.ViewModels.Tables
{
    public class TableViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ColumnsCount { get; set; }

        public bool IsDeleted { get; set; }
    }
}