#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PSD.Biblioteca.WebAPI/PSD.Biblioteca.WebAPI.csproj", "PSD.Biblioteca.WebAPI/"]
COPY ["PSD.Biblioteca/PSD.Biblioteca.csproj", "PSD.Biblioteca/"]
COPY ["PSD.Core/PSD.Core.csproj", "PSD.Core/"]
RUN dotnet restore "PSD.Biblioteca.WebAPI/PSD.Biblioteca.WebAPI.csproj"
COPY . .
WORKDIR "/src/PSD.Biblioteca.WebAPI"
RUN dotnet build "PSD.Biblioteca.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PSD.Biblioteca.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PSD.Biblioteca.WebAPI.dll"]