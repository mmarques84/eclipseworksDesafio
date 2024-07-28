# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie os arquivos .csproj para seus respectivos diretórios
COPY eclipseworksDesafio.Api/eclipseworksDesafio.Api.csproj eclipseworksDesafio.Api/
COPY eclipseworksDesafio.Application/eclipseworksDesafio.Application.csproj eclipseworksDesafio.Application/
COPY eclipseworksDesafio.Core/eclipseworksDesafio.Core.csproj eclipseworksDesafio.Core/
COPY eclipseworksDesafio.Infrastructure/eclipseworksDesafio.Infrastructure.csproj eclipseworksDesafio.Infrastructure/

# Build da aplicação e aplicação de migrações
#RUN dotnet restore
#RUN dotnet build -c Release -o /app/build
#RUN dotnet tool install --global dotnet-ef --version 3.1.0
#RUN dotnet ef database update --context AppDbContext
# Restaure as dependências
RUN dotnet restore "eclipseworksDesafio.Api/eclipseworksDesafio.Api.csproj"

# Copie o restante do código-fonte
COPY . .

# Build
WORKDIR "/src/eclipseworksDesafio.Api"
RUN dotnet build "eclipseworksDesafio.Api.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "eclipseworksDesafio.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eclipseworksDesafio.Api.dll"]
