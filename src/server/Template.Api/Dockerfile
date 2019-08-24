FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Template.Api/Template.Api.csproj", "Template.Api/"]
COPY ["Template.Application/Template.Application.csproj", "Template.Application/"]
COPY ["Template.Infra.Crosscutting/Template.Infra.Data.Crosscutting.csproj", "Template.Infra.Crosscutting/"]
COPY ["Template.Domain/Template.Domain.csproj", "Template.Domain/"]
COPY ["Template.Infra.EF/Template.Infra.Data.EF.csproj", "Template.Infra.EF/"]
RUN dotnet restore "Template.Api/Template.Api.csproj"
COPY . .
WORKDIR "/src/Template.Api"
RUN dotnet build "Template.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Template.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Template.Api.dll"]