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
    class Events
    {
        public string category;
        
        public Events()
        {
        }

        public Events(string myCategory)
        {
            category = myCategory;
        }
        
        public List<Events> listOfEvents()
        {

            List<Events> myEvents = new List<Events>();

            myEvents.Add(new Events("Clubbing"));
            myEvents.Add(new Events("Food and Drinks"));
            myEvents.Add(new Events("Sports"));
            myEvents.Add(new Events("Workshop"));

            return myEvents;
        }
    
}
}