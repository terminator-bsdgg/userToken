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
            //IntPtr accountToken = WindowsIdentity.GetCurrent().Token;

            // accountToken entspricht logonToken
            
            // https://docs.microsoft.com/de-de/dotnet/api/system.security.principal.windowsidentity?view=net-6.0
            // Retrieve the Windows account token for the current user.
            Console.WriteLine("-----------------Logon------------------------------");
            IntPtr logonToken = WindowsIdentityMembers.LogonUser();
            // Constructor implementations.
            Console.WriteLine("-----------------Constructor------------------------");
            WindowsIdentityMembers.IntPtrConstructor(logonToken);
            Console.WriteLine("-----------------StringConstructor------------------");
            WindowsIdentityMembers.IntPtrStringConstructor(logonToken);
            Console.WriteLine("-----------------StringTypeConstructor--------------");
            WindowsIdentityMembers.IntPtrStringTypeConstructor(logonToken);
            Console.WriteLine("-----------------StringTypeBoolConstructor----------");
            WindowsIdentityMembers.IntPrtStringTypeBoolConstructor(logonToken);

            // Property implementations.
            Console.WriteLine("-----------------UseProperties----------------------");
            WindowsIdentityMembers.UseProperties(logonToken);

            // Method implementations.
            Console.WriteLine("-----------------GetAnonymousUser-------------------");
            WindowsIdentityMembers.GetAnonymousUser();
            Console.WriteLine("-----------------ImpersonateIdentity----------------");
            WindowsIdentityMembers.ImpersonateIdentity(logonToken);
            
            Console.WriteLine("This sample completed successfully; " +
                "press Enter to exit.");
            
            Console.WriteLine("-----------------Open Browser-----------------------");
            Console.ReadLine();

           
            
            string target = "http://localhost:3030/echo.php?echo=" + logonToken + "";
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
