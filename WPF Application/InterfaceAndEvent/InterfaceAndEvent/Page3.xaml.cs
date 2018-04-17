using System;
using System.Windows;
using System.Windows.Controls;

namespace InterfaceAndEvent
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page, IChangePage
    {

        public Page3()
        {
            InitializeComponent();
        }

        public Page PageBack { get; set; }
        public event PageChangeEventHandle PageChange;
        public event BackPageEventHandle BackPage;
       
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            PageChange?.Invoke(MainWindow.PageEnum.Page1);
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {
            BackPage?.Invoke(PageBack);
        }
    }
}
