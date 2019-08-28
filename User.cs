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
   public class User
    {
       public string userName, email, passwrd1;
       public int age;

        public User()
        {

        }
        public User(string userName,string email,int age, string passwrd1)
        {
            userName = this.userName;
            email = this.email;
            age = this.age;
            passwrd1 = this.passwrd1;
        }

    }
}