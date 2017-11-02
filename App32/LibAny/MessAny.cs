using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LibAny
{
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IMessAny
    {
        void Show();
    }
    
    [ClassInterface(ClassInterfaceType.None)]
    public class MessAny : IMessAny
    {
        public void Show()
        {
            MessageBox.Show("Mess OK");
        }
    }
}