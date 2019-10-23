# Get base image.
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy the CSPROJ file and restore any dependencies ( via NUGET ).
COPY *.csproj ./
RUN dotnet restore

# Copy the project files and build release.
COPY . ./
RUN  dotnet publish -c Release -o out

# Generate runtime image.
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

# Install Mysql client. 
RUN apt-get update
RUN apt-get install mysql-client -y

WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Orders.dll"]
