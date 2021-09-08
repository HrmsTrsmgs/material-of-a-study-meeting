using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
{
    //Xaml1
    var page = new Page();
}

{
    //Xaml2
    var page = new Page();
    page.AccessKey = "A";
}
{
    //Xaml2
    var page = new Page { AccessKey = "A" };
}
{
    //Xaml3
    var page = new Page { TabIndex = 1 };
}
{
    //Xaml4
    var page = new Page { Width = 45.85 };
}
{
    //Xaml5
    var page = new Page { CanDrag = true };
}

{
    //Xaml6
    var page = new Page 
    {
        Background = new SolidColorBrush(Colors.Green) 
    };
}
{
    //Xaml7
    var page = new Page
    {
        Content = new Button()
    };
}
{
    //Xaml8
    var page = new Page
    {
        Content = new Button()
    };
}
{
    //Xaml9
    var page = new Page
    {
        Content = new Button { Content = "ボタン"}
    };
}
{
    //Xaml10
    var page = new Page
    {
        Content = new Button { Content = new string("") }
    };
}
{
    //Xaml11
    var page = new Page
    {
        Content = new Button { Content = "ボタン" }
    };
}
{
    //Xaml12
    var page = new Page
    {
        Content = new Button
        {
            Content = new Rectangle
            {
                Width = 100,
                Height = 50,
                Fill = new SolidColorBrush(Colors.Blue)
            }
        }
    };
}