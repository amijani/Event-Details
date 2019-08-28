
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
    class thirdFragment:Fragment
    {
        DBHelper dBHelper;
        string[] myFavFood;
        Activity context;
        ListView listView;
        
        List<UserObject> favList = new List<UserObject>();
        UserObject myObj;
        UserObject1 myObject;

        public thirdFragment(String[] myFood, Activity maincontext)
        {

            myFavFood = myFood;
            context = maincontext;
            dBHelper = new DBHelper(context);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View firstView = inflater.Inflate(Resource.Layout.thirdFragment, container, false);

            listView = firstView.FindViewById<ListView>(Resource.Id.favListID);
            // searchView = firstView.FindViewById<SearchView>(Resource.Id.searchViewId);
            myObj = new UserObject();
            myObject = new UserObject1();


            favList = dBHelper.selectAllFavrouites();
            var favCustomerAdapter = new myCustomAdapter(context, favList);
            listView.SetAdapter(favCustomerAdapter);

            
            listView.ItemClick += myListViewEvent;
            //  searchView.QueryTextChange += searchView_QueryTextChange;

            return firstView;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

        void myListViewEvent(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;

            UserObject value = favList[index];
            System.Console.WriteLine("Value " + value.name);

           /* var activity = new Intent(context, typeof(EventActivity));
            activity.PutExtra("Value", value.name);
            StartActivity(activity);*/
        }

        //search view code
          private void searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
          {
              var value = e.NewText;
              System.Console.WriteLine("value" + value);
              List<UserObject> filterList = new List<UserObject>();
              foreach (UserObject aobj in favList)
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
        
      }
}