#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["test2_formulas/test2_formulas.csproj", "test2_formulas/"]
RUN dotnet restore "test2_formulas/test2_formulas.csproj"
COPY . .
WORKDIR "/src/test2_formulas"
RUN dotnet build "test2_formulas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "test2_formulas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test2_formulas.dll"]
