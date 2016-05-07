using PhysicsAdvertisements.Repository.Repo;
using PhysicsAdvertisements.WebForms.Web.Data.Advertisement;
using PhysicsAdvertisements.WebForms.Web.Presenters.Advertisement;
using PhysicsAdvertisements.WebForms.Web.Presenters.Global;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Presenters;
using PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicsAdvertisements.WebForms.Web.Forms.Advertisement
{
    public interface IMyAdvertisementsView
    {
        object MyAdvertisementsGridViewControl_DataSourceWithDataBind { set; }
    }


    public partial class MyAdvertisements : System.Web.UI.Page, IMyAdvertisementsView
    {

        //Presenters
        private IMyAdvertisementsPresenter _myAdvertisementsPresenter;


        //Repositories
        private IUserRepo _userRepo;

        #region **********************************   Page life cycle   **********************************
        protected void Page_Init(object sender, EventArgs e)
        {
            LoggedUserPresenter.CheckIsUserLooged(this);

            //Init HomePresenter
            _myAdvertisementsPresenter = new MyAdvertisementsPresenter(this);

            //Init Objects
            _myAdvertisementsPresenter.InitializeRepoObjects(ref _userRepo);

            //InitializeSearchControl upchac cala logike do prezentera


            MyAdvertisementsGridViewControl.DataSource = myAdvertisementsData;
            MyAdvertisementsGridViewControl.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        #endregion


        #region **********************************   Controls events   **********************************
        protected void MyAdvertisementsGridViewControl_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
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
        #endregion






























        List<MyAdvertisementsData> myAdvertisementsData = new List<MyAdvertisementsData>()
            {
                  new MyAdvertisementsData()
                  {
                      AddedDate= DateTime.Now,
                      UserImageUrl= "../../ecommerce-icon-set-freepik/New/avatar%20girl.png",
                      Name= "Kate",
                      Surname="Frog",
                      Age=28,

                      AdvertisementId = "34",
                      AdvertisementPhysicsArea = "PhysicsArea1",
                      AdvertisementTitle = "Title1",
                      AdvertisementCategory = "Category1",
                      AdvertisementContent = "dfdsafkjdsfhkjdsahf ksdjahfkjsahfd ksflkjsaf sakfdhjskjdfhfdshsadkfhdsf lsdkjflksajflkdsfj",

                      Email = "sample@email.com",
                      PhoneNumber = "512-952-443"


                  },
                   new MyAdvertisementsData()
                  {
                      AddedDate= DateTime.Now,
                      UserImageUrl= "../../ecommerce-icon-set-freepik/New/avatar%20girl.png",
                      Name= "Kate",
                      Surname="Frog",
                      Age=6564,

                      AdvertisementId = "111",
                      AdvertisementPhysicsArea = "PhysicsArea1",
                      AdvertisementTitle = "Title1",
                      AdvertisementCategory = "Category1",
                      AdvertisementContent = "dfdsafkjdsfhkjdsahf ksdjahfkjsahfd ksflkjsaf sakfdhjskjdfhfdshsadkfhdsf lsdkjflksajflkdsfj",

                      Email = "sample@email.com",
                      PhoneNumber = "512-952-443"


                  }
            };
    }
}