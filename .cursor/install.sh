#!/usr/bin/env bash
set -euo pipefail

ROOT="${WORKSPACE:-$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)}"
OS="$(uname -s)"
LOCAL_BIN="${HOME}/.local/bin"
NUGET="${NUGET_PATH:-}"

ensure_mono() {
  if command -v mono >/dev/null 2>&1; then
    return 0
  fi

  case "$OS" in
    Linux)
      sudo DEBIAN_FRONTEND=noninteractive apt-get update -qq
      sudo DEBIAN_FRONTEND=noninteractive apt-get install -y -qq mono-complete curl ca-certificates
      ;;
    Darwin)
      if command -v brew >/dev/null 2>&1; then
        brew install mono
      else
        echo "Mono is required. Install Homebrew (https://brew.sh), then run: brew install mono" >&2
        exit 1
      fi
      ;;
    *)
      echo "Unsupported OS: $OS. Install Mono manually, then rerun this script." >&2
      exit 1
      ;;
  esac
}

ensure_nuget() {
  if [[ -n "$NUGET" && -f "$NUGET" ]]; then
    return 0
  fi

  case "$OS" in
    Linux)
      NUGET=/usr/local/bin/nuget.exe
      if [[ ! -f "$NUGET" ]]; then
        sudo curl -fsSL https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -o "$NUGET"
        sudo chmod +x "$NUGET"
      fi
      ;;
    Darwin)
      mkdir -p "$LOCAL_BIN"
      NUGET="$LOCAL_BIN/nuget.exe"
      if [[ ! -f "$NUGET" ]]; then
        curl -fsSL https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -o "$NUGET"
        chmod +x "$NUGET"
      fi
      if [[ ":$PATH:" != *":$LOCAL_BIN:"* ]]; then
        export PATH="$LOCAL_BIN:$PATH"
      fi
      ;;
    *)
      echo "Unsupported OS: $OS" >&2
      exit 1
      ;;
  esac
}

build_solution() {
  local sln="$ROOT/Source/MyProjects.sln"
  local args=(/p:Configuration=Debug /verbosity:minimal /nologo "$sln")

  if command -v msbuild >/dev/null 2>&1; then
    msbuild "${args[@]}"
  elif command -v xbuild >/dev/null 2>&1; then
    xbuild "${args[@]}"
  else
    echo "Neither msbuild nor xbuild was found. Reinstall Mono and try again." >&2
    exit 1
  fi
}

ensure_mono
ensure_nuget

cd "$ROOT"

while IFS= read -r packages_config; do
  project_dir="$(dirname "$packages_config")"
  packages_dir="$(dirname "$project_dir")/packages"
  mono "$NUGET" restore "$packages_config" -PackagesDirectory "$packages_dir" -NonInteractive
done < <(find Source -name packages.config | sort)

build_solution
