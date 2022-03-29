# Public_CAdminTools
Public Version of the CAdminTools App 

This version will not work properly as all sensitive data has been removed.


This tool was made for Alberta Health Services IT Service desk.

The tool has many functions to enable the tech to more easily complete their role.

![image](https://user-images.githubusercontent.com/14237962/160677425-b04251df-8946-4d01-9a84-efb4f9239c1a.png)


Below is an overview of the functions and how they were designed to be used.

Please use the numbering on the image below to match up with the explaination.

![AdminToolsDetail](https://user-images.githubusercontent.com/14237962/160680166-9bb37ccf-1cc5-4003-af0f-a17575fc688e.jpg)

1. Computer Name, Status and core
  Allows the tech to enter a computer name and the program will automatically attempt to ping the computer and determine if the computer is online, and if it is, the IP address, and the current logged in user. 
  This textbox also interacts with many other functions on this form to target a specific computer.
  The 

2. Remote Desktop Connection options
  There were many options to connect to remote and virtual computers. LANDesk was the main option and would take the computer number entered into the textbox in section 1 and connect directly to that computer. The LANDesk Web option would do the same, but use a web browser to host the connection. The web browser used is the default browser for the machine, through this can be changed with the 'change browser' button in section 7. RCViewer was a backup, and did not allow arguments when opening the program to directly link to a computer. Windows RDP will also use the computer name in the textbox. Selecting a virtual machine from the list will allow a tech to connect to a virtual machine easily.

3. 
