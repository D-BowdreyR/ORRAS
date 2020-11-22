# Get base SDK Image from microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

# install node js for react
RUN curl --silent --location https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get install --yes nodejs

WORKDIR /app

# COPY app source files
COPY src/ ./

# publish and release app to out dir
RUN dotnet publish WebUI -c Release -o out

# pull down the aspnet runtime and rebase the container
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

# expose IP port of container
EXPOSE 80

WORKDIR /app

# copy released binaries to container
COPY --from=build-env /app/out .

# set entry point to run when container is run
ENTRYPOINT [ "dotnet", "ORRA.WebUI.dll" ]