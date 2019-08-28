﻿using System;
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
    [Activity(Label = "EventActivity")]
    public class EventActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            string name = Intent.GetStringExtra("Value") ?? string.Empty;

            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("");
            alert.SetMessage(name);
            alert.SetButton("OK", (c, ev) =>
            {
                Intent intent = new Intent(this, typeof(homeActivity));
                StartActivity(intent);
            });
            alert.Show();
        }
    }
}