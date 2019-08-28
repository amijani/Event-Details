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
    class UserObject
    {
        public string name, address;
        public string day;
        public int price;
        public string category;
        public int id;
        public UserObject()
        {
        }

        public UserObject(int myid,String myName, string myaddress, string myday,int myprice,string myCategory)
        {
            id= myid;
            name = myName;
            address = myaddress;
            day = myday;
            price = myprice;
            category = myCategory;
        }

        public List<UserObject> createListOfUsers()
        {

            List<UserObject> myList = new List<UserObject>();

            myList.Add(new UserObject(1,"NEST",  "420 College Street","14 April 2019 ",20,"Clubbing"));
            myList.Add(new UserObject(2,"OASIS AQUALOUNGE",  "80 Dundas Street", "18 April 2019", 50, "Clubbing"));
            myList.Add(new UserObject(3,"REBEL",  "151 Bay Street", "24 April 2019", 20,"Clubbing"));
            myList.Add(new UserObject(4,"FLY",  "55 Don Mills Road", "2 May 2019", 100, "Clubbing"));
            myList.Add(new UserObject(5,"Lula Lounge", "55 King Street", "4 May 2019", 20, "Clubbing"));
            myList.Add(new UserObject(8,"Vertigo", "95 Broadview Park", "7 MAY 2019", 50 , "Clubbing"));
            myList.Add(new UserObject(6,"Revival", "25 Bay Street", "24 April 2019 ", 20 , "Clubbing"));
            myList.Add(new UserObject(7,"Soho House", "783 College Street", "2 May 2019", 50, "Clubbing"));

            return myList;
        }

        public List<UserObject> createListOfUsers1()
        {

            List<UserObject> myList1 = new List<UserObject>();

            myList1.Add(new UserObject(1,"The Loose Moose", "146 Front Street West", "24 April 2019", 50, "Food and drinks"));
            myList1.Add(new UserObject(2,"Jack Astors", "80 Dundas Street", "28 April 2019", 50, "Food and Drinks"));
            myList1.Add(new UserObject(3,"Kelsyes", "151 Bay Street", "2 May 2019", 20, "Food and drinks"));
            myList1.Add(new UserObject(4,"Mulberry", "55 Don Mills Road", "5 May 2019", 100, "Food and drinks"));
            myList1.Add(new UserObject(5,"Hive Esports", "25 Front Street", "8 May 2019 ", 20, "Food and drinks"));
            myList1.Add(new UserObject(6,"The Rooftop", "146 Bayview Avenue", "24 April 2019", 50, "Food and Drinks"));
            myList1.Add(new UserObject(7,"Duke's", "346 Yonge Street", "10 May 2019 ", 20, "Food and drinks"));
            myList1.Add(new UserObject(8,"Woody's", "5 Broadview Avenue", "12 May 2019 ", 50, "Food and drinks"));

            return myList1;
        }

        public List<UserObject> createListOfUsers2()
        {

            List<UserObject> myList2 = new List<UserObject>();

            myList2.Add(new UserObject(1,"Skate For Sarah", "986 Murray Ross", "14 April 2019 ", 20, "Sports"));
            myList2.Add(new UserObject(2,"Blue Jays vs San Francisco", "Rogers Center", "23 April 2019", 50 , "Sports"));
            myList2.Add(new UserObject(3,"Toronto Cup", "159 Dynamic Drive", "26 April 2019", 20 , "Sports"));
            myList2.Add(new UserObject(4,"NHL Finals", "Scotiabank Arena", "20 April 2019 ", 50, "Sports"));
            myList2.Add(new UserObject(5,"Battle Of The Badges", "989 Murray Ross", "20 May 2019 ", 20, "Sports"));
            myList2.Add(new UserObject(6,"NBA Finals", "Scotiabank Arena", "15 May 2019", 50 , "Sports"));
            myList2.Add(new UserObject(7,"Everything In Soccer", "650 Dixon Rd", "2nd May 2019 ", 20 , "Sports"));
            myList2.Add(new UserObject(8,"Toronto May Madness", "989 Murray Ross", "4 May 2019", 50, "Sports"));

            return myList2;
        }

        public List<UserObject> createListOfUsers3()
        {

            List<UserObject> myList3 = new List<UserObject>();

            myList3.Add(new UserObject(1,"Content Marketing", "136 Geary Avenue", "13 April 2019", 100, "Workshop"));
            myList3.Add(new UserObject(2,"Chocolate and Caramel Workshop", "The Mad Bean Coffee House", "26 April 2019", 150, "Workshop"));
            myList3.Add(new UserObject(3,"Think Your Stress", "George Brown College", "9 April 2019", 200, "Workshop"));
            myList3.Add(new UserObject(4,"Beyond Digital", "Toronto Public Library", "10 May 2019 ", 150, "Workshop"));
            myList3.Add(new UserObject(5,"Poetry Workshop", "House Of Anansi Press", "8 May 2019 ", 150, "Workshop"));
            myList3.Add(new UserObject(6,"Yoga Workshop", "Sony Centre", "10 April 2019",100, "Workshop"));
            myList3.Add(new UserObject(7,"Brain-Based Learning", "Sheraton Toronto", "30 April 2019 ", 200, "Workshop"));
            myList3.Add(new UserObject(8,"Microsoft Excel Training Conference", "1 Yonge Street", "8 May 2019", 150, "Workshop"));


            return myList3;
        }


        public List<UserObject> createListOfFav()
        {

            List<UserObject> myFavList = new List<UserObject>();

            return myFavList;
        }

    }
}