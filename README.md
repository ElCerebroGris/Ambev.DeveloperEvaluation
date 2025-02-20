# backend

# Project Setup and Execution Guide

## Prerequisites

Before running this project, ensure you have the following installed:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Configuration

### Environment Variables
This project relies on environment variables for configuration. Ensure the following variables are set:

```sh
DOCKER_REGISTRY=
APPDATA=
```

Ensure your `APPDATA` path is correctly set to allow Docker to mount the necessary volumes.

## Running the Project

To start the application and its dependencies, run:

```sh
docker-compose up -d --build
```

This will:
- Build and start the API container (`ambev.developerevaluation.webapi`)
- Start a PostgreSQL database (`ambev.developerevaluation.database`)
- Start a MongoDB instance (`ambev.developerevaluation.nosql`)
- Start a Redis cache (`ambev.developerevaluation.cache`)

## Accessing Services

- **Web API**: Runs on `http://localhost:8080` (HTTP) and `https://localhost:8081` (HTTPS)
- **PostgreSQL**: Accessible on `localhost:5432` with user `developer` and password `ev@luAt10n`
- **MongoDB**: Accessible on `localhost:27017` with user `developer` and password `ev@luAt10n`
- **Redis**: Accessible on `localhost:6379` with password `ev@luAt10n`

## Stopping the Project

To stop the running containers, execute:

```sh
docker-compose down
```

## Testing the Project

### Verify Containers Are Running

Run the following command to check the status of the running containers:

```sh
docker ps
```

### API Health Check

To ensure the API is up, you can send a request using `curl` or Postman:

```sh
curl -X GET http://localhost:8080/health
```

### Database Connection

For PostgreSQL, use the following command to connect:

```sh
docker exec -it ambev_developer_evaluation_database psql -U developer -d developer_evaluation
```

For MongoDB:

```sh
docker exec -it ambev_developer_evaluation_nosql mongosh -u developer -p ev@luAt10n
```

## Logs and Debugging

To view logs for a specific container, use:

```sh
docker logs -f <container_name>
```

Example:

```sh
docker logs -f ambev_developer_evaluation_webapi
```

## Cleanup

To remove all containers and volumes:

```sh
docker-compose down -v
```

This will stop and remove all running containers, as well as any associated volumes.

