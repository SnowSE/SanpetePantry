# Restart script for the pantry website
param(
    [string]$tag
)

$sha = $tag.split(":") | where  -filterscript {$_ -like  "sha*" }

write-host "Got tag $tag from parameter, setting 'BuildID' to $sha"
$ENV:BuildID=$sha

# pull new image
write-host "Pulling new image"
docker-compose pull

# Stop running server
write-host "Stopping server"
# docker-compose kill

# Start server
write-host "Starting server"
docker-compose up -d
