netmailsender
=============

NetMail Sender API tool
Overview
NetMail Sender is a tool to help test the System.Net.Mail API.  It is basically an email sender and it contains most of the options available in the Net.Mail API.
Features
System.Net.Mail features include:
•	Send email
•	Add custom header(s)
•	Add attachment(s)
•	Add Alternate views (html and plain text)
•	Add LinkedResource / Inline attachment
•	Set message priority
•	Use html body for message
•	Use read receipt
•	Send by port
•	Send by pickup folder
•	Send message every ‘x’ number of seconds
•	Send to multiple recipients (To, Cc, Bcc)
•	Adjust file attachment content type
•	Adjust message encoding
•	Send calendar appointments
•	Error logging
Requirements
•	Microsoft .NET Framework Version 4

Footnotes
Special thanks to the following articles for providing me with helpful information:
1.	I looked at the code from the following sites to base some of the functionality of the NetMail features:
 a.	http://systemnetmail.com
 b.	http://blogs.msdn.com/b/webdav_101/
2.	The function to convert the file size and display it was primarily taken from the following post on stackoverflow:
 a.	http://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc
3.	Image Resources are from:
 a.	http://www.microsoft.com/en-us/download/details.aspx?id=35825
4.	Logging sample borrowed and modified from EWS Streaming Notification
 a.	http://ewsstreaming.codeplex.com/
