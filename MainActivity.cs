using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace Android_Assignment3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button registor_Btn,user_Btn;
        EditText userName;
        EditText user_age;
        EditText user_Email;
        EditText user_password;
        DBHelper dbhelper;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            dbhelper = new DBHelper(this);
            //Step 4
            userName = FindViewById<EditText>(Resource.Id.username);
            user_age = FindViewById<EditText>(Resource.Id.userAge);
            user_Email = FindViewById<EditText>(Resource.Id.email_id);
            user_password = FindViewById<EditText>(Resource.Id.userPassword);
            registor_Btn = FindViewById<Button>(Resource.Id.registerBtn);
            user_Btn = FindViewById<Button>(Resource.Id.userBtn);

            registor_Btn.Click += delegate {
                
                string value = userName.Text.Trim();
                
                string value_age = user_age.Text.Trim();
                
                string value_email = user_Email.Text.Trim();
               
                string value_password = user_password.Text.Trim();

                if (value!="" && value_age!="" && value_email!="" && value_password!="")
                {
                    //equal

                    dbhelper.insertValue(userName.Text, user_age.Text, user_Email.Text, user_password.Text);

                   // dbhelper.selectAllUsers();
                    Intent newScreen = new Intent(this, typeof(Loginactivity));
                    StartActivity(newScreen);

                }
                else
                {
                    //not equal
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Error");
                    alert.SetMessage("Please Enter all fields");

                    alert.SetButton("OK", (c, ev) =>
                    {
                        // Ok button click task  
                    });

                    alert.Show();

                }

            };
            user_Btn.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Loginactivity));
                StartActivity(intent);


            };

          


        }
    }
}