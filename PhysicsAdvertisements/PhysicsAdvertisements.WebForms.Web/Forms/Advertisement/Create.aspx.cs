using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Presenters.Advertisement;
using PhysicsAdvertisements.WebForms.Web.ViewModels.AdvertisementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validatable;
using System.Drawing;
using PhysicsAdvertisements.WebForms.Web.Presenters.Global;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Advertisement
{
    public interface ICreateView
    {
        string StatusControl_Text { set; }
        System.Drawing.Color StatusControl_ForeColor { set; }

        CreateVM CreateVMFormData { get; }
    }

    public partial class Create : System.Web.UI.Page, ICreateView
    {
        //Presenters
        private ICreatePresenter _createPresenter;

        //Repositories
        private IAdvertisementRepo _advertisementRepo;
        private IPhysicsAreasRepo _physicsAreasRepo;
        private ICategoryRepo _categoryRepo;

        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            LoggedUserPresenter.CheckIsUserLooged(this);

            //Init HomePresenter
            _createPresenter = new CreatePresenter(this);

            //Init Objects
            _createPresenter.InitializeObjects(ref _advertisementRepo, ref _physicsAreasRepo, ref _categoryRepo);

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        protected void GetTypeName(object sender, EventArgs e)
        {
            DataAnnotationValidator validator = (DataAnnotationValidator)sender;
            validator.SourceTypeName = new CreateVM().EntityType.AssemblyQualifiedName;
        }

        protected void SubmitControl_Click(object sender, EventArgs e)
        {
            _createPresenter.SubmitControl_Click(this, _advertisementRepo, _physicsAreasRepo, _categoryRepo, CreateVMFormData);
        }


        #region **********************************   Accessors   **********************************
        public string StatusControl_Text
        {
            set
            {
                StatusControl.Text = value;
            }
        }

        public Color StatusControl_ForeColor
        {
            set
            {
                StatusControl.ForeColor = value;
            }
        }

        public CreateVM CreateVMFormData
        {
            get
            {
                return new CreateVM()
                {
                    Title = TitleControl.Text,
                    PhysicsArea = PhysicsAreaControl.SelectedValue,
                    Category = CategoryControl.SelectedValue,
                    Content = ContentControl.Text
                };
            }
        }
        #endregion 
    }
}