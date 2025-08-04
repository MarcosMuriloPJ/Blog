# 📦 Blog

Serviço .NET para **gerenciamento de posts** com CRUD completo via APIs REST.

## 🛠 Stack

- .NET 8 (ASP.NET Core)
- SQLServer
- Docker
- Entity Framework Core
- Clean Architecture

## 🏁 Começando

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/)

### ▶ Execução

```bash
# Clone o repositório
git clone https://github.com/MarcosMuriloPJ/Blog.git
cd Blog

## Execução via Docker
docker-compose up --build

## Execução via manual

# Navegue até a pasta da API
cd src/Blog.API

# Restaurar dependências
dotnet restore

# Gerar build local (opcional)
dotnet build
```

### Migrations

```bash
dotnet ef migrations add Initial --project ./src/Blog.Infrastructure/Blog.Infrastructure.csproj --startup-project ./src/Blog.API/Blog.API.csproj --output-dir Data\Migrations
dotnet ef database update --project ./src/Blog.Infrastructure/Blog.Infrastructure.csproj --startup-project ./src/Blog.API/Blog.API.csproj
```
