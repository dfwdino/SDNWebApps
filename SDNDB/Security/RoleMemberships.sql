﻿ALTER ROLE [db_owner] ADD MEMBER [SDNWebApp];


GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\IUSR];


GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\NETWORK SERVICE];


GO
ALTER ROLE [db_datareader] ADD MEMBER [SDNWebApp];


GO
ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\IUSR];


GO
ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\NETWORK SERVICE];


GO
ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\SYSTEM];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [SDNWebApp];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\IUSR];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\NETWORK SERVICE];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\SYSTEM];

