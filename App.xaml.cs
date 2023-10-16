public App()
{
    InitializeComponent();
    var page = new NavigationPage(new MainPage());

    MainPage = page;
}
static NoteDatabase database;

public static NoteDatabase Database
{
    get
    {
        if (database == null)
        {
            database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
        }
        return database;
    }
}
