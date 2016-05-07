using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Views
{
    public interface IAdvertisementsSearchView
    {
        string PhysicsAreaControl_Text { get; set; }
        string CategoryControl_Text { get; set; }

        List<string> CategoryControl_DataSourceWithDataBind { set; }
        List<string> PhysicsAreaControl_DataSourceWithDataBind { set; }
    }
}
