using System;
namespace WearExample1
{
    public enum PageTypeEnum { Frage, Anweisung }

    public class Page
    {

        public String Text { get; set; }
        public PageTypeEnum PageType { get;  set; }
        public int NextIfYes { get; set; }
        public int NextIfNo { get; set; }
    }
}
