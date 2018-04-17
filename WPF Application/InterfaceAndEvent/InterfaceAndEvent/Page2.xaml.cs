using System.Windows;
using System.Windows.Controls;

namespace InterfaceAndEvent
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page, IChangePage
    {
        public Page2()
        {
            InitializeComponent();
        }

        public Page PageBack {get; set;}

        public event BackPageEventHandle BackPage;
        public event PageChangeEventHandle PageChange;

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            PageChange?.Invoke(MainWindow.PageEnum.Page3);
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {
            BackPage?.Invoke(PageBack);
        }
    }
}
