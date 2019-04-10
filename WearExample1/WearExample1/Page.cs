namespace WearExample1
{
    public enum PageTypeEnum { Frage, Anweisung }

    public class Page
    {
        public string text { get; set; }
        public PageTypeEnum pageType { get; set; }
        public int nextIfYes { get; set; }
        public int nextIfNo { get; set; }
    }
}
