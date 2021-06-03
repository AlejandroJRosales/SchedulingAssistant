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
            TaskInputAnimation();
        }

        private async void TaskInputAnimation()
        {
            if (newTaskButton.Text == "New Task")
            {
                newTaskButton.Text = "Cancel";
                newTaskInputStack.Children.Add(titleEditor);
                newTaskInputStack.Children.Add(detailsEditor);
                newTaskInputStack.Children.Add(weightEntry);
                newTaskStack.Children.Add(tempBoxView);
                titleEditor.FadeTo(1, 2000);
                detailsEditor.FadeTo(1, 2000);
                weightEntry.FadeTo(1, 2000);
            }

            else
            {
                newTaskButton.Text = "New Task";
                titleEditor.FadeTo(0, 250);
                detailsEditor.FadeTo(0, 250);
                weightEntry.FadeTo(0, 250);
                await Task.Delay(250);
                newTaskInputStack.Children.Remove(titleEditor);
                newTaskInputStack.Children.Remove(detailsEditor);
                newTaskInputStack.Children.Remove(weightEntry);
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
                WidthRequest = 400,
                Opacity = 0
            };

            detailsEditor = new Editor
            {
                Placeholder = "Details",
                FontSize = 20,
                TextColor = Color.White,
                Margin = new Thickness(0, 30, 0, 0),
                AutoSize = EditorAutoSizeOption.TextChanges,
                WidthRequest = 400,
                Opacity = 0
            };

            weightEntry = new Entry
            {
                Placeholder = "Weight",
                FontSize = 20,
                Keyboard = Keyboard.Numeric,
                TextColor = Color.White,
                Margin = new Thickness(0, 30, 200, 0),
                Opacity = 0
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