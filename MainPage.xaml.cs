 public partial class MainPage : ContentPage
 {
     public MainPage()
     {
         InitializeComponent();
         NextButton.Clicked += NextButton_Clicked;
         NavigationPage.SetHasNavigationBar(this, false);
     }
     private void NextButton_Clicked(object sender, EventArgs e)
     {
         //Application.Current.MainPage = new BPage();
         //Navigation.PushModalAsync(new BPage());
         Navigation.PushAsync(new SubPage());
     }
     protected override async void OnAppearing()
     {
         base.OnAppearing();
         listview.ItemsSource = await App.Database.GetNotesAsync();
     }

     private async void OnAddButtonClicked(object sender, EventArgs e)
     {
         if (!string.IsNullOrWhiteSpace(AttendantEntry.Text) && !string.IsNullOrWhiteSpace(CustomerEntry.Text))
         {
             await App.Database.SaveNoteAsync(new Note
             {
                 Attendant = AttendantEntry.Text,
                 Customer = CustomerEntry.Text,
                 Date = DateTime.Now
             });

             AttendantEntry.Text = CustomerEntry.Text = string.Empty;
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
                 if (!string.IsNullOrWhiteSpace(AttendantEntry.Text) && !string.IsNullOrWhiteSpace(CustomerEntry.Text))
                 {
                     item.Attendant = AttendantEntry.Text;
                     item.Customer = CustomerEntry.Text;
                     item.Date = DateTime.Now;
                     await App.Database.SaveNoteAsync(item);
                     AttendantEntry.Text = CustomerEntry.Text = string.Empty;
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
