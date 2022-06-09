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
            //windowsIdentityDemo();
            //Console.WriteLine();

            Console.WriteLine("Load WindowsIdentity token -- Press Enter");
            Console.ReadKey();
            IntPtr accountToken = getCurrentUserToken();
            Console.WriteLine(accountToken);
            Console.WriteLine();

            Console.WriteLine("Load user data from WindowsIdentity token -- Press Enter");
            Console.ReadKey();
            // https://csharp.hotexamples.com/de/examples/-/WindowsIdentity/-/php-windowsidentity-class-examples.html
            WindowsIdentity identity = getUserIdentity(accountToken);
            //identity.Impersonate();
            Console.WriteLine("Name:");
            Console.WriteLine(identity.Name);
            Console.WriteLine("Label:");
            Console.WriteLine(identity.Label);
            Console.WriteLine("User:");
            Console.WriteLine(identity.User);
            Console.WriteLine("Owner:");
            Console.WriteLine(identity.Owner);
            Console.WriteLine("AccessToken:");
            Console.WriteLine(identity.AccessToken);
            Console.WriteLine("Actor:");
            Console.WriteLine(identity.Actor);
            Console.WriteLine("Token:");
            Console.WriteLine(identity.Token);
            Console.WriteLine();

            

            string url = "http://localhost:3030/echo.php?echo=";
            Console.WriteLine("Send WindowsIdentity token to " + url + identity + " -- (Press Enter)");
            Console.ReadKey();
            openUrl(url, accountToken);
        }

        static WindowsIdentity getUserIdentity(IntPtr accountToken)
        {
            return new WindowsIdentity(accountToken);
        }

        static IntPtr getCurrentUserToken()
        {
            return WindowsIdentity.GetCurrent().Token;
        }

        static void openUrl(string url, IntPtr data)
        {
            string target = url + data;
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

        static void windowsIdentityDemo()
        {
            // !!!! accountToken entspricht logonToken
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
        }
    }
}
