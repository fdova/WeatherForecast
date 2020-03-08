# Use this as the base image
FROM mcr.microsoft.com/dotnet/core/sdk AS build-env
# This is the directory that we will be navigated inside the container.
# If the directory doesn't exist, it will be created
WORKDIR /app


### Copy csproj and restore 
# Copy needs to define a source and a destination
COPY RestApi/*.csproj ./
RUN dotnet restore

### Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

### Build runtime image
# This removes the intermediate container, and creates a new one
# with only the out folder
FROM mcr.microsoft.com/dotnet/core/sdk
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "RestApi.dll"]