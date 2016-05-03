using PhysicsAdvertisements.WebForms.Web.ViewModels.AdvertisementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validatable;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Advertisement
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetTypeName(object sender, EventArgs e)
        {
            DataAnnotationValidator validator = (DataAnnotationValidator)sender;
            validator.SourceTypeName = new CreateVM().EntityType.AssemblyQualifiedName;
        }

        protected void SubmitControl_Click(object sender, EventArgs e)
        {
            //_createPresenter.SubmitControl_Click(this, _userRepo, CreateVMFormData);
        }
    }
}