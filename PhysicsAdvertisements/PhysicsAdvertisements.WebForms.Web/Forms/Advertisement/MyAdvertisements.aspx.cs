using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Data.Advertisement;
using PhysicsAdvertisements.WebForms.Web.Presenters.Advertisement;
using PhysicsAdvertisements.WebForms.Web.Presenters.Global;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Presenters;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Advertisement
{
    public interface IMyAdvertisementsView
    {
        string StatusControl_Text { set; }
        System.Drawing.Color StatusControl_ForeColor { set; }

        object MyAdvertisementsGridViewControl_DataSourceWithDataBind { set; }
    }


    public partial class MyAdvertisements : System.Web.UI.Page, IMyAdvertisementsView
    {

        //Presenters
        private IMyAdvertisementsPresenter _myAdvertisementsPresenter;


        //Repositories
        private IUserRepo _userRepo;
        private IAdvertisementRepo _advertisementRepo;


        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            LoggedUserPresenter.CheckIsUserLooged(this);

            //Init HomePresenter
            _myAdvertisementsPresenter = new MyAdvertisementsPresenter(this);

            //Init Objects
            _myAdvertisementsPresenter.InitializeRepoObjects(ref _userRepo, ref _advertisementRepo);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _myAdvertisementsPresenter.PutDataToSearchResultGridViewControl(this, (int)this.Session["LoggedUserId"], _userRepo, _advertisementRepo);
        }
        #endregion


        #region **********************************   Controls events   **********************************
        protected void MyAdvertisementsGridViewControl_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _myAdvertisementsPresenter.DeleteSelectedAdvertisement(Convert.ToInt32(((HiddenField)MyAdvertisementsGridViewControl.Rows[e.RowIndex].FindControl("AdvertisementId")).Value),
                                                                    _advertisementRepo, this, (int)this.Session["LoggedUserId"], _userRepo);
        }
        #endregion



        #region **********************************   Accessors   **********************************
        public object MyAdvertisementsGridViewControl_DataSourceWithDataBind
        {
            set
            {
                MyAdvertisementsGridViewControl.DataSource = value;
                MyAdvertisementsGridViewControl.DataBind();
            }
        }

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
        #endregion
       
    }
}