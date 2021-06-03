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
    public partial class AssistantPage : ContentPage
    {
        Editor titleEditor;
        Editor detailsEditor;
        Entry weightEntry;
        BoxView tempBoxView;

        public AssistantPage()
        {
            InitializeComponent();
            InitializeGeneratedElements();
        }

        /**
         * OptionsClicked displays the new notes and refresh button
         * on Notes page if the text for the button that initially
         * says Options, says Options. If it says Hide, then the
         * buttons are hidden/removed
         */
        private void NewTaskClicked(object sender, EventArgs e)
        {
            if (newTaskButton.Text == "New Task")
            {
                newTaskButton.Text = "Cancel";
                newTaskButtonsStack.Children.Clear();
                newTaskButtonsStack.Children.Add(titleEditor);
                newTaskButtonsStack.Children.Add(detailsEditor);
                newTaskButtonsStack.Children.Add(weightEntry);
                newTaskStack.Children.Add(tempBoxView);
            }

            else
            {
                newTaskButton.Text = "New Task";
                newTaskButtonsStack.Children.Remove(titleEditor);
                newTaskButtonsStack.Children.Remove(detailsEditor);
                newTaskButtonsStack.Children.Remove(weightEntry);
                newTaskStack.Children.Remove(tempBoxView);
            }
        }

        /**
         * InitializeButtons create the buttons for creating a new task
         * and refreshing the task stack, but does not display them.
         * Just gets them ready
         */
        private void InitializeGeneratedElements()
        {
            titleEditor = new Editor
            {
                Placeholder = "Title",
                FontSize = 40,
                TextColor = Color.White,
                Margin = new Thickness(0, 0, 0, 0),
                AutoSize = EditorAutoSizeOption.TextChanges,
                WidthRequest = 400
            };

            detailsEditor = new Editor
            {
                Placeholder = "Details",
                FontSize = 20,
                TextColor = Color.White,
                Margin = new Thickness(0, 30, 0, 0),
                AutoSize = EditorAutoSizeOption.TextChanges,
                WidthRequest = 400
            };

            weightEntry = new Entry
            {
                Placeholder = "Weight",
                FontSize = 20,
                Keyboard = Keyboard.Numeric,
                TextColor = Color.White,
                Margin = new Thickness(0, 30, 200, 0)
            };

            tempBoxView = new BoxView
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 1,
                Color = Color.White,
                Margin = new Thickness(0, 20, 0, 0)
            };
        }

        //<Editor Placeholder = "Title"
        //                FontSize="40"
        //                TextColor="White"
        //                Margin="0, 0, 0, 0"
        //                AutoSize="TextChanges"
        //                WidthRequest="400"/>
        //        <Editor Placeholder = "Details"
        //                FontSize="20"
        //                TextColor="White"
        //                Margin="0, 30, 0, 0"
        //                AutoSize="TextChanges"
        //                WidthRequest="400"/>
        //        <Entry Placeholder = "Weight"
        //               FontSize="20"
        //               Keyboard="Numeric"
        //               TextColor="White"
        //               Margin="0, 30, 200, 0" />
    }
}