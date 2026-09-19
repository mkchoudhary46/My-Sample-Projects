# My-Sample-Projects
This repo contains my sample projects.

## Local setup (Mac)

Prerequisites:

- [Homebrew](https://brew.sh) (recommended)
- Mono (installed automatically by the script if Homebrew is available)

From the repo root:

```bash
# Install Mono (if needed), restore NuGet packages, and build
bash .cursor/install.sh

# Run the ProgrammingPractice demo
bash .cursor/run-demo.sh
```

Manual Mono install:

```bash
brew install mono
```

Build only:

```bash
bash .cursor/install.sh
```

Run the demo directly:

```bash
printf '' | mono Source/ProgrammingPractice/ProgrammingPractice/bin/Debug/ProgrammingPractice.exe
```

The same `.cursor/install.sh` script is used by Cloud Agents on Linux.
