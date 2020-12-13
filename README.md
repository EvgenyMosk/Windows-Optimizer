# Windows-Optimizer
Lightweight Microsoft Windows optimizer
__________________________
## WARNING!
This is an experimental version of the software. It was tested only on the limited number of PCs.  
The author is NOT responsible for any damage you do to your Personal Computer or Operating System!
____________________________________
## System requirements:
* Operating System: **Windows 10** (Windows 7/8/8.1 were not tested)
* Software Components: **.NET Framework 3.5** (you may be promted by OS to install it)
* User privileges level: **Administrator**
_______
## How to use it?
### Backup your registry
> Please, before changing you registry values using this software - [create a backup for your registry](https://support.microsoft.com/en-us/help/322756/how-to-back-up-and-restore-the-registry-in-windows).
1. Download an executable file (.exe) and a text file from the **Releases** page
2. Launch the executable file with Administrator privileges
3. Follow the instructions in the software GUI

### CLI (Console) UI:
1. Enter the path to the text file (the one you should have downloaded from the Releases page)
> If the file doesn't exist, the program will stop it's execution.
> If you've placed the .exe and .txt files into the same folder, you can input only the file name.
> Otherwise, please use the full path (e.g. *C:\Users\My name\Downloads\Windows Optimizer\Alpha release\Records.txt*)
2. Next, the software validates the file content
> If file contains nothing, or the data is in wrong format - execution stops.
3. Successfully fetched records is being printed to a console
> Records are preceded with '[+]' or '[X]' symbol:
> [+] - means record exists in your registry, but it may contain other Value
> [X] - record was not found in your registry, so it will be created
4. Now, you'll be asked to confirm the Registry Changes, type "yes" (without quotes, any case will do, e.g. YES, yEs, YEs, yES)
> Any other word will be counted as "No" and the execution will be aborted.
5. After changing is done, you can see the **number of changed records** and the **records that were not changed** for some reason

### GUI
Only CLI UI is currently supported. Feature-rich Graphical UI will be added in the future.
