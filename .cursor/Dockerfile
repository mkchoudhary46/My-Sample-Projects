FROM ubuntu:24.04

RUN apt-get update \
    && DEBIAN_FRONTEND=noninteractive apt-get install -y --no-install-recommends \
        mono-complete \
        curl \
        git \
        ca-certificates \
    && rm -rf /var/lib/apt/lists/* \
    && curl -fsSL https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -o /usr/local/bin/nuget.exe

USER ubuntu
