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
        private int currentViewId = -1;
        Book book = new Book();

        // Anwendung startet
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentViewToMain();

            SetAmbientEnabled();
        }

        private void SetContentViewToMain()
        {
            if (currentViewId != Resource.Layout.activity_main)  // ContentView nur wechseln wenn noetig
            {
                SetContentView(Resource.Layout.activity_main);
                currentViewId = Resource.Layout.activity_main;
                // und Callback fuer Button setzen
                FindViewById<Button>(Resource.Id.mainButton).Click += StartClicked;
            }
        }

        private void SetContentViewToQuery()
        {
            if (currentViewId != Resource.Layout.activity_query)  // ContentView nur wechseln wenn noetig
            {
                SetContentView(Resource.Layout.activity_query);
                currentViewId = Resource.Layout.activity_query;
                // und Callbacks fuer Buttons setzen
                FindViewById<Button>(Resource.Id.queryYesButton).Click += YesClicked;
                FindViewById<Button>(Resource.Id.queryNoButton).Click += NoClicked;
            }
        }

        void StartClicked(object sender, EventArgs e)
        {
            SetContentViewToQuery();
            FindViewById<TextView>(Resource.Id.queryText).Text = book.GetCurrentPage().text;
        }

        void YesClicked(object sender, EventArgs e)
        {
            // Weiterblaettern im Kontext von "Ja"
            ShowPage(book.GetNextPage(YesNoEnum.Yes));
        }

        void NoClicked(object sender, EventArgs e)
        {
            // Weiterblaettern im Kontext von "Nein"
            ShowPage(book.GetNextPage(YesNoEnum.No));
        }

        private void ShowPage(Page page)
        {
            if (page.pageType == PageTypeEnum.Query) // Enthaellt die Seite eine Frage?
            {
                SetContentViewToQuery();
                FindViewById<TextView>(Resource.Id.queryText).Text = page.text;
            }
            else // oder die finale Antwort?
            {
                SetContentViewToMain();
                FindViewById<TextView>(Resource.Id.mainText).Text = page.text;
                FindViewById<Button>(Resource.Id.mainButton).Text = "noch mal von Vorne"; ;
                book.Reset(); // alles wieder auf Anfang
            }
        }
    }
}
