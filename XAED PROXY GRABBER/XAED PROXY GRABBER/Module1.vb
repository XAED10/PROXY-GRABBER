Imports System.IO, System.Text.RegularExpressions, System.Console
Imports System.Threading
Module Module1
    Dim proxies As String
    Dim webbie As New Net.WebClient
    Dim proxyapi As String = File.ReadAllText("PROXY API.txt")
    Dim https, http, socks4, socks5 As String
    Dim banner As String = " __   __         ______ _____    _____  _____   ______   ___     __   _____ _____           ____  ____  ______ _____  
 \ \ / /   /\   |  ____|  __ \  |  __ \|  __ \ / __ \ \ / \ \   / /  / ____|  __ \    /\   |  _ \|  _ \|  ____|  __ \ 
  \ V /   /  \  | |__  | |  | | | |__) | |__) | |  | \ V / \ \_/ /  | |  __| |__) |  /  \  | |_) | |_) | |__  | |__) |
   > <   / /\ \ |  __| | |  | | |  ___/|  _  /| |  | |> <   \   /   | | |_ |  _  /  / /\ \ |  _ <|  _ <|  __| |  _  / 
  / . \ / ____ \| |____| |__| | | |    | | \ \| |__| / . \   | |    | |__| | | \ \ / ____ \| |_) | |_) | |____| | \ \ 
 /_/ \_\_/    \_\______|_____/  |_|    |_|  \_\\____/_/ \_\  |_|     \_____|_|  \_\_/    \_\____/|____/|______|_|  \_\
                                                                                                                      "
    Sub Main()
        If My.Computer.FileSystem.FileExists("Grabbed Proxies.txt") Then
            My.Computer.FileSystem.DeleteFile("Grabbed Proxies.txt")
        End If
        http = Regex.Match(proxyapi, "http{(.*?)}").Groups(1).Value  'MsgBox(http)
        https = Regex.Match(proxyapi, "https{(.*?)}").Groups(1).Value  'MsgBox(https)
        socks4 = Regex.Match(proxyapi, "socks4{(.*?)}").Groups(1).Value  'MsgBox(socks4)
        socks5 = Regex.Match(proxyapi, "socks5{(.*?)}").Groups(1).Value  'MsgBox(socks5)
        ForegroundColor = ConsoleColor.Blue
        Write(banner)
        ForegroundColor = ConsoleColor.Magenta
        Write(vbNewLine & "Choose Proxy Type :" + vbNewLine + "[1] HTTP" + vbNewLine + "[2] HTTPS" + vbNewLine + "[3] SOCKS 4" + vbNewLine + "[4] SOCKS 5" + vbNewLine + "[?] : ")
        Dim proxychoice As String = ReadLine()
        If proxychoice = "1" Then
            getproxies(http)
        ElseIf proxychoice = "2" Then
            getproxies(https)
        ElseIf proxychoice = "3" Then
            getproxies(socks4)
        ElseIf proxychoice = "4" Then
            getproxies(socks5)
        End If
    End Sub
    Sub getproxies(api As String)
        Try
            proxies = webbie.DownloadString(String.Format(api))
            ForegroundColor = ConsoleColor.Green
            Write(vbNewLine + "Grabbed Proxies : " + vbNewLine + proxies + vbNewLine + "Thank You For Using XAED PROXY GRABBER, FOLLOW ME ON INSTAGRAM => instagram.com/xaed or @xaed")
            My.Computer.FileSystem.WriteAllText("Grabbed Proxies.txt", "Grabbed Proxies : " + vbNewLine + proxies + vbNewLine + "Thank You For Using XAED PROXY GRABBER, FOLLOW ME ON INSTAGRAM => instagram.com/xaed or @xaed", False)
            Thread.Sleep(1500)
            ForegroundColor = ConsoleColor.Red
            Write(vbNewLine + "[X] Press Enter To Exit")
            ReadLine()
            Environment.Exit(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
