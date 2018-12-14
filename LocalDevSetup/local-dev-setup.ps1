#$Server = Read-Host -Prompt 'Input your server  name'
#$User = Read-Host -Prompt 'Input the user name'
#$Date = Get-Date
#Write-Host "You input server '$Servers' and '$User' on '$Date'" 
# $executingScriptDirectory = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
# $scriptPath = Join-Path $executingScriptDirectory "scriptb.ps1"
# Invoke-Expression ".\$scriptPath" 

# Placeholder variables
$sqlConnStringPlaceholder = "#iFlyShopContextConnString#"

# Output folder
$outputFolder = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
$outputFolder = Join-Path $outputFolder '..\Backend\ThirteenDaysAWeek.iFlyShop.Api'

# Template Folder
$templateFolder = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent

# Capture SQL DB connection string
$sqlConnString = Read-Host -Prompt 'Enter the connection string for your SQL database'

# Read connection string template file
$connStringTemplatePath = Join-Path $templateFolder 'api.connectionStrings.template'
$connStringTemplate = Get-Content -Path $connStringTemplatePath

# Replace placeholder with console input
$outputContent = $connStringTemplate -replace $sqlConnStringPlaceholder, $sqlConnString

# Create file in output folder with updated template string
$connStringOutputPath = Split-Path $MyInvocation.MyCommand.Definition -Parent
$connStringOutputPath = Join-Path $connStringOutputPath '..\Backend\ThirteenDaysAWeek.iFlyShop.Api\api.connectionStrings.config'
Out-File -FilePath $connStringOutputPath -InputObject $outputContent

# Copy appSettings template to output folder (no values in this file yet, so just a straight copy)
$appSettingsTemplate = Join-Path $templateFolder 'api.appSettings.template'
$appSettingsOutputFile = Join-Path $outputFolder 'api.appSettings.config'
Copy-Item $appSettingsTemplate $appSettingsOutputFile
