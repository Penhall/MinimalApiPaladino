#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#ESTÁGIO 1
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#ESTÁGIO 2
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MinimalApiPaladino/MinimalApiPaladino.csproj", "MinimalApiPaladino/"]
RUN dotnet restore "MinimalApiPaladino/MinimalApiPaladino.csproj"
COPY . .
WORKDIR "/src/MinimalApiPaladino"
RUN dotnet build "MinimalApiPaladino.csproj" -c Release -o /app/build


#ESTÁGIO 3
FROM build AS publish
RUN dotnet publish "MinimalApiPaladino.csproj" -c Release -o /app/publish /p:UseAppHost=false


#ESTÁGIO 4
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinimalApiPaladino.dll"]