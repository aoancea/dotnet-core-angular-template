FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./

WORKDIR /app/src/Client/Web
#RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
#RUN curl -sL https://deb.nodesource.com/setup_8.x | bash - && apt-get install -yq nodejs build-essential
#RUN npm install -g npm
#RUN npm install

RUN apt-get -qq update && apt-get -qqy --no-install-recommends install wget gnupg \
    git \
    unzip

RUN curl -sL https://deb.nodesource.com/setup_8.x |  bash -
RUN apt-get install -y nodejs

RUN npm install
RUN npm install -g @angular/cli
RUN ng build

RUN dotnet restore
RUN dotnet publish -c Release -o out

ENTRYPOINT ["dotnet", "out/NetCoreAngular.Client.Web.dll"]
