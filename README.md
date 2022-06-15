# userToken
## Inhalt
- [userToken](#usertoken)
  - [Inhalt](#inhalt)
  - [Voraussetzungen](#voraussetzungen)
  - [Token](#token)
      - [Beispielausgabe](#beispielausgabe)
  - [Identity](#identity)
    - [Beispielausgabe](#beispielausgabe-1)
      - [identity](#identity-1)
      - [identity.Token](#identitytoken)
      - [identity.Name](#identityname)
      - [identity.User](#identityuser)
      - [identity.Owner](#identityowner)
      - [identity.AccessToken](#identityaccesstoken)
      - [identity.Actor](#identityactor)
      - [identity.Label](#identitylabel)
  - [Browser öffnen](#browser-öffnen)
  - [Autoren](#autoren)
## Voraussetzungen
- C#
## Token
- Returns a WindowsIdentity object that represents the current Windows user.
```C#
IntPtr accountToken = WindowsIdentity.GetCurrent().Token;
```
#### Beispielausgabe
```C#
780
```
## Identity
- Represents a Windows user.
```C#
WindowsIdentity identity = new WindowsIdentity(accountToken);
```
### Beispielausgabe
#### identity
```C#
780
```
#### identity.Token
```C#
784
```  
#### identity.Name
```C#
#HOST#\#NAME#
```
#### identity.User
```C#
S-1-5-21-2531573742-4144415368-2059679471-1001
```
#### identity.Owner
```C#
S-1-5-21-2531573742-4144415368-2059679471-1001
```
#### identity.AccessToken
```C#
Microsoft.Win32.SafeHandles.SafeAccessTokenHandle
```
#### identity.Actor
```C#
""
```
#### identity.Label
```C#
""
```
## Browser öffnen
```C#
try {
    System.Diagnostics.Process.Start(target);
} catch (System.ComponentModel.Win32Exception noBrowser) {
    if (noBrowser.ErrorCode == -2147467259)
        MessageBox.Show(noBrowser.Message);
} catch (System.Exception other) {
    MessageBox.Show(other.Message);
}
```
## Autoren
* **Kevin Müller** - [Profile](https://github.com/hydrokevin)
* **Milan Kovacevic** - [GitHub](https://github.com/miko41)