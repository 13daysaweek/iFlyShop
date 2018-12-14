#$Server = Read-Host -Prompt 'Input your server  name'
#$User = Read-Host -Prompt 'Input the user name'
#$Date = Get-Date
#Write-Host "You input server '$Servers' and '$User' on '$Date'" 
# $executingScriptDirectory = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
# $scriptPath = Join-Path $executingScriptDirectory "scriptb.ps1"
# Invoke-Expression ".\$scriptPath" 

# Placeholder variables
$sqlConnStringPlaceholder = "#iFlyShopContextConnString#"

# Capture SQL DB connection string
$sqlConnString = Read-Host -Prompt 'Enter the connection string for your SQL database'

# Read connection string template file
$connStringTemplatePath = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
$connStringTemplatePath = Join-Path $connStringTemplatePath 'api.connectionStrings.template'
$connStringTemplate = Get-Content -Path $connStringTemplatePath

$outputContent = $connStringTemplate -replace $sqlConnStringPlaceholder, $sqlConnString

$connStringOutputPath = Split-Path $MyInvocation.MyCommand.Definition -Parent
$connStringOutputPath = Join-Path $connStringOutputPath '..\Backend\ThirteenDaysAWeek.iFlyShop.Api\api.connectionStrings.config'
$connStringOutputPath
Out-File -FilePath $connStringOutputPath -InputObject $outputContent
