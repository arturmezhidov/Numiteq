using System.ComponentModel.DataAnnotations;

namespace Numiteq.Areas.Admin.ViewModels.Number
{
    public class EditNumberViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Value")]
        public int Value { get; set; }

        [Required]
        [Display(Name = "Label")]
        public string Label { get; set; }
    }
}