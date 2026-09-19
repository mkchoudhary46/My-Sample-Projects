#!/usr/bin/env bash
set -euo pipefail

ROOT="${WORKSPACE:-/workspace}"
NUGET=/usr/local/bin/nuget.exe

cd "$ROOT"

while IFS= read -r packages_config; do
  project_dir="$(dirname "$packages_config")"
  packages_dir="$(dirname "$project_dir")/packages"
  mono "$NUGET" restore "$packages_config" -PackagesDirectory "$packages_dir" -NonInteractive
done < <(find Source -name packages.config | sort)

xbuild Source/MyProjects.sln /p:Configuration=Debug /verbosity:minimal /nologo
