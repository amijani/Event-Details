using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace Android_Assignment3
{
    [Activity(Label = "secondFragment")]
    public class secondFragment : Fragment
    {
        string[] myFavFood;
        Activity context;
        EditText username_val;
        EditText password_val;
        EditText age_val;
        EditText email_val;
        Button edit;
        DBHelper dBHelper;
        User user;


        public secondFragment(String[] myFood, Activity maincontext)
        {

            myFavFood = myFood;
            context = maincontext;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            dBHelper = new DBHelper(context);

            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            string user_email = prefs.GetString("user_email", null);

            user = dBHelper.Uservalue(user_email);


            View firstView = inflater.Inflate(Resource.Layout.Welcome, container, false);
            username_val = firstView.FindViewById<EditText>(Resource.Id.nameTxt);
            password_val = firstView.FindViewById<EditText>(Resource.Id.pwdTxt);
            age_val = firstView.FindViewById<EditText>(Resource.Id.age1);
            email_val = firstView.FindViewById<EditText>(Resource.Id.emailIdTxt);
            edit = firstView.FindViewById<Button>(Resource.Id.Edit_Btn);


            // user_email = Intent.GetStringExtra("Email");


           
          /* username_val.Enabled = false;
            password_val.Enabled = false;
            email_val.Enabled = false;
            age_val.Enabled = false;*/

          
            password_val.Text = user.passwrd1;
            email_val.Text = user.email;

            edit.Click += delegate
            {


                username_val.Enabled = true;
                email_val.Enabled = true;
                password_val.Enabled = true;
                age_val.Enabled = true;
                dBHelper.update(email_val.Text,password_val.Text,age_val.Text, username_val.Text);

                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(context);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Successful");
                alert.SetMessage("Data changed have been saved");

                alert.SetButton("OK", (c, ev) =>
                {
                    // Ok button click task
                    Intent intent = new Intent(context, typeof(homeActivity));
                    StartActivity(intent);
                });

                alert.Show();
            };
            
            return firstView;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
        
    }
}