[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class SubPage : ContentPage
{
    public SubPage()
    {
        InitializeComponent();
        ReturnButton.Clicked += ReturnButton_Clicked;
    }
    private void ReturnButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync(true);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listview.ItemsSource = await App.Database.GetNotesAsync();
    }

    private async void OnAddButton2Clicked(object sender, EventArgs e)
    {
       /* var note = new Note()
        {
            OutstandingFee = int.Parse(OutstandingFeeEntry.Text),
            Point = int.Parse(PointEntry.Text)
        };

        noteRepository.Add(note);

        listview.ItemsSource = noteRepository.GetAll();*/
        if (!string.IsNullOrWhiteSpace(OutstandingFeeEntry.Text) && !string.IsNullOrWhiteSpace(PointEntry.Text))
        {
            await App.Database.SaveNoteAsync(new Note
            {
                OutstandingFee = int.Parse(OutstandingFeeEntry.Text),
                Point = int.Parse(PointEntry.Text),
                Date = DateTime.Now
            });

            OutstandingFeeEntry.Text = PointEntry.Text = string.Empty;
            listview.ItemsSource = await App.Database.GetNotesAsync();
        }
    }

    private async void TappedlistviewItem(object sender, ItemTappedEventArgs e)
    {
        var item = e.Item as Note;
        string action = await DisplayActionSheet("Select Action?", "Cancel", null, "Update", "Delete");
        string check = await DisplayActionSheet("Really?", "No", null, "Yes");
        if (check == "Yes")
        {
            if (action == "Delete")
            {
                await App.Database.DeleteNoteAsync(item);
                listview.ItemsSource = await App.Database.GetNotesAsync();
            }
            else if (action == "Update")
            {
                if (!string.IsNullOrWhiteSpace(OutstandingFeeEntry.Text) && !string.IsNullOrWhiteSpace(PointEntry.Text))
                {
                    item.OutstandingFee = int.Parse(OutstandingFeeEntry.Text);
                    item.Point = int.Parse(PointEntry.Text);
                    item.Date = DateTime.Now;
                    await App.Database.SaveNoteAsync(item);
                    OutstandingFeeEntry.Text = PointEntry.Text = string.Empty;
                    listview.ItemsSource = await App.Database.GetNotesAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Write the sentence in the text input.", "OK");
                }
            }
        }
    }
}
