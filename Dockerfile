# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia os arquivos .csproj e restaura as dependências
COPY *.csproj ./
RUN dotnet restore ./ads.csproj

# Copia o restante do código e realiza o build
COPY . ./
RUN dotnet publish ./ads.csproj -c Release -o out

# Etapa final - cria a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expõe a porta 5000
EXPOSE 5000

# Define o comando de entrada para a execução do container
ENTRYPOINT ["dotnet", "ads.dll"]
