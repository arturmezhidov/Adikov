using Adikov.Domain.Models;

namespace Adikov.ViewModels.Forms
{
    public class FormControlViewModel
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public ColumnType Type { get; set; }

        public string Value { get; set; }

        public string FieldNamePrefix { get; set; }
    }
}