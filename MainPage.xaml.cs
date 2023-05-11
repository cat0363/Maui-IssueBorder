using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Maui_IssueBorder;

public partial class MainPage : ContentPage
{
    ObservableCollection<TestItem> TestItems = new ObservableCollection<TestItem>();

    public MainPage()
    {
        InitializeComponent();

        for (int i = 0; i < 10; i++)
        {
            TestItems.Add(new TestItem() { ItemName = "Item " + (i + 1) });
        }
        BindableLayout.SetItemsSource(slTestItems1, TestItems);
        BindableLayout.SetItemsSource(slTestItems2, TestItems);

        slTestItems1.SizeChanged += (object sender, EventArgs e) =>
        {
            (svTestItems1 as IView).InvalidateMeasure();
        };
        slTestItems2.SizeChanged += (object sender, EventArgs e) =>
        {
            (svTestItems2 as IView).InvalidateMeasure();
        };
    }
}

public class TestItem
{
    public string ItemName { get; set; }    
}

