# Define a imagem base usando a imagem .NET 7.0 da Microsoft
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

# Define o diretório de trabalho no container para /app
WORKDIR /app

# Expõe as portas 80 e 443 do container
EXPOSE 80
EXPOSE 443

# Define uma nova imagem base usando a imagem .NET SDK 7.0 da Microsoft
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Define o diretório de trabalho no container para /src
WORKDIR /src

# Copia os arquivos .csproj para o container
COPY LearnCraft.Api/*.csproj ./LearnCraft.Api/
COPY LearnCraft.Domain/*.csproj ./LearnCraft.Domain/
COPY LearnCraft.Repository/*.csproj ./LearnCraft.Repository/

# Restaura as dependências e ferramentas de um projeto .NET
RUN dotnet restore LearnCraft.Api/LearnCraft.Api.csproj

# Copia todos os outros arquivos para o container
COPY . .

# Muda o diretório de trabalho para /src/LearnCraft.Api
WORKDIR /src/LearnCraft.Api

# Compila o projeto e suas dependências para um diretório de saída
RUN dotnet build LearnCraft.Api.csproj -c Release -o /app/build

# Define uma nova imagem base a partir da imagem 'build'
FROM build AS publish

# Publica o projeto e suas dependências para um diretório de saída
RUN dotnet publish LearnCraft.Api.csproj -c Release -o /app/out

# Define uma nova imagem base a partir da imagem 'base'
FROM base as final

# Define o diretório de trabalho no container para /app
WORKDIR /app

# Copia os arquivos do diretório /app/out da imagem 'publish' para o diretório atual
COPY --from=publish /app/out .

# Define o comando a ser executado quando o container Docker é iniciado
ENTRYPOINT ["dotnet", "LearnCraft.Api.dll"]