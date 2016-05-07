using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Presenters;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.ControlTemplates
{
    public partial class AdvertisementsSearch : System.Web.UI.UserControl, IAdvertisementsSearchView
    {

        //Presenters
        private AdvertisementsSearchPresenter _advertisementsSearchPresenter;


        //Repositories
        private IAdvertisementRepo _advertisementRepo;
        private ICategoryRepo _categoryRepo;
        private IPhysicsAreasRepo _physicsAreasRepo;
        private IUserRepo _userRepo;

        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            //Init HomePresenter
            _advertisementsSearchPresenter = new AdvertisementsSearchPresenter(this);

            //Init Objects
            _advertisementsSearchPresenter.InitializeRepoObjects(ref _advertisementRepo, ref _categoryRepo, ref _physicsAreasRepo,ref _userRepo);



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _advertisementsSearchPresenter.PutDataToControlsDataSource(this,_categoryRepo, _physicsAreasRepo);
        }
        #endregion



        protected void SearchBtnControl_Click(object sender, EventArgs e)
        {
            _advertisementsSearchPresenter.SearchBtnControl_Click(this, CategoryControl_Text, PhysicsAreaControl_Text, _advertisementRepo, _userRepo);
            
        }


        #region **********************************   Accessors   **********************************
        public string PhysicsAreaControl_Text
        {
            get
            {
                return PhysicsAreaControl.SelectedValue;
            }
            set
            {
                PhysicsAreaControl.Text = value;
            }
        }

        public string CategoryControl_Text
        {
            get
            {
                return CategoryControl.SelectedValue;
            }
            set
            {
                CategoryControl.Text = value;
            }
        }

        public List<string> CategoryControl_DataSourceWithDataBind
        {
            set
            {
                CategoryControl.DataSource = value;
                CategoryControl.DataBind();
            }
        }

        public List<string> PhysicsAreaControl_DataSourceWithDataBind
        {
            set
            {
                PhysicsAreaControl.DataSource = value;
                PhysicsAreaControl.DataBind();
            }
        }


        #endregion

    }
}