param([string]$MigrationName)

$project = "$PSScriptRoot\..\GoalsAndTasks.WebApi.DatabaseDesign.csproj"

dotnet ef migrations has-pending-model-changes `
	--project $project `
	| Tee-Object -Variable modelChangesStatus

if (-not ($modelChangesStatus -contains 'Changes have been made to the model since the last migration. Add a new migration.')) {
	return
}

if (-not $MigrationName) {
	Write-Host 'Migration name: ' -NoNewline
	$MigrationName = Read-Host
}

dotnet ef migrations add $MigrationName `
	--project $project `
	--output-dir .\Migrations\ `
	--no-build
