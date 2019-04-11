using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Wearable.Views;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Wearable.Activity;
using Java.Interop;
using Android.Views.Animations;

namespace WearExample1
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : WearableActivity
    {
        Button losGehts;
        TextView frage;

        Book book = new Book();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            losGehts = FindViewById<Button>(Resource.Id.btnLosGehts);
            losGehts.Click += LosGehts;

            SetAmbientEnabled();
        }

        void LosGehts(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.janein);
            frage = FindViewById<TextView>(Resource.Id.frageTxt);
            frage.Text = book.GetCurrentPage().text;
            FindViewById<Button>(Resource.Id.jaBtn).Click += JaClick;
            FindViewById<Button>(Resource.Id.neinBtn).Click += NeinClick;
        }

        void JaClick(object sender, EventArgs e)
        {
            // Handle Ja
            Page page = book.GetNextPage(YesNoEnum.Yes);
            if (page.pageType == PageTypeEnum.Frage)
            {
                SetContentView(Resource.Layout.janein);
                FindViewById<TextView>(Resource.Id.frageTxt).Text = page.text;
                FindViewById<Button>(Resource.Id.jaBtn).Click += JaClick;
                FindViewById<Button>(Resource.Id.neinBtn).Click += NeinClick;
            }
            else
            {
                SetContentView(Resource.Layout.activity_main);
                FindViewById<TextView>(Resource.Id.antwortTxt).Text = page.text;
                losGehts = FindViewById<Button>(Resource.Id.btnLosGehts);
                losGehts.Text = "noch mal von Vorne";
                book.currentPage = 0;
                losGehts.Click += LosGehts;
            }
        }


        void NeinClick(object sender, EventArgs e)
        {
            // Handle nein
            Page page = book.GetNextPage(YesNoEnum.No);
            if (page.pageType == PageTypeEnum.Frage)
            {
                SetContentView(Resource.Layout.janein);
                FindViewById<TextView>(Resource.Id.frageTxt).Text = page.text;
                FindViewById<Button>(Resource.Id.jaBtn).Click += JaClick;
                FindViewById<Button>(Resource.Id.neinBtn).Click += NeinClick;
            }
            else
            {
                SetContentView(Resource.Layout.activity_main);
                FindViewById<TextView>(Resource.Id.antwortTxt).Text = page.text;
                losGehts = FindViewById<Button>(Resource.Id.btnLosGehts);
                losGehts.Text = "noch mal von Vorne";
                book.currentPage = 0;
                losGehts.Click += LosGehts;
            }
        }
    }
}


