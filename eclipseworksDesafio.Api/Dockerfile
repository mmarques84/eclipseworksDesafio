FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia o arquivo csproj e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do código e compila o projeto
COPY . ./
RUN dotnet publish -c Release -o out

# Fase de Execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia os arquivos publicados da fase de construção
COPY --from=build /app/out .

# Define a porta que o aplicativo vai escutar
EXPOSE 80

# Define o comando para executar o aplicativo
ENTRYPOINT ["dotnet", "eclipseworksDesafio.Api.dll"]