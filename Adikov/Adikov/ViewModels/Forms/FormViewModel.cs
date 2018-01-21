using System.Collections.Generic;

namespace Adikov.ViewModels.Forms
{
    public class FormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<FormControlViewModel> Controls { get; set; }
    }
}