using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lib64
{
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IMess64
    {
        void Show();
    }
    
    [ClassInterface(ClassInterfaceType.None)]
    public class Mess64 : IMess64
    {
        public void Show()
        {
            MessageBox.Show("Mess OK");
        }
    }
}