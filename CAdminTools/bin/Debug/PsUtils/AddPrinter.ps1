



#Add-Printer -ConnectionName "\\WSPRINT07\CNTIS60"

(new-Object -ComObject WScript.Network).AddWindowsPrinterConnection("\\WSPRINT07\CNTIS60")