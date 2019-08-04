
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 
#AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./webapp/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./webapp ./

RUN dotnet add package Microsoft.EntityFrameworkCore.SQLite
#RUN dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
#RUN dotnet add package Microsoft.EntityFrameworkCore.Design

RUN dotnet publish -c Release -o out

# Build runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
# WORKDIR /app
# COPY --from=build-env /app/out/ ./
#RUN dotnet add package Microsoft.EntityFrameworkCore.SQLite
ENTRYPOINT ["dotnet", "/app/out/webapp.dll"]
