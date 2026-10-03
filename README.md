# DockerTestProject

ASP.NET Core (.NET 8) Web API with PostgreSQL and Redis, packaged with Docker.

## Requirements

- Docker Desktop (or Docker Engine + Compose)

## Run

1. Download `docker-compose.yml` and `init.sql` into the same folder.
2. Open a terminal in that folder and run:

```bash
docker compose up
```

That's it. Docker will automatically:

1. Pull the API image (`hridoy335/dockertest`), PostgreSQL and Redis
2. Create the `testdb` database and run `init.sql` (creates all tables)
3. Start the API

## Open the app

- Swagger UI: http://localhost:8080/swagger
- API: http://localhost:8080/api/Product2

## Notes

- `init.sql` runs only the first time, when the database volume is empty.
- Update to the latest image: `docker compose pull`
- Stop: `docker compose down`
- Stop and delete all data (re-runs `init.sql` next time): `docker compose down -v`

## Ports used

| Service    | Port |
|------------|------|
| API        | 8080 |
| PostgreSQL | 5433 |
| Redis      | 6379 |

Make sure these ports are free on your machine.