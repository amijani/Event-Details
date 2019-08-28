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
    class myCustomAdapter1: BaseAdapter<UserObject1>
    {
        List<UserObject1> adapterlist;

        Activity context;

        public myCustomAdapter1(Activity cont, List<UserObject1> myEventlist)
        {
            context = cont;
            adapterlist = myEventlist;
        }

        public override UserObject1 this[int position]
        {

            get { return adapterlist[position]; }
        }

        public override int Count
        {
            get { return adapterlist.Count; }
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            UserObject1 myObj1 = adapterlist[position];

            View myeventsView = convertView;
            if (myeventsView == null)
            {
                myeventsView = context.LayoutInflater.Inflate(Resource.Layout.Category, null);
            }

            myeventsView.FindViewById<TextView>(Resource.Id.myCategoryId).Text = myObj1.category;

            return myeventsView;

        }
    
}
}