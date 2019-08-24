FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ifsc.tcc.Portal.Api/ifsc.tcc.Portal.Api.csproj", "ifsc.tcc.Portal.Api/"]
COPY ["ifsc.tcc.Portal.Infra.EF/ifsc.tcc.Portal.Infra.Data.EF.csproj", "ifsc.tcc.Portal.Infra.EF/"]
COPY ["ifsc.tcc.Portal.Domain/ifsc.tcc.Portal.Domain.csproj", "ifsc.tcc.Portal.Domain/"]
COPY ["ifsc.tcc.Portal.Application/ifsc.tcc.Portal.Application.csproj", "ifsc.tcc.Portal.Application/"]
COPY ["ifsc.tcc.Portal.Infra.Crosscutting/ifsc.tcc.Portal.Infra.Data.Crosscutting.csproj", "ifsc.tcc.Portal.Infra.Crosscutting/"]
RUN dotnet restore "ifsc.tcc.Portal.Api/ifsc.tcc.Portal.Api.csproj"
COPY . .
WORKDIR "/src/ifsc.tcc.Portal.Api"
RUN dotnet build "ifsc.tcc.Portal.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ifsc.tcc.Portal.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ifsc.tcc.Portal.Api.dll"]