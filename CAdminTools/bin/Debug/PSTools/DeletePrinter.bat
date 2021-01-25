
@Echo off
REM Author: Jacob Yaremchuk
REM Delete a network printer on a computer remotely
REM the parameters are:

REM   1 - the name of the computer on which the network printer is to be deleted
REM   2 - the name of the printer to be deleted

REM for example, to delete the printer called cntis60 that is on wsprint07
REM    to the computer called TheClient:
REM    key this command in a Command Prompt window:
REM    deleteglobalprinterremotely theclient wsprint07\cntis60


@Echo On
rundll32 printui.dll,PrintUIEntry /dn /c\\%1 /n\\%2
@Echo off

REM stop the print spooler on the specified computer and wait until the sc command finishes

@Echo On
start /wait sc \\%1 stop spooler
@Echo off

REM start the print spooler on the specified computer and wait until the sc command finishes

@Echo On
start /wait sc \\%1 start spooler

