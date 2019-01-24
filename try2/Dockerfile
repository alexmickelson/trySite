FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["try2.csproj", "try2/"]

RUN dotnet restore "try2/try2.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "try2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "try2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "try2.dll"]
