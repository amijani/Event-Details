using System;
using Android.Database.Sqlite;
using Android.Content;
using Android.Database;
using Android.Widget;
using Android.App;
using Android.OS;
using System.Collections.Generic;

namespace Android_Assignment3
{
    class DBHelper: SQLiteOpenHelper
    {
        //Step 1:
        private static string _DatabaseName = "mydatabase1.db";
        private const string TableName = "persontable";
        private const string ColumnName = "name";
        private const string ColumnAge = "age";
        private const string ColumnEmail = "eMail";
        private const string ColumnPassword = "password";

        //favrouites table
        private const string TableFavourite = "Eventtable";
        private const string ColumnId = "id";
        private const string ColumnName1 = "name";
        private const string ColumnAddress = "address";
        private const string ColumnDay = "day";
        private const string ColumnPrice = "price";
        private const string ColumnCategory = "category";


        //Step 2:
        //create person query
        public const string CreatePersonTableQuery = "CREATE TABLE " +
        TableName + " ( " + ColumnName + " Text,"
            + ColumnAge + " TEXT,"
            + ColumnEmail + " TEXT,"
            + ColumnPassword + " TEXT)";

        //create favrouties table query
        public const string CreateEventtableQuery = "CREATE TABLE " +
        TableFavourite + " ( "+ ColumnId + " INTEGER,"
            + ColumnName1 + " TEXT," 
           + ColumnAddress + " TEXT,"
            + ColumnDay + " TEXT,"
              +ColumnPrice + " TEXT,"
                 +ColumnCategory+ " TEXT)";


        public const string DeleteQuery = "DROP TABLE IF EXISTS " + TableName;

        public const string DeleteQuery1 = "DROP TABLE IF EXISTS " + TableFavourite;
        //Step 3:
        SQLiteDatabase dbWritablObject;
        /*
         * A default constructor is required, to call the base constructor.
         * The base constructor, takes in the context and the database name; rest of the 
         * 2 parameters are not as much important to understand. 
         */
        public DBHelper(Context context) :
        base(context, name: _DatabaseName, factory: null, version: 1) //Step 4 : Create database
        {
            dbWritablObject = WritableDatabase; //Step 5  
        }

        //Step 6 : Create table 
        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(CreatePersonTableQuery);
            db.ExecSQL(CreateEventtableQuery);
            // db.ExecSQL()
        }
        public override void OnUpgrade(SQLiteDatabase db,
        int oldVersion, int newVersion)
        {
            db.ExecSQL(DeleteQuery);
            db.ExecSQL(DeleteQuery1);
        }
        //create a insert function for person table
        public void insertValue(String userName, string user_age, string user_email, string user_password )
        {
            var insertQuery = "INSERT INTO " + TableName +
            " Values('" + userName + "'" + "," + "'" + user_age + "','" + user_email + "','" + user_password + "')";

            System.Console.WriteLine("My Sql Insert " + insertQuery);
            dbWritablObject.ExecSQL(insertQuery);
            
        }

        //create a insert function for favrouite table
        public void insertFavouritetable(int id, string name, string address, string day, int price, string category)
        {
           // Random rnd = new Random();
           // var id1 = rnd.Next(1, 10000);

            var insertQuery = "INSERT INTO " + TableFavourite +
              " Values('" + id + "'" + "," + "'" + name + "', '" + address + "','" + day + "','" + price + "', '" + category + "')";
            System.Console.WriteLine("My Sql Insert " + insertQuery);
            dbWritablObject.ExecSQL(insertQuery);
        }

        //for person table
        public bool selectAllUsers(string Email,string pwd)
        {
            bool isExist = false;

            string[] columns = new string[] {  ColumnName, ColumnAge, ColumnEmail, ColumnPassword };

            ICursor cursor = dbWritablObject.Query(TableName, columns, null, null, null, null, null);

            while (cursor.MoveToNext())
            {
                var name = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnName));
                System.Console.WriteLine("Value of name : " + name);

                var age = cursor.GetInt(cursor.GetColumnIndexOrThrow(ColumnAge));
                System.Console.WriteLine("Value of age : " + age);

