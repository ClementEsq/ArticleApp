@echo off
SETLOCAL

cls

SET DB_LOG_FILE=DatabaseCreationProcess.log
SET FAKE_PATH=packages\FAKE\tools\Fake.exe
SET BASE_PATH=%cd%
SET SQL_FILE_PATH=ArticleApi.Service.Database.Scripts\NewsArticleRepositoryDatabaseCreation.sql
SET DATABASE_CREATION_LOG=%BASE_PATH%\dbOutput\%DB_LOG_FILE%

sqlcmd -S ".\SQLEXPRESS" -i "%BASE_PATH%\%SQL_FILE_PATH%" -v path="%BASE_PATH%\"
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe init
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe install
if errorlevel 1 (
  exit /b %errorlevel%
)

dotnet restore
if errorlevel 1 (
  exit /b %errorlevel%
)

echo Database creation process log:
type %DB_LOG_FILE%

IF [%1]==[] (
    "%FAKE_PATH%" "build.fsx" "Default" 
) ELSE (
    "%FAKE_PATH%" "build.fsx" %* 
)