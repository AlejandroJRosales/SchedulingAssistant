using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SchedulingAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        private StackLayout parent;
        private Frame titleFrame;
        private Label titleLabel;
        private Label bodyLabel;
        private Button newNoteButton;
        private Button refreshButton;

        public NotesPage()
        {
            InitializeComponent();
            InitializeButtons();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayNotes();
        }

        private async void GenerateNoteView(NoteEntry note)
        {
            titleFrame = new Frame
            {
                Padding = new Thickness(20, 0, 20, 0),
                Margin = new Thickness(30, 20, 30, 0),
                BackgroundColor = Color.FromHex("#FFF8B1"),
                Opacity = 0
            };

            titleLabel = new Label
            {
                Text = note.Title,
                TextColor = Color.Black,
                FontSize = 30,
                BackgroundColor = Color.FromHex("#FFF8B1"),
                Opacity = 0
            };

            bodyLabel = new Label
            {
                Text = note.Body,
                TextColor = Color.Black,
                BackgroundColor = Color.FromHex("#FFF8B1"),
                Opacity = 0
            };

            // label tap event
            var note_tap = new TapGestureRecognizer();
            // when the user taps the title label or the body
            // label button, 
            note_tap.Tapped += (s, e) =>
            {
                Device.BeginInvokeOnMainThread(async () => {
                    OpenedNotePage openNotePage = new OpenedNotePage(note);
                    await Navigation.PushAsync(openNotePage);
                });
            };
            // add the gesture recognizers to the note
            bodyLabel.GestureRecognizers.Add(note_tap);
            titleLabel.GestureRecognizers.Add(note_tap);

            // set StackLayout in XAML to the class field
            parent = notesStack;

            // add the new note to the StackLayout
            parent.Children.Add(titleFrame);
            parent.Children.Add(titleLabel);
            parent.Children.Add(bodyLabel);

            titleFrame.FadeTo(1, 1000);
            titleLabel.FadeTo(1, 1000);
            bodyLabel.FadeTo(1, 1000);
        }

        /**
         * ResetListViewSources updates the list view of notes the user has made
         * by clearing the stack and adding each note, including the new note, to
         * the notes stack
         */
        private void ResetNotesStackLayout()
        {
            notesStack.Children.Clear();
            foreach (NoteEntry note in NotesDB.conn.Table<NoteEntry>())
            {
                GenerateNoteView(note);
            }
        }

        private async void DisplayNotes()
        {
            await Task.Delay(500);
            ResetNotesStackLayout();
        }

        /**
         * NewNoteClicked brings up an Entry to enter in the users
         * note then click on the note they want to edit
         */
        private async void NewNoteClicked(object buttonSender, EventArgs e)
        {
            CreateNote createNotePage = new CreateNote();
            await Navigation.PushAsync(createNotePage);
            MessagingCenter.Subscribe<CreateNote>(this, "CreateNoteClicked", (sender) =>
            {
                ResetNotesStackLayout();
            });
            MessagingCenter.Unsubscribe<CreateNote, string>(this, "CreateNoteClicked");
        }

        /**
         * ResetView refreshes the notes stack
         */
        private void ResetView(object buttonSender, EventArgs e)
        {
            ResetNotesStackLayout();
        }

        /**
         * OptionsClicked displays the new notes and refresh button
         * on Notes page if the text for the button that initially
         * says Options, says Options. If it says Hide, then the
         * buttons are hidden/removed
         */
        private void OptionsClicked(object buttonSender, EventArgs e)
        {
            if (optionsButton.Text == "Options")
            {
                optionsButton.Text = "Hide";
                optionsButtonsStack.Children.Add(newNoteButton);
                optionsButtonsStack.Children.Add(refreshButton);
            }

            else
            {
                optionsButton.Text = "Options";
                optionsButtonsStack.Children.Remove(newNoteButton);
                optionsButtonsStack.Children.Remove(refreshButton);
            }
        }

        /**
         * InitializeButtons create the buttons for creating a new note
         * and refreshing the note stack, but does not display them.
         * Just gets them ready
         */
        private void InitializeButtons()
        {
            newNoteButton = new Button
            {
                Text = "New Note",
                FontSize = 12,
                BackgroundColor = Color.FromHex("#FFB33E"),
                Margin = new Thickness(30, 0, 0, 0)
            };
            newNoteButton.Clicked += NewNoteClicked;

            refreshButton = new Button
            {
                Text = "Refresh",
                FontSize = 12,
                BackgroundColor = Color.Gray,
            };
            refreshButton.Clicked += ResetView;
        }
    }
}