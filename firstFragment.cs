using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Android_Assignment3
{
    [Activity(Label = "firstFragment")]
    public class firstFragment : Fragment
    {

        string[] myFavFood;
        Activity context;
        ListView listView;
        string[] spinnerValue = { "a", "b" };
        SearchView searchView;
        Spinner myOptions;
        List<UserObject> myUserList = new List<UserObject>();
       List<UserObject1> myEventsList = new List<UserObject1>();
        UserObject myObj;
        UserObject1 myObject;
        DBHelper dbhelper;


        string[] items = { "Clubbing", "Food and drinks", "Sports","Workshop" };

        public firstFragment(String[] myFood, Activity maincontext)
        {

            myFavFood = myFood;
            context = maincontext;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        // List View code
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View firstView = inflater.Inflate(Resource.Layout.firstfragment, container, false);
            
            myOptions = firstView.FindViewById<Spinner>(Resource.Id.mySpinnerId);
            listView = firstView.FindViewById<ListView>(Resource.Id.myListID);
           searchView = firstView.FindViewById<SearchView>(Resource.Id.searchViewId);
            myObj = new UserObject();
            myObject = new UserObject1();

            myUserList = myObj.createListOfUsers();
            var myCustomerAdapter = new myCustomAdapter(context, myUserList);
            listView.SetAdapter(myCustomerAdapter);


            myEventsList = myObject.eventList();
            var adatperSpinner = new myCustomAdapter1(context, myEventsList);
            myOptions.Adapter = adatperSpinner;

            myOptions.ItemSelected += MyOptions_ItemSelected;

            listView.ItemClick += myListViewEvent;
           searchView.QueryTextChange += searchView_QueryTextChange;

            return firstView;
            
            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
        void myListViewEvent(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;

            UserObject value = myUserList[index];
            System.Console.WriteLine("Value " + value.name);

            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(context);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Favourite!");
            alert.SetMessage("Add To Favourites?");

            alert.SetButton("Add", (c, ev) =>
            {
                dbhelper = new DBHelper(context);
                
                dbhelper.insertFavouritetable(value.id,value.name,value.address,value.day,value.price,value.category);
            });
            
            alert.SetButton2("Cancel", (c, ev) =>

            {
                var activity = new Intent(context, typeof(homeActivity));
                //activity.PutExtra("Value", value.name);
                StartActivity(activity);
            });

            alert.Show();

            /*var activity = new Intent(context, typeof(EventActivity));
            activity.PutExtra("Value", value.name);
            StartActivity(activity);*/
        }

        //search view code
          private void searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
          {
              var value = e.NewText;
              System.Console.WriteLine("value" + value);
              List<UserObject> filterList = new List<UserObject>();
              foreach (UserObject aobj in myUserList)
              {
                  if (aobj.name.ToLower().Contains(value.ToLower()))
                  {
                      filterList.Add(aobj);
                  }
              }
              var newFilter = new myCustomAdapter(context
                  , filterList);
              listView.SetAdapter(newFilter);  //list view declared in this 
          }

        void MyOptions_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
           // var index = e.Position;

           // var value = items[index];
            //System.Console.WriteLine("value is " + value);

            switch(e.Position)
            {
                case 0:
                    myUserList = myObj.createListOfUsers();
                    var myCustomerAdapter = new myCustomAdapter(context, myUserList);
                    listView.SetAdapter(myCustomerAdapter);
                    break;

                case 1:
                    myUserList = myObj.createListOfUsers1();
                    var myCustomerAdapter1 = new myCustomAdapter(context, myUserList);
                    listView.SetAdapter(myCustomerAdapter1);
                    break;

                case 2:
                    myUserList = myObj.createListOfUsers2();
                    var myCustomerAdapter2 = new myCustomAdapter(context, myUserList);
                    listView.SetAdapter(myCustomerAdapter2);
                    break;

                case 3:
                    myUserList = myObj.createListOfUsers3();
                    var myCustomerAdapter3 = new myCustomAdapter(context, myUserList);
                    listView.SetAdapter(myCustomerAdapter3);
                    break;

                default:
                    System.Console.WriteLine(" ");
                    break;
            }

        }
    }
}