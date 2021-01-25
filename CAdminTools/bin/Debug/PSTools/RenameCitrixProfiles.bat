@echo off
cls
FOR /F "TOKENS=3 eol=/ DELIMS=/ " %%A IN ('DATE/T') DO SET dd=%%A
FOR /F "TOKENS=1,2 eol=/ DELIMS=/ " %%A IN ('DATE/T') DO SET mm=%%B
FOR /F "TOKENS=2,3,4 eol=/ DELIMS=/ " %%A IN ('DATE/T') DO SET yyyy=%%C
SET todaysdate=%mm%%dd%%yyyy%
echo Renaming profiles for %username%
REN \\wsctxprf01.healthy.bewell.ca\rdsprofiles$\%USERNAME% %USERNAME%_%todaysdate%
REN \\wsctxprf02.healthy.bewell.ca\rdsprofiles$\%USERNAME% %USERNAME%_%todaysdate%
REN \\wsctxprf03.healthy.bewell.ca\rdsprofiles$\%USERNAME% %USERNAME%_%todaysdate%

Echo Results:
dir \\wsctxprf01.healthy.bewell.ca\rdsprofiles$ /b
dir \\wsctxprf02.healthy.bewell.ca\rdsprofiles$ /b
dir \\wsctxprf03.healthy.bewell.ca\rdsprofiles$ /b
pause





