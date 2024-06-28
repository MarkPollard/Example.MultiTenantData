FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
# Turn off Invariant mode and install icu packages for EntityFramework. 
# See: https://github.com/dotnet/SqlClient/issues/220
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS sdkbase
# Turn off Invariant mode and install icu packages for EntityFramework. 
# See: https://github.com/dotnet/SqlClient/issues/220
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ARG BUILD_CONFIGURATION=Release
ARG VERSION=0.0.0-local
ARG ASSEMBLY_VERSION=0.0.0
ARG FILE_VERSION=0.0.0.0
ARG INFORMATIONAL_VERSION=0.0.0-local
ARG PACKAGE_VERSION=0.0.0-local
WORKDIR /work

FROM sdkbase AS build
WORKDIR /work
COPY ["./src/Example.MultiTenantData.Api/Example.MultiTenantData.Api.csproj", "src/Example.MultiTenantData.Api/"]
COPY ["./src/Example.MultiTenantData.BusinessLogic.Abstractions/Example.MultiTenantData.BusinessLogic.Abstractions.csproj", "src/Example.MultiTenantData.BusinessLogic.Abstractions/"]
COPY ["./src/Example.MultiTenantData.BusinessLogic/Example.MultiTenantData.BusinessLogic.csproj", "src/Example.MultiTenantData.BusinessLogic/"]
COPY ["./src/Example.MultiTenantData.Contracts/Example.MultiTenantData.Contracts.csproj", "src/Example.MultiTenantData.Contracts/"]
COPY ["./src/Example.MultiTenantData.DA.Abstractions/Example.MultiTenantData.DA.Abstractions.csproj", "src/Example.MultiTenantData.DA.Abstractions/"]
COPY ["./src/Example.MultiTenantData.DA.EF/Example.MultiTenantData.DA.EF.csproj", "src/Example.MultiTenantData.DA.EF/"]
COPY ["./src/CommonLibraries/Example.Common.DA.EF.MigrationsExtensions/Example.Common.DA.EF.MigrationsExtensions.csproj", "src/CommonLibraries/Example.Common.DA.EF.MigrationsExtensions/"]
COPY ["./nuget.config", "./"]
RUN dotnet restore "src/Example.MultiTenantData.Api/Example.MultiTenantData.Api.csproj"
COPY . .
WORKDIR "/work/src/Example.MultiTenantData.Api"
RUN dotnet build "Example.MultiTenantData.Api.csproj" --no-restore -p:Version=${VERSION} -p:AssemblyVersion=${ASSEMBLY_VERSION} -p:FileVersion=${FILE_VERSION} -p:InformationalVersion=${INFORMATIONAL_VERSION} -p:PackageVersion=${PACKAGE_VERSION} -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
WORKDIR "/work/src/Example.MultiTenantData.Api"
RUN dotnet publish "Example.MultiTenantData.Api.csproj" --no-build -p:OutDir=/app/build -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM build AS buildMigration
RUN dotnet tool install --version 8.0.3 --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
WORKDIR /work
COPY ["./src/Example.MultiTenantData.DA.EF.Deploy/Example.MultiTenantData.DA.EF.Deploy.csproj", "src/Example.MultiTenantData.DA.EF.Deploy/"]
RUN dotnet restore "src/Example.MultiTenantData.DA.EF.Deploy/Example.MultiTenantData.DA.EF.Deploy.csproj"
WORKDIR "/work/src/Example.MultiTenantData.DA.EF.Deploy"
RUN dotnet build "Example.MultiTenantData.DA.EF.Deploy.csproj" --no-restore -p:Version=${VERSION} -p:AssemblyVersion=${ASSEMBLY_VERSION} -p:FileVersion=${FILE_VERSION} -p:InformationalVersion=${INFORMATIONAL_VERSION} -p:PackageVersion=${PACKAGE_VERSION} -c $BUILD_CONFIGURATION -o /app/build
WORKDIR /work
RUN dotnet ef migrations bundle --project src/Example.MultiTenantData.DA.EF.Deploy --verbose

FROM base AS finalMigration
WORKDIR /app
COPY --from=buildMigration /work/efbundle .
COPY --from=buildMigration /work/src/Example.MultiTenantData.DA.EF.Deploy/ShellScripts/migrateDatabase.sh .
RUN chmod +x migrateDatabase.sh
ENTRYPOINT ["./migrateDatabase.sh"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.MultiTenantData.Api.dll"]