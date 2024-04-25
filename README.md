[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=MartinObrecht_LearnCraft&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=MartinObrecht_LearnCraft)

> Para criar a imagem do docker, execute o comando abaixo:
```
docker build -f ./LearnCraft.Api/Dockerfile -t martinobrecht/learcraft:0.3 .
```

> Para rodar a imagem do docker, execute o comando abaixo:
```
docker container run --rm -p 3030:80 -e ApplicationInsights__ConnectionString="xxxx" martinobrecht/learcraft:0.3
```

## Link de documentações consultadas para desenvolvimento do projeto

- [https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet)

- [https://learn.microsoft.com/pt-br/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows](https://learn.microsoft.com/pt-br/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows)

### Application Insights

- [https://learn.microsoft.com/pt-br/azure/azure-monitor/app/asp-net-core?tabs=netcorenew](https://learn.microsoft.com/pt-br/azure/azure-monitor/app/asp-net-core?tabs=netcorenew)

### Configuration

- [https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0)

### Docker

- [https://learn.microsoft.com/pt-br/dotnet/core/docker/build-container?tabs=windows](https://learn.microsoft.com/pt-br/dotnet/core/docker/build-container?tabs=windows)
- [https://docs.docker.com](https://docs.docker.com)
