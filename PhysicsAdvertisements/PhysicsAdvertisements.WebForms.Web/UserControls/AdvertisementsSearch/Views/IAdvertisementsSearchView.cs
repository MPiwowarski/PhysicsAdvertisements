using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Views
{
    public interface IAdvertisementsSearchView
    {
        string PhysicAreaName_Text { get; set; }
        string CategoryName_Text { get; set; }
        event EventHandler SearchBtn_Click_Event;
    }
}
