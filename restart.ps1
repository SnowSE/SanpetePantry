# Restart script for the pantry website
param(
    [string]$tag
)

write-host "Got tag $tag from parameter, setting to BuildID ENV variable..."
$ENV:BuildID=$tag


# pull new image
write-host "Pulling new image"
docker-compose pull

# Stop running server
write-host "Stopping server"
docker-compose kill

# Start server
write-host "Starting server"
docker-compose up -d