#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Account/Account.Api/Account.Api.csproj", "Services/Account/Account.Api/"]
COPY ["Services/Account/Account.Infrastructure/Account.Infrastructure.csproj", "Services/Account/Account.Infrastructure/"]
COPY ["Services/Account/Account.Application/Account.Application.csproj", "Services/Account/Account.Application/"]
COPY ["Services/Account/Account.Domain/Account.Domain.csproj", "Services/Account/Account.Domain/"]
COPY ["Services/Account/Account.Service/Account.Service.csproj", "Services/Account/Account.Service/"]
RUN dotnet restore "Services/Account/Account.Api/Account.Api.csproj"
COPY . .
WORKDIR "/src/Services/Account/Account.Api"
RUN dotnet build "Account.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Account.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Account.Api.dll"]