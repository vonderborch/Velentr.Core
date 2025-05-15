# Velentr.Core

![Logo](https://raw.githubusercontent.com/vonderborch/Velentr.Core/refs/heads/main/logo.png)

The core Velentr package, containing helpers and basic objects and interfaces shared across other Velentr packages.

## Installation

### Nuget

[![NuGet version (Velentr.Core)](https://img.shields.io/nuget/v/Velentr.Core.svg?style=flat-square)](https://www.nuget.org/packages/Velentr.Core/)

The recommended installation approach is to use the available nuget
package: [Velentr.Core](https://www.nuget.org/packages/Velentr.Core/)

### Clone

Alternatively, you can clone this repo and reference the Velentr.Core project in your project.

## Features

- Color Helpers: Convert from RGB to hex, HSL, and HSV (and back)
- Various helpers for working with directories, files and archive files
- Wrappers on common JSON operations
- Various mathematical helpers:
    - Bounds struct (representing a range of valid values)
    - Fixed Point Math structs (ranging from 2 decimals of precision to 8), including math helpers
    - Pseudo-random number generators, with some common extensions added
    - Various math helpers that are missing by default
- Classes to help with tracking performance
- Various string helpers and extensions, such as MessageTemplate-style formatting, ascii tables, and string similarity.
- Various default interfaces for common potential methods in XNA-derived frameworks

## Development

### Requirements

- Some way to build C# projects
- This project cloned, forked, downloaded, etc.
- Powershell (for running some build scripts)
- Python (for setting up dependencies and for running some build scripts)
    - NOTE: make sure to run `update_or_install_fna.py` to install FNA for the repo
    - NOTE: FNA generally updates once a month, so if you've previously run the script and it's been a while, you may
      want
      to run it again to get the latest version

### Instructions

1. Clone or fork the repo
2. Create a new branch
3. Code!
4. Push your changes and open a PR
5. Once approved, they'll be merged in
6. Profit!

## Future Plans

See list of issues under the Milestones: https://github.com/vonderborch/Velentr.Core/milestones

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

Certain portions of this project are licensed under other licenses. See individual files for specific licenses as they
apply.
