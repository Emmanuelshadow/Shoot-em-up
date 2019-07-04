# racing-client

The symlink needs to be configured as followed.

If SharedFromServer is present:
D:\Racing\racing-client\Assets>rm -f SharedFromServer

D:\Racing\racing-client\Assets>del SharedFromServer

D:\Racing\racing-client\Assets>del SharedFromServer.meta


then: 

D:\Racing\racing-client\Assets>mklink /d SharedFromServer "..\\..\\racing-instance\Assets\SharedWithClient"

symbolic link created for SharedFromServer <<===>> ..\\..\\racing-instance\Assets\SharedWithClient
