using System;
using System.Windows;
using System.Windows.Controls;

namespace InterfaceAndEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Page currentPage;
        private Page1 page1;
        private Page2 page2;
        private Page3 page3;

        public MainWindow()
        {
            InitializeComponent();
        }

        public enum PageEnum
        {
            Page1,
            Page2,
            Page3,
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            page1 = new Page1();
            page1.PageChange += ChangePage;
            page1.BackPage += BackPage;

            page2 = new Page2();
            page2.PageChange += ChangePage;
            page2.BackPage += BackPage;

            page3 = new Page3();
            page3.PageChange += ChangePage;
            page3.BackPage += BackPage;

            frame.NavigationService.Navigate(page1);
            currentPage = page1;
        }

        private void ChangePage(PageEnum page)
        {
            try
            {
                switch(page)
                {
                    case PageEnum.Page1:
                        page1.PageBack = currentPage;
                        frame.NavigationService.Navigate(page1);
                        currentPage = page1;
                        break;

                    case PageEnum.Page2:
                        page2.PageBack = currentPage;
                        frame.NavigationService.Navigate(page2);
                        currentPage = page2;
                        break;

                    case PageEnum.Page3:
                        page3.PageBack = currentPage;
                        frame.NavigationService.Navigate(page3);
                        currentPage = page3;
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error change page! ");
            }
        }

        private void BackPage(Page page)
        {
            if(page != null)
            {
                frame.NavigationService.Navigate(page);
            }
            if (page == page1)
                page1.PageBack = currentPage;
            if (page == page2)
                page2.PageBack = currentPage;
            if (page == page3)
                page3.PageBack = currentPage;

            currentPage = page;
        }
    }
}
