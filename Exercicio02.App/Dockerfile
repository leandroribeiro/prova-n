FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Exercicio02.App/*.csproj", "Exercicio02.App/"]
RUN dotnet restore "Exercicio02.App/Exercicio02.App.csproj"
COPY . .
WORKDIR "/src/Exercicio02.App"
RUN dotnet build "Exercicio02.App.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Exercicio02.App.csproj" -c Release -o /app

FROM base AS final

WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Exercicio02.App.dll"]