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

    [Activity(Label = "Loginactivity")]
    public class Loginactivity : Activity
    {
        EditText user_Emailid;
        EditText user_passWord;
        Button login_Btn;
        DBHelper dbhelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginActivity);
            dbhelper = new DBHelper(this);
            // Create your application here

            user_Emailid = FindViewById<EditText>(Resource.Id.user_email_id);
            user_passWord = FindViewById<EditText>(Resource.Id.user_Password);

           /* ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("user_email", user_Emailid.Text);
            editor.Commit();    
            editor.Apply();*/

            login_Btn = FindViewById<Button>(Resource.Id.LoginBtn);
            login_Btn.Click += delegate
            {
                string user_name_val = user_Emailid.Text;
                if (user_Emailid.Text != " " && user_passWord.Text != " ")
                {
                    bool result = dbhelper.selectAllUsers(user_Emailid.Text, user_passWord.Text);

                    if (result)
                    {
                        Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alert = dialog.Create();
                        alert.SetTitle("Success");
                        alert.SetMessage("Logged in successfully");

                        alert.SetButton("OK", (c, ev) =>
                        {
                            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                            ISharedPreferencesEditor editor = prefs.Edit();
                            editor.PutString("user_email", user_Emailid.Text);
                            editor.Commit();
                            editor.Apply();

                            Intent newScreen = new Intent(this, typeof(homeActivity));
                           // newScreen.PutExtra("Email", user_name_val);
                            StartActivity(newScreen);

                            // Ok button click task  
                        });

                        alert.Show();
                    }
                    else
                    {
                        Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alert = dialog.Create();
                        alert.SetTitle("Error");
                        alert.SetMessage("Sorry username or password is incorrect");

                        alert.SetButton("OK", (c, ev) =>
                        {
                            // Ok button click task  
                        });

                        alert.Show();
                    }

                }
                else
                {

                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Error");
                    alert.SetMessage("Please enter email or password");

                    alert.SetButton("OK", (c, ev) =>
                    {
                            // Ok button click task  
                        });

                    alert.Show();
                }
                

              
            };


        }
    }
}
  
