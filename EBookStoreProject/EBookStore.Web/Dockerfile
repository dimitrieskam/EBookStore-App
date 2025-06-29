FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source

COPY . .

ARG TARGETARCH

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish EBookStore.Web/EBookStore.Web.csproj -c Release -a x64 --use-current-runtime --self-contained false -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

RUN apk add --no-cache icu-libs

WORKDIR /app

COPY --from=build /app .

ENV ASPNETCORE_URLS=http://+:80


ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

ENTRYPOINT ["dotnet", "EBookStore.Web.dll"]
