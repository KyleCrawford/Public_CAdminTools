
#modified to remove print server names


$printerList = Get-WMIObject Win32_Printer -ComputerName $env:COMPUTERNAME | select-object name | where-object {$_.name -like "\\*"}

foreach ($printer in $printerList)
{
    remove-printer -name $printer.name
    #$printer.name
    #(New-Object -ComObject WScript.Network).RemovePrinterConnection($printer.name)
}

(new-Object -ComObject WScript.Network).AddWindowsPrinterConnection("\\PrintServer\CNTIS60")
(New-Object -ComObject WScript.Network).SetDefaultPrinter("\\PrintServer\CNTIS60")

