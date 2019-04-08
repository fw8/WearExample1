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
        TextView textView;
        Button losGehts;
        TextView frage;

        Book book = new Book();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            textView = FindViewById<TextView>(Resource.Id.text);
            losGehts = FindViewById<Button>(Resource.Id.btnLosGehts);


            losGehts.Click += delegate {
                SetContentView(Resource.Layout.janein);
                frage = FindViewById<TextView>(Resource.Id.frageTxt);
                frage.Text = book.GetCurrentPage().Text;
                FindViewById<Button>(Resource.Id.jaBtn).Click += Ja_Click;
                FindViewById<Button>(Resource.Id.neinBtn).Click += Nein_Click;

            };

            //SetAmbientEnabled();
        }


        void Ja_Click(object sender, EventArgs e)
        {
            // Handle Ja
            SetContentView(Resource.Layout.janein);
            frage = FindViewById<TextView>(Resource.Id.frageTxt);
            frage.Text = book.GetNextPage(YesNoEnum.Yes).Text;
            FindViewById<Button>(Resource.Id.jaBtn).Click += Ja_Click;
            FindViewById<Button>(Resource.Id.neinBtn).Click += Nein_Click;
        }


        void Nein_Click(object sender, EventArgs e)
        {
            // Handle nein
            SetContentView(Resource.Layout.janein);
            frage = FindViewById<TextView>(Resource.Id.frageTxt);
            frage.Text = book.GetNextPage(YesNoEnum.No).Text;
            FindViewById<Button>(Resource.Id.jaBtn).Click += Ja_Click;
            FindViewById<Button>(Resource.Id.neinBtn).Click += Nein_Click;

        }
    }
}


