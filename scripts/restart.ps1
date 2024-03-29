# Restart script for the pantry website
param(
    [string]$tag,
    [string]$branch
)

write-host "Got tag $tag from parameter"

$sha = $tag.split(":") | where  -filterscript {$_ -like  "sha*" }
write-host "Setting 'BuildID' to $sha"
$ENV:BuildID=$sha

docker-compose -f "docker-compose-$branch.yml" pull
docker-compose -f "docker-compose-$branch.yml" up -d
