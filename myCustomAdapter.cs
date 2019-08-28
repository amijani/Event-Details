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
    class myCustomAdapter : BaseAdapter<UserObject>
    {
        List<UserObject> myAdapterlist;
        
        Activity context;

        public myCustomAdapter(Activity cont, List<UserObject> mylist)
        {
            context = cont;
            myAdapterlist = mylist;
        }

        public override UserObject this[int position]
        {

            get { return myAdapterlist[position]; }
        }

        public override int Count
        {
            get { return myAdapterlist.Count; }
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            UserObject myObj = myAdapterlist[position];

            View eventsView = convertView;
            if (eventsView == null)
            {
                eventsView = context.LayoutInflater.Inflate(Resource.Layout.events, null);
            }

            eventsView.FindViewById<TextView>(Resource.Id.myNameId).Text = myObj.name;
            eventsView.FindViewById<TextView>(Resource.Id.myAddressId).Text = myObj.address;
            eventsView.FindViewById<TextView>(Resource.Id.mydayId).Text = myObj.day;
            eventsView.FindViewById<TextView>(Resource.Id.mypriceId).Text = myObj.price.ToString();
            eventsView.FindViewById<TextView>(Resource.Id.mycategoryId).Text = myObj.category;
            return eventsView;

        }
    }
    
    }
