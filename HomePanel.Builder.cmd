@ECHO OFF
SET ASPNETCORE_URLS=https://homepanel-builder.dev.localhost:8443;http://homepanel-builder.dev.localhost:8080
SET ASPNETCORE_ENVIRONMENT=Production
SET HOMEPANEL_BUILDER_ESPHOME_CONFIG=C:\Users\michael.POWER\esphome
PUSHD .\HomePanel.Builder\bin\Release\net10.0\publish\
ECHO Launching HomePanel.Builder
START https://homepanel-builder.dev.localhost:8443
.\HomePanel.Builder.exe
POPD