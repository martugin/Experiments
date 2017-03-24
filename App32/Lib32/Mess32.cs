using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lib32
{
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IMess32
    {
        void Show();
    }
    
    [ClassInterface(ClassInterfaceType.None)]
    public class Mess32 : IMess32
    {
        public void Show()
        {
            MessageBox.Show("Mess OK");
        }
    }
}