                var email = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEmail));
                System.Console.WriteLine("Value of email : " + email);

                var password = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnPassword));
                System.Console.WriteLine("Value of password : " + password);

                if(email.ToLower().Equals(Email.ToLower()) && password.ToLower().Equals(pwd.ToLower()))
                {
                    isExist = true;
                }

            }

            return isExist;
        }

        //for favrouites table
        public List<UserObject> selectAllFavrouites()
        {
            string[] columns = new string[] { ColumnId, ColumnName, ColumnAddress, ColumnDay, ColumnPrice, ColumnCategory };

            ICursor cursor = dbWritablObject.Query(TableFavourite, columns, null, null, null, null, null);
            List<UserObject> eventlist = new List<UserObject>();
            while (cursor.MoveToNext())
            {
                var id = cursor.GetInt(cursor.GetColumnIndexOrThrow(ColumnId));
                System.Console.WriteLine("Value of id : " + id);

                var name = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnName));
                System.Console.WriteLine("Value of name : " + name);

                var address = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnAddress));
                System.Console.WriteLine("Value of address : " + address);

                var day = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnDay));
                System.Console.WriteLine("Value of day : " + day);

                var price = cursor.GetInt(cursor.GetColumnIndexOrThrow(ColumnPrice));
                System.Console.WriteLine("Value of price : " + price);
                
                var category = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnCategory));
                System.Console.WriteLine("Value of category : " + category);

                eventlist.Add(new UserObject(id, name, address, day, price, category));
            }
            return eventlist;
        }

        //select query forperson table
        public User Uservalue(string user_email)
        {
            var selectQuery = "SELECT * FROM " + TableName + " WHERE "+ ColumnEmail + " ='" + user_email + "'";
            ICursor c = dbWritablObject.RawQuery(selectQuery, null);
            
            while (c.MoveToNext())
            {
                var nameInfo = c.GetString(c.GetColumnIndexOrThrow(ColumnName));
                System.Console.WriteLine("Value of name : " + nameInfo);

                var emailInfo = c.GetString(c.GetColumnIndexOrThrow(ColumnEmail));
                System.Console.WriteLine("Value of email : " + emailInfo);
                
                var ageInfo = c.GetInt(c.GetColumnIndexOrThrow(ColumnAge));
                
                var password1 = c.GetString(c.GetColumnIndexOrThrow(ColumnPassword));

                if (user_email.ToLower().Equals(emailInfo.ToLower()))
                {
                   User user = new User(nameInfo, emailInfo, ageInfo, password1);

                    c.Close();
                    return user;

                }
            }
            return null;
        }

        //select query for favrouites table
        public UserObject Favouriteselection(int user_id)
        {
            var selectQuery = "SELECT * FROM " + TableFavourite + " WHERE " + ColumnId + " ='" + user_id + "'";
            ICursor c = dbWritablObject.RawQuery(selectQuery, null);
            UserObject user;
            while (c.MoveToNext())
            {

                var idInfo = c.GetInt(c.GetColumnIndexOrThrow(ColumnId));
                System.Console.WriteLine("Value of id : " + idInfo);


                var nameInfo = c.GetString(c.GetColumnIndexOrThrow(ColumnName));
                System.Console.WriteLine("Value of name : " + nameInfo);

                var addressInfo = c.GetString(c.GetColumnIndexOrThrow(ColumnAddress));
                System.Console.WriteLine("Value of address : " + addressInfo);

                var dayInfo = c.GetString(c.GetColumnIndexOrThrow(ColumnDay));
                System.Console.WriteLine("Value of day : " + dayInfo);

                var priceInfo = c.GetInt(c.GetColumnIndexOrThrow(ColumnPrice));
                System.Console.WriteLine("Value of price : " + priceInfo);

                var categoryInfo = c.GetString(c.GetColumnIndexOrThrow(ColumnCategory));
                System.Console.WriteLine("Value of category : " + categoryInfo);
               
                if (user_id.Equals(idInfo))
                {
                    user = new UserObject(idInfo,nameInfo, addressInfo, dayInfo, priceInfo, categoryInfo);
                    c.Close();
                    return user;
                }
            }
            return null;
        }

        public void update(string u_email, string u_password,string u_age,string u_name)
        {
            var updateQuery="UPDATE "+TableName +" SET eMail ='" + u_email + "', password ='" + u_password  + "', age ='" + u_age + "' WHERE name ='"+ u_name + "'";
            System.Console.WriteLine("Insert  " + updateQuery);
            dbWritablObject.ExecSQL(updateQuery);
        }
    }
}