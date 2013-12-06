cd /d %~dp0
cd %CD%\bin
mysqld --install MySQL >> install.log
net start MySQL >> install.log