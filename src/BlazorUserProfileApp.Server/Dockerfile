FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "BlazorUserProfileApp.Server.dll"]

