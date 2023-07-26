Set WshShell = CreateObject("WScript.Shell") 
WshShell.Run chr(34) & "dpscat.exe" & Chr(34), 0
Set WshShell = Nothing
