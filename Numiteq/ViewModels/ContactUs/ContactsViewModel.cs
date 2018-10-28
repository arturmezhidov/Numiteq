using Numiteq.Common.Settings;

namespace Numiteq.ViewModels.ContactUs
{
    [SettingsType(SettingsKeys.Contacts)]
    public class ContactsViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string FormTitle { get; set; }
        
        public string FormDescription { get; set; }

        public string FormSuccessMessage { get; set; }
        
        public string FormErrorMessage { get; set; }
    }
}
