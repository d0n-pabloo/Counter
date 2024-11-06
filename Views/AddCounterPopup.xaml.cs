using CommunityToolkit.Maui.Views;

namespace CounterApp2.Views;

public partial class AddCounterPopup : Popup
{
    public event Action<string, int, string> CounterCreated;

    public AddCounterPopup()
    {
        InitializeComponent();
    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
        var name = NameEntry.Text;
        var initialValue = int.TryParse(ValueEntry.Text, out int value) ? value : 0;
        var color = "#" + ColorEntry.Text;

        CounterCreated?.Invoke(name, initialValue, color);
        Close();
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close();
    }
}