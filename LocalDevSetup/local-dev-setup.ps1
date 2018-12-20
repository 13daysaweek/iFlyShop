#$Server = Read-Host -Prompt 'Input your server  name'
#$User = Read-Host -Prompt 'Input the user name'
#$Date = Get-Date
#Write-Host "You input server '$Servers' and '$User' on '$Date'" 
# $executingScriptDirectory = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
# $scriptPath = Join-Path $executingScriptDirectory "scriptb.ps1"
# Invoke-Expression ".\$scriptPath" 

# Placeholder variables
$sqlConnStringPlaceholder = "__iFlyShopContext__"
$cacheConnectionStringPlaceholder = "__cacheConnectionString__"
$storageAccountPlaceholder = "__storageConnectionString__"

$appInsightsiKeyPlaceholder = "__iKey__"
$orderQueueNamePlaceholder = "__orderQueueName__"

# Output folder
$outputFolder = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
$outputFolder = Join-Path $outputFolder '..\Backend\ThirteenDaysAWeek.iFlyShop.Api'

# Template Folder
#$templateFolder = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent

# Capture SQL DB connection string
$sqlConnString = Read-Host -Prompt 'Enter the connection string for your SQL database'

# Capture Cache ConnectionString
$cacheConnectionString = Read-Host -Prompt 'Enter the connection string for your Redis cache'

# Capture Storage Connection String
$storageAccountConnectionString = Read-Host -Prompt 'Enter the connection string for your storage account'

# Capture App Insights iKey
$appInsightsiKey = Read-Host -Prompt 'Enter the Instrumentation Key for your Application Insights instance'

# Capture the order queue name
$orderQueueName = Read-Host -Prompt 'Enther the queue name for orders'

# Read connection string template file
$connStringTemplatePath = Join-Path $outputFolder 'api.connectionStrings.config'
$connStringTemplate = Get-Content -Path $connStringTemplatePath

# Replace Placeholders
$outputContent = $connStringTemplate.Replace($sqlConnStringPlaceholder, $sqlconnString).Replace($cacheConnectionStringPlaceholder, $cacheConnectionString).Replace($storageAccountPlaceholder, $storageAccountConnectionString)

# Create file in output folder with updated template string
$connStringOutputPath = Join-Path $outputFolder 'api.connectionStrings.local'
Out-File -FilePath $connStringOutputPath -InputObject $outputContent

# Copy appSettings template to output folder (no values in this file yet, so just a straight copy)
$appSettingsTemplate = Join-Path $outputFolder 'api.appSettings.config'
$appSettingsOutputFile = Join-Path $outputFolder 'api.appSettings.local'
$appSettingsContent = Get-Content -Path $appSettingsTemplate

$appSettingsContent = $appSettingsContent.Replace($appInsightsiKeyPlaceholder, $appInsightsiKey).Replace($orderQueueNamePlaceholder, $orderQueueName)

# Copy appSettings file to output location
Out-File -FilePath $appSettingsOutputFile -InputObject $appSettingsContent