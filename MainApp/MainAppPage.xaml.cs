using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MainApp
{
    public partial class MainAppPage : TabbedPage
    {
        public static Dictionary<int, string> PageTypes = new Dictionary<int, string>();


        List<StackLayout> Layouts = new List<StackLayout>();

        public MainAppPage()
        {
            InitializeComponent();
            
            
            int j = 0;
            foreach (var type in Enum.GetValues(typeof(Util.Type)))
            {
                PageTypes.Add(j, type.ToString());
                j++;
            }

            for (int i = 0; i < PageTypes.Count; i++)
            {
                ContentPage cp = new ContentPage();
                cp.Title = PageTypes[i];

                StackLayout sl = new StackLayout();
                sl.Orientation = StackOrientation.Horizontal;

                ScrollView sv = new ScrollView();
                Layouts.Add(new StackLayout());

                cp.Content = sl;
                sl.Children.Add(sv);
                sv.Content = Layouts[i];
                Children.Add(cp);
            }
        }
        

        public void UpdateArticles()
        {
            Image i = new Image();
            i.Source =
                "https://images-na.ssl-images-amazon.com/images/I/610EksXe52L._SX355_.jpg";
            Label l1 = new Label();
            l1.Text = "author";

            Label l2 = new Label();
            l2.Text = DateTime.Now.ToString();

            Label l3 = new Label();
            l3.Text =
                "This is the main text. Tellson’s Bank near Temple Bar was an old-fashioned place, even back in 1780. It was very small, very dark, very ugly, and very uncomfortable. The partners who ran the bank were old-fashioned too. They were proud of its smallness, darkness, ugliness, and discomfort. They even boasted that their bank was all these things, and they believed that it if hadn’t been so unpleasant, it wouldn’t have been so well respected. The bankers liked to brag about this to their competitors. Tellson’s Bank, they would say, didn’t need elbow room or bright light or fancy decorations. Maybe Noakes and Co. or Snooks Brothers needed these things, but not Tellson’s Bank!";

            Article a = new Article(i, l1, l2, l3, Util.Type.Home);


            for (int j = 0; j < Layouts.Count; j++)
            {
                if (a.t == (Util.Type) j)
                {
                    Layouts[j].Children.Add(a);
                }
            }
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            UpdateArticles();
        }
    }
}