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
using ActionBar = Android.App.ActionBar;


namespace Android_Assignment3
{
    [Activity(Label = "home")]
    public class homeActivity : Activity
    {
       

        Fragment[] _fragments;
        string[] listOfFavFood = { "a", "B", "C" };
        //string[] items = { "a", "B", "C" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.home);
            // Create your application here
            
            _fragments = new Fragment[]
               {
                new firstFragment(listOfFavFood,this),
                new secondFragment(listOfFavFood,this),
                new thirdFragment(listOfFavFood, this)
               };


            // Get our button from the layout resource,
            AddTabToActionBar("EVENTS"); //First Tab
            AddTabToActionBar("EDIT DETAILS"); //Second Tab
            AddTabToActionBar("FAVOURITES"); //Second Tab


            // Get our button from the layout resource,
        }
        
            void AddTabToActionBar(string tabTitle)
            {
                ActionBar.Tab tab = ActionBar.NewTab().SetText(tabTitle); 
                
                tab.TabSelected += TabOnTabSelected;
                ActionBar.AddTab(tab);
            }
            void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
            {
                ActionBar.Tab tab = (ActionBar.Tab)sender;

                //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
                Fragment frag = _fragments[tab.Position];

                tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
            }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // set the menu layout on Main Activity  
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);

            
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            switch (item.ItemId)
            {
                case Resource.Id.menuItem1:
                    {
                        // add your code  
                        Intent refresh = new Intent(this, typeof(homeActivity));
                        refresh.AddFlags(ActivityFlags.NoAnimation);
                        Finish();
                        StartActivity(refresh);
                        return true;
                    }
                case Resource.Id.menuItem2:
                    {
                        // add your code 
                        
                            Intent intent = new Intent(this, typeof(Loginactivity));
                            StartActivity(intent);
                            return true;
                    }
                case Resource.Id.menuItem3:
                    {
                        // add your code 
                        Intent intent = new Intent(this, typeof(AboutUsActivity));
                        StartActivity(intent);
                        return true;
                    }
            }

            return base.OnOptionsItemSelected(item);

        }


        /*void MyOptions_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = items[index];
            System.Console.WriteLine("value is " + value);
            if (value.ToLower().Equals("veg"))
            {
                //create a veg array and create as a new adater 


            }
        }*/

    }
    }