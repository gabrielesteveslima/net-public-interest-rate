FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# Set the workdir for the application
WORKDIR /app

# Copy csproj and restore
COPY . /app

RUN dotnet restore
RUN dotnet publish -c Release -o out/

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

# Copy the production artifacts to the workdir
COPY --from=build /app/out .

# Set the port that the application will run on
ENV ASPNETCORE_URLS=http://+:5001

# Set the command that will run the API
ENTRYPOINT ["dotnet", "Soft.InterestRate.API.dll"]

# Expose the port that the application will run on
EXPOSE 5001