@echo off

cls
:start

    set /P UserInput=Please enter the name of the printer wish to find:

    set NotFound=No Printer Found!

    setlocal enabledelayedexpansion

    set "baseName=chprint"

cls

    echo Searching chprint

    for /l %%a in (1 1 9) do (

        set "n=0%%a"

                net view \\%baseName%!n:~-2! | findstr /I %UserInput% && echo \\%baseName%!n:~-2! %UserInput%

    )         

    echo Searching wsprint

    set "baseName=wsprint"

        for /l %%a in (1 1 9) do (

        set "n=0%%a"

                net view \\%baseName%!n:~-2! | findstr /I %UserInput% && echo \\%baseName%!n:~-2! %UserInput%

    )

echo No Other Printers Found!

pause
goto start