# Get base image.
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy the CSPROJ file and restore any dependencies ( via NUGET ).
COPY Orders/*.csproj ./Orders/
COPY Orders.Tests/*.csproj ./Orders.Tests/
RUN dotnet restore ./Orders/
RUN dotnet restore ./Orders.Tests/

# Copy the project files, test and build release.
COPY Orders/ ./Orders/
COPY Orders.Tests/ ./Orders.Tests/
RUN dotnet test Orders.Tests/
RUN dotnet publish -c Release Orders/ -o /app/out

# Generate runtime image.
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

# Install Mysql client. 
RUN apt-get update
RUN apt-get install mysql-client -y

WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Orders.dll"]
