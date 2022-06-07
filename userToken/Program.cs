using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace userToken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntPtr accountToken = WindowsIdentity.GetCurrent().Token;
            
            string target = "http://localhost:3030/echo.php?echo=" + accountToken + "";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
}
