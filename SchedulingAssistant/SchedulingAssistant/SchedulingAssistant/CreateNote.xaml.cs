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
    public partial class CreateNote : ContentPage
    {
        public CreateNote()
        {
            InitializeComponent();
        }

        /**
         * NewEntry adds the note the user made to the NoteDB
         */
        private void NewEntry()
        {
            try
            {
                NoteEntry noteEntry = new NoteEntry
                {
                    Title = titleEntry.Text,
                    Body = bodyEntry.Text
                };
                NotesDB.conn.Insert(noteEntry);
            }
            catch
            {
                DisplayAlert("Oops", "Your entry is invalid, please try again", "Okie doke");
            }
        }

        private async void CreateClicked(object sender, EventArgs e)
        {
            NewEntry();
            // send a message to CreateNote saying that the create button was clicked
            // so that the list view of notes can reset
            MessagingCenter.Send<CreateNote>(this, "CreateNoteClicked");
            await Navigation.PopAsync();
        }
    }
}