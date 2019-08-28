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
    [Activity(Label = "WelcomeActivity")]
    public class WelcomeActivity : Activity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            EditText username_val;
            EditText password_val;
            EditText age_val;
            EditText email_val;
            Button edit;
            DBHelper dBHelper;
            User user;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Welcome);
            // Create your application here
            string user_email = Intent.GetStringExtra("Email");

            username_val = FindViewById<EditText>(Resource.Id.nameTxt);
            password_val = FindViewById<EditText>(Resource.Id.pwdTxt);
            age_val = FindViewById<EditText>(Resource.Id.age1);
            email_val = FindViewById<EditText>(Resource.Id.emailIdTxt);
            edit = FindViewById<Button>(Resource.Id.Edit_Btn);

            dBHelper = new DBHelper(this);

            username_val.Enabled = false;
            password_val.Enabled = false;
            email_val.Enabled = false;
            age_val.Enabled = false;
            
            user = dBHelper.Uservalue(user_email);

            //username_val.Text = user.userName;
            password_val.Text = user.passwrd1;
            email_val.Text = user.email;
            //age_val.Text = user.age.ToString();

            edit.Click += delegate
              {
                  username_val.Enabled = true;
                  password_val.Enabled = false ;
                  age_val.Enabled = true;
                  
              };

            /*Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);*/
        }
    }
}