This project uses Pcap.net and WinPcap to capture network traffic on a selected device and graphs that information.
At the moment, you can only scan for a specified time. This is my first program written in C# that uses multithreading
and displays information on a gui. I have not figured out what to do about the size limits on GUI elements. The program
will stop scanning abruptly after 4 hours or when enough data is run through it. Future improvments that may come at a 
later time are customizable graph colors, x-axis labels that depict time intervals, and a continuous scanning mode.

This program may not compile as the Pcap.net dll's are not included here. 
The sorce files are in ../Data Monitor/Data Monitor/ if you would like to see them.