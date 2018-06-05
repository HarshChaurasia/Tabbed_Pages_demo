using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Tabbed_Pages
{
    public partial class Tabbed_PagesPage : TabbedPage
    {
        public Tabbed_PagesPage()
        {
            InitializeComponent();
            ItemsSource = MonkeyDataModel.All;
        }
        protected Stack<Page> TabStack { get; private set; } = new Stack<Page>();

        protected override void OnCurrentPageChanged()
        {

            // current page
            var page = CurrentPage;
            if (page != null)
            {
                // Push the page onto the stack
                TabStack.Push(page);
            }

            base.OnCurrentPageChanged();
        }

        protected override bool OnBackButtonPressed()
        {

            // Go to previous page in the stack. First, 
            //pop off the top page since this represents the
            // current page we are on.
            if (TabStack.Any())
            {
                TabStack.Pop();
            }

            // Check if we have any pages left
            if (TabStack.Any())
            {
                // Pop off the next page and Launch it
                CurrentPage = TabStack.Pop();
                // Return true to indicate we handled this scenario
                return true;
            }
            return false;

        }
    }
}
