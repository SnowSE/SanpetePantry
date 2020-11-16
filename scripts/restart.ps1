# Restart script for the pantry website
param(
    [string]$tag
)

$parts = [String]::Split($tag)
$sha = $parts | where  -filterscript {$_ -like  "sha*" }

write-host "Got tag $tag from parameter, setting to BuildID ENV variable..."
$ENV:BuildID=$sha

# pull new image
write-host "Pulling new image"
docker-compose pull

# Stop running server
write-host "Stopping server"
docker-compose kill

# Start server
write-host "Starting server"
docker-compose up -d