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
    [Activity(Label = "foodanddrink")]
    public class foodanddrink : Activity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // searchView.QueryTextChange += searchView_QueryTextChange;

        }

        /* private void searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
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
           var newFilter = new myCustomAdapter(this, filterList);
           listView.SetAdapter(newFilter);  //list view declared in this 
       }*/


    }
}