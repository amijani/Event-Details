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
    class UserObject1
    {
        public string category;

        public UserObject1()
        {

        }

        public UserObject1(string mycategory)
        {
            category = mycategory;
        }

        public List<UserObject1> eventList()
        {
            List<UserObject1> myEventList = new List<UserObject1>();

            myEventList.Add(new UserObject1("Clubbing"));
            myEventList.Add(new UserObject1("Food and Drinks"));
            myEventList.Add(new UserObject1("Sports"));
            myEventList.Add(new UserObject1("Workshop"));

            return myEventList;
        }
    }
}