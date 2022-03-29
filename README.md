# Public_CAdminTools
Public Version of the CAdminTools App 

This version will not work properly as all sensitive data has been removed.


This tool was made for Alberta Health Services (AHS) IT Service desk.

The tool has many functions to enable the tech to more easily complete their role.

![image](https://user-images.githubusercontent.com/14237962/160677425-b04251df-8946-4d01-9a84-efb4f9239c1a.png)

** Note This tool does use PSInfo for some system querying. When first using some functions, you will be prompted to accept the use of PSInfo.
More info here - https://docs.microsoft.com/en-us/sysinternals/downloads/psinfo

Many of these functions rely on the tech already having admin permissions. Windows will prompt for elevation if required for most functions.


Below is an overview of the functions and how they were designed to be used.

Please use the numbering on the image below to match up with the explaination.

![AdminToolsDetail](https://user-images.githubusercontent.com/14237962/160680166-9bb37ccf-1cc5-4003-af0f-a17575fc688e.jpg)

1. Computer Name, Status and core
  Allows the tech to enter a computer name and the program will automatically attempt to ping the computer and determine if the computer is online, and if it is, the IP address, and the current logged in user. 
  This textbox also interacts with many other functions on this form to target a specific computer.
  The 

2. Remote Desktop Connection options
  There were many options to connect to remote and virtual computers. LANDesk was the main option and would take the computer number entered into the textbox in section 1 and connect directly to that computer. The LANDesk Web option would do the same, but use a web browser to host the connection. The web browser used is the default browser for the machine, through this can be changed with the 'change browser' button in section 7. RCViewer was a backup, and did not allow arguments when opening the program to directly link to a computer. Windows RDP will also use the computer name in the textbox. Selecting a virtual machine from the list will allow a tech to connect to a virtual machine easily.

3. This section contains many different functions that interact with the computer entered into the computer name textbox (section 1)
  - Uptime - Returns how long a computer has been running, returns in days: hours: minutes: seconds
  - PC Info - Returns information on the computer such as uptime, operating system version, registered user and some hardware specifications.
  - Log off & Restart - Force logs off or restarts a computer entered in the computer name textbox (section 1)
  - PC Management - Opens up Windows Computer Management for the target computer (Some issues when connecting to computers on different network cores, some functionality will be limited.)
  - View Processes - View and stop processess running on a remote machine. (Some issues when connecting to computers on different network cores, some functionality will be limited.)
  - Remote C$ - View the local files of the target computer.

4. User lookup section
  This allows the tech to look up a user in both of the user systems used at AHS. The button to the left of the UserName textbox allows the search to change from username to first, last, to email search.
  Can target both websites at once.
  ARS opens in the default or selected browser
  IAM opens in a form that contains a web browser. This is a limited browser with the URL bar not included as it is not intended for outside browsing.

5. Open Document
  Used to contain the many documents a tech has to hold on to for the many fixes they are expected to know how to perform. This was designed to just use shortcuts, accessed from a shared location, so the documents can be updated from management without the tech having to do anything.

6. Open Site
  Allows the tech to open a website on their own or on a remote computer. This allows the tech to more easily keep track of which websites are needed for their work, as well as being able to direct users to a website with ease.
  The default option is to just select a website from the dropdown list; however, you are able to change to a 'custom url' and enter your own. 
  The HTTP, HTTPS and No Prefix options are used as if you simply enter 'google.com' it will not direct properly. This tool was designed for technical minded people, as a result, I have given more options to allow them to enter urls the way they want. If they want to be able to type in 'google.com' they can leave the option on HTTPS. If they want to copy and paste an entire URL, they can select no prefix.

7. Clean Printers button
    Removes all the printers off the techs local machine, and installs the default printer (set in a powershell script)
  Change Browser
    Changes the default browser that this program uses. Can be different from operating system default browser.

8. Output log
  All functions will trigger an entry in the output log to indicate something is working, has succeeded or failed. This can be cleared with the 'Clear Output' button.

9. Customize
  The form can be customised to make it look a little more appealing that default system grey.
  
  ![image](https://user-images.githubusercontent.com/14237962/160683476-cac793c8-4032-4992-ae67-b01ce160b70c.png)
  
  You can either load a background image or select a background colour.
  Buttons, Panels and Labels can all have their colour and opacity set.
  The font type and colour can be changed.
  These settings can be saved so the next time the program opens the settings persist.
  There is also the option to restore to default.

![image](https://user-images.githubusercontent.com/14237962/160683985-c6ccd5cf-371a-4a67-b2f3-eac513937c30.png)

The settings are saved to C:\users\[username]\CAdminTools\LocalSettings.xml
