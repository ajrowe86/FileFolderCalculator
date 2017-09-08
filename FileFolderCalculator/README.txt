DISCLAIMER:

FileFolderCalculator.exe and the source code used to generate the application was created by Andrew John Rowe in Cambridge, UK. Various help threads on 
www.stackoverflow.com and other sites, by unknown authors, were used to assist in its creation. The application was last updated on 11/08/2017.

THE SOURCE CODE USED TO CREATE THIS CONSOLE APPLICATION CAN BE FOUND IN THE DIRECTORY OF THIS APPLICATION <~\FileFolderCalculator\Source Code>.

WHAT FILEFOLDERCALCULATOR DOES:

The application searches through all directories on a system and stores the paths and sizes of all files and folders in separate .txt files (File Data.txt 
and Folder Data.txt, respectively). This data is ordered in the .txt files by file/folder size, with the largest file/folder at the top. A further .txt 
file is also created to record any exceptions encountered when the code was running (Exceptions Data.txt).

The file sizes displayed in "File Data.txt" have been found to always give correct values. However, problems (probably arising from unauthorised access 
exceptions) encountered mean that some of the data in "Folders Data.txt" may not always be correct.

--------------------------HOW TO USE FILEFOLDERCALCULATOR:-------------------------------------------------------------------------------------------------------------------

- Run FileFolderCalculator.exe, preferrably with administrator privileges (see capitalised text below). All output that will eventually be written to .txt files will 
be shown in a console window as the application calculates the data.

- Once the application has finished running, the user will be prompted to "Press any key to exit." Pressing any keyboard key will close the console window.

- Output .txt files can then be found in <~FileFolderCalculator\Output Files\>.

    - "File Data.txt" lists all files found on the system and orders them by descending size values.

    - "Folder Data.txt" lists all folders found on a system and orders them by descending size values.

    - "Exceptions Data.txt" lists all exceptions encountered while the code was running.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PROBLEMS WITH FILEFOLDERCALCULATOR:

THE CURRENT VERSION OF FILEFOLDERCALCULTOR MAY NOT ALLOW ALL FILES AND DIRECTORIES ON A SYSTEM TO BE READ, DUE TO THE UNAUTHORISED ACCESS EXCEPTIONS OUTLINED ABOVE. 
RUNNING THE APPLICATION WITH ADMINISTRATOR PRIVILEGES WILL REDUCE THE NUMBER OF EXCEPTIONS ENCOUNTERED, BUT WILL PROBABLY NOT MAKE THE CODE PERFECT. THE AUTHOR REDUCED 
THE NUMBER OF EXCEPTIONS THEY ENCOUNTERED BY 75% USING THIS METHOD. HOWEVER, IT SHOULD BE NOTED THAT FURTHER UPDATES ARE REQUIRED TO MAKE THE CODE PERFORM AS INTENDED.

The application has been tested on drives that contain no restricted access directories and the results for those drives were found to be correct. However, any folders which 
are dependent on paths listed in "Exceptions Data.txt" will not have correct sizes displayed in "Folders Data.txt". The author has not found a way to stop the calculation 
once it has started for calculations of directory size which encounter an exception.

Also, it has been found that folders which are reliant on paths found in "Exceptions data.txt" were sometimes calculated to be larger than in reality. This means that some 
folders may be being counted multiple times in the algorithm. Further research i required to solve this problem.

POSSIBLE IMPROVEMENTS:

Ideally, a method to grant temporary read privileges to all directories on a system should be employed in the source code to allow the application to read the size 
of all directories on a system. However, the author has not found a way to do this at present.