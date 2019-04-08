using System;
using System.Collections.Generic;

namespace WearExample1
{
    public enum YesNoEnum { No=0, Yes };

    public class Book
    {
        public int CurrentPage { get; set; }
        private List<Page> Pages { get; set; }

        public Book()
        {
            // create list
            Pages = new List<Page>();

            //0
            Pages.Add(new Page() { PageType = PageTypeEnum.Frage, Text = "Hat es geschmeckt?", NextIfNo = 2, NextIfYes = 1 });

            //1 geschmeckt / ja - mehr?
            Pages.Add(new Page() { PageType = PageTypeEnum.Frage, Text = "OK, möchtest Du mehr?", NextIfNo = 2, NextIfYes = 0 });

            //2 geschmeckt / nein - nachtisch?
            Pages.Add(new Page() { PageType = PageTypeEnum.Frage, Text = "Schade, trotzdem noch Nachtisch?", NextIfNo = 4, NextIfYes = 3 });

            //3 nachtisch ja?
            Pages.Add(new Page() { PageType = PageTypeEnum.Anweisung, Text = "Alles klar, guten Appetit!", NextIfNo = 0, NextIfYes = 0 });

            //4 nachtisch2?
            Pages.Add(new Page() { PageType = PageTypeEnum.Anweisung, Text = "Schade!", NextIfNo = 0, NextIfYes = 0 });
        }

        public Page GetCurrentPage()
        {
            return Pages[CurrentPage];
        }


        public Page GetNextPage(YesNoEnum answer)
        {
            int NextPage = Pages[CurrentPage].NextIfNo;

            if (answer == YesNoEnum.Yes) {
                NextPage = Pages[CurrentPage].NextIfYes;
            }

            Page np = Pages[NextPage];
            CurrentPage = NextPage; // save state
            return (np);
        }

    }
}
