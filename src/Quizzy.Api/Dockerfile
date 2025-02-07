# 1. Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy solution and project files
COPY Quizzy.sln ./
COPY ./src/Quizzy.Api/Quizzy.Api.csproj src/Quizzy.Api/
COPY ./src/Quizzy.Core/Quizzy.Core.csproj src/Quizzy.Core/
COPY ./src/Quizzy.Data/Quizzy.Data.csproj src/Quizzy.Data/

# Restore packages
RUN dotnet restore ./src/Quizzy.Api/Quizzy.Api.csproj

# Copy source code
COPY src/ ./src/

# Build and publish
WORKDIR /app/src/Quizzy.Api
RUN dotnet publish -c Release -o /out

# 2. Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy compiled files
COPY --from=build /out ./

# Expose the API port
# First port is http, the second https (ej. 1727 2717)
EXPOSE 8080

# Command to execute the API
# ENV ASPNETCORE_URLS=http://localhost:1727
# ENV ASPNETCORE_HTTP_PORTS=1727
# ENV DOTNET_GENERATE_ASPNET_CERTIFICATE=false
ENTRYPOINT [ "dotnet", "Quizzy.Api.dll" ]