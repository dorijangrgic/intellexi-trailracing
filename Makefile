# Define variables for convenience
DOCKER_COMPOSE_FILE = docker-compose.yml
DOCKER_COMPOSE_CMD = docker-compose -f $(DOCKER_COMPOSE_FILE)

# Docker Compose services
DB_SERVICE = db
BACKEND_SERVICE = backend

# .NET project paths
MIGRATION_PROJECT_PATH = ./backend/src/Intellexi.TrailRacing.Persistence/Intellexi.TrailRacing.Persistence.csproj
QUERY_PROJECT_PATH = ./backend/src/Intellexi.TrailRacing.QueryService/Intellexi.TrailRacing.QueryService.csproj
UNIT_TEST_PROJECT_PATH = ./backend/tests/Intellexi.TrailRacing.UnitTests/Intellexi.TrailRacing.UnitTests.csproj
INTEGRATION_TEST_PROJECT_PATH = ./backend/tests/Intellexi.TrailRacing.IntegrationTests/Intellexi.TrailRacing.IntegrationTests.csproj

# Run Docker Compose
.PHONY: up
up:
	$(DOCKER_COMPOSE_CMD) up -d

# Apply database migrations
.PHONY: apply-migrations
migrate:
	dotnet ef database update --startup-project $(QUERY_PROJECT_PATH) --project $(MIGRATION_PROJECT_PATH)

# Run backend unit tests
.PHONY: test-unit
test-unit:
	dotnet test $(UNIT_TEST_PROJECT_PATH)

# Run backend integration tests
.PHONY: test-integration
test-integration:
	dotnet test $(INTEGRATION_TEST_PROJECT_PATH)

# Clean up Docker Compose setup
.PHONY: down
down:
	$(DOCKER_COMPOSE_CMD) down
