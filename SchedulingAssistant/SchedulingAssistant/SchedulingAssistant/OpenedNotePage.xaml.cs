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
    public partial class OpenedNotePage : ContentPage
    {
        private NoteEntry oldNote;

        public OpenedNotePage(NoteEntry note)
        {
            InitializeComponent();
            oldNote = note;
            FillNoteView();
        }

        private void FillNoteView()
        {
            titleEntry.Text = oldNote.Title;
            bodyEditor.Text = oldNote.Body;
        }

        private void SubmitChangesClicked(object buttonSender, EventArgs e)
        {
            NoteEntry newNote = new NoteEntry
            {
                Title = titleEntry.Text,
                Body = bodyEditor.Text
            };
            newNote.Id = oldNote.Id;
            NotesDB.conn.Update(newNote);
        }

        /**
         * DeleteNoteClicked deletes the note that was selected from
         * the notes stack
         */
        private async void DeleteNoteClicked(object buttonSender, EventArgs e)
        {
            bool deleteNote = await DisplayAlert("Delete Note", "Are you sure you want to delete the note?", "Yep", "Nope");
            if (deleteNote)
            {
                NotesDB.conn.Delete(oldNote);
                await Navigation.PopAsync();
            }
        }
    }
}