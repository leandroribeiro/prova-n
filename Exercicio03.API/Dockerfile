FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY "Exercicio03.sln" "Exercicio03.sln"
COPY "Exercicio03.API/Exercicio03.API.csproj" "Exercicio03.API/Exercicio03.API.csproj"
COPY "Exercicio03.Application/Exercicio03.Application.csproj" "Exercicio03.Application/Exercicio03.Application.csproj"
COPY "Exercicio03.Application.Tests/Exercicio03.Application.Tests.csproj" "Exercicio03.Application.Tests/Exercicio03.Application.Tests.csproj"
RUN dotnet restore

COPY . .
WORKDIR /src/Exercicio03.API
RUN dotnet publish -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Exercicio03.API.dll"]