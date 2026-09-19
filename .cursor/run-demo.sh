#!/usr/bin/env bash
set -euo pipefail

ROOT="${WORKSPACE:-$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)}"
APP="$ROOT/Source/ProgrammingPractice/ProgrammingPractice/bin/Debug/ProgrammingPractice.exe"

if [[ ! -f "$APP" ]]; then
  echo "Build output not found. Run: bash .cursor/install.sh" >&2
  exit 1
fi

printf '' | mono "$APP"
