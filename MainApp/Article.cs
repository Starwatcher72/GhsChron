using Xamarin.Forms;

namespace MainApp
{
    public class Article : Frame
    {
        private StackLayout _stackLayout;
        private Image _image;
        private Label author;
        private Label date;
        private Label summaryText;
        private Label mainText;
        private Button readMoreButton;
        public Util.Type t;
        
        public Article(Image image, Label author, Label date, Label mainText, Util.Type t)
        {
            this.t = t;
            _stackLayout = new StackLayout();
            _image = image;
            this.author = author;
            this.date = date;
            this.mainText = mainText;
            _stackLayout.Children.Add(_image);
            StackLayout tempSL = new StackLayout();
            tempSL.Orientation = StackOrientation.Horizontal;
            tempSL.Children.Add(this.author);
            tempSL.Children.Add(this.date);
            _stackLayout.Children.Add(tempSL);
            summaryText = new Label();
            summaryText.Text = Util.BreakLines(mainText.Text).Substring(0, 99);
            mainText.IsVisible = false;
            _stackLayout.Children.Add(summaryText);
            _stackLayout.Children.Add(this.mainText);
            
            readMoreButton = new Button();
            readMoreButton.Text = "Read More";
            readMoreButton.Clicked += (object sender, System.EventArgs e) => ReadMore(sender, e);
            _stackLayout.Children.Add(readMoreButton);
            
            CornerRadius = 20;
            OutlineColor = Color.Silver;
            Margin = new Thickness(0, 10, 0 , 10);
            Content = _stackLayout;
            
        }

        public void ReadMore(object sender, System.EventArgs e)
        {
            summaryText.IsVisible = Util.invertBool(summaryText.IsVisible);
            mainText.IsVisible = Util.invertBool(mainText.IsVisible);
        }
        
    }
}