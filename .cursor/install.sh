#!/usr/bin/env bash
set -euo pipefail

ROOT="${WORKSPACE:-/workspace}"
NUGET=/usr/local/bin/nuget.exe

if ! command -v mono >/dev/null 2>&1; then
  sudo DEBIAN_FRONTEND=noninteractive apt-get update -qq
  sudo DEBIAN_FRONTEND=noninteractive apt-get install -y -qq mono-complete curl ca-certificates
fi

if [[ ! -f "$NUGET" ]]; then
  sudo curl -fsSL https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -o "$NUGET"
  sudo chmod +x "$NUGET"
fi

cd "$ROOT"

while IFS= read -r packages_config; do
  project_dir="$(dirname "$packages_config")"
  packages_dir="$(dirname "$project_dir")/packages"
  mono "$NUGET" restore "$packages_config" -PackagesDirectory "$packages_dir" -NonInteractive
done < <(find Source -name packages.config | sort)

xbuild Source/MyProjects.sln /p:Configuration=Debug /verbosity:minimal /nologo
