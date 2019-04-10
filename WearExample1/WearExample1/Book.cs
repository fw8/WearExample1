using System.Collections.Generic;

namespace WearExample1
{
    public enum YesNoEnum { No = 0, Yes };

    public class Book
    {
        public int currentPage { get; set; }
        private List<Page> pages { get; set; }

        public Book()
        {
            // create list
            pages = new List<Page>();

            //0
            pages.Add(new Page() { pageType = PageTypeEnum.Frage, text = "Hat es geschmeckt?", nextIfNo = 2, nextIfYes = 1 });

            //1 geschmeckt / ja - mehr?
            pages.Add(new Page() { pageType = PageTypeEnum.Frage, text = "OK, möchtest Du mehr?", nextIfNo = 2, nextIfYes = 0 });

            //2 geschmeckt / nein - nachtisch?
            pages.Add(new Page() { pageType = PageTypeEnum.Frage, text = "Schade, trotzdem noch Nachtisch?", nextIfNo = 4, nextIfYes = 3 });

            //3 nachtisch ja?
            pages.Add(new Page() { pageType = PageTypeEnum.Anweisung, text = "Alles klar, guten Appetit!", nextIfNo = 0, nextIfYes = 0 });

            //4 nachtisch2?
            pages.Add(new Page() { pageType = PageTypeEnum.Anweisung, text = "Schade!", nextIfNo = 0, nextIfYes = 0 });
        }

        public Page GetCurrentPage()
        {
            return pages[currentPage];
        }

        public Page GetNextPage(YesNoEnum answer)
        {
            int nextPage = pages[currentPage].nextIfNo;

            if (answer == YesNoEnum.Yes)
            {
                nextPage = pages[currentPage].nextIfYes;
            }

            Page np = pages[nextPage];
            currentPage = nextPage; // save state
            return (np);
        }

    }
}
