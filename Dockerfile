FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine-amd64 AS base
RUN apk --no-cache upgrade && \
    apk add --no-cache --virtual=run-deps \
      certbot \
      bash

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine-amd64 AS build
COPY ./ /src/
WORKDIR /src/CertbotAliyunDns/
RUN dotnet publish "CertbotAliyunDns.csproj" -p:PublishSingleFile=true -r linux-musl-x64 --self-contained true -p:PublishTrimmed=True -c Release -o /app/publish

FROM base
LABEL maintainer="HMBSbige"
WORKDIR /app
COPY --from=build /app/publish .

VOLUME ["/etc/letsencrypt"]
ENTRYPOINT ["certbot"]