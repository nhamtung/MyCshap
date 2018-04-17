using System.Windows.Controls;

namespace InterfaceAndEvent
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="page"></param>

    public delegate void PageChangeEventHandle(MainWindow.PageEnum page);
    public delegate void BackPageEventHandle(Page page);
    interface IChangePage
    {
        event PageChangeEventHandle PageChange;
        event BackPageEventHandle BackPage;

        Page PageBack { get; set; }
    }
}
