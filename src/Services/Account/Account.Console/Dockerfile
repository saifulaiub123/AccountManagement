#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Account/Account.Console/Account.ConsoleApp.csproj", "Services/Account/Account.Console/"]
COPY ["Services/Account/Account.Infrastructure/Account.Infrastructure.csproj", "Services/Account/Account.Infrastructure/"]
COPY ["Services/Account/Account.Application/Account.Application.csproj", "Services/Account/Account.Application/"]
COPY ["Services/Account/Account.Domain/Account.Domain.csproj", "Services/Account/Account.Domain/"]
COPY ["Services/Account/Account.Service/Account.Service.csproj", "Services/Account/Account.Service/"]
RUN dotnet restore "Services/Account/Account.Console/Account.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/Services/Account/Account.Console"
RUN dotnet build "Account.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Account.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Account.ConsoleApp.dll"]