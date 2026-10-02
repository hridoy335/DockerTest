# DockerTest

## Start the application

docker compose pull
docker compose up -d

## Apply database migration

dotnet ef database update --connection "Host=localhost;Port=5433;Database=testdb;Username=postgres;Password=postgres"

## Test API

http://localhost:8080