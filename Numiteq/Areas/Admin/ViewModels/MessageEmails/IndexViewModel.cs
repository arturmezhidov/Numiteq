using Numiteq.Common.Entities;
using System.Collections.Generic;

namespace Numiteq.Areas.Admin.ViewModels.MessageEmails
{
    public class IndexViewModel
    {
        public IEnumerable<MessageEmail> Emails { get; set; }
    }
}