FNA game project for .Net Core 3.1 on Linux
===========================================

This repository contains a minimal FNA game project that can be built with .Net Core 3.1 and Visual Studio Code on Linux in just a few steps:

- Run **`sh prepare.sh NewProjectName`** which automates these actions:
  1. Rename FNAGame to NewProjectName.
  2. Get the git submodules (just the FNA source code and dependencies) using **`git submodule update --init --recursive`**.
  3. Extract the contents of [http://fna.flibitijibibo.com/archive/fnalibs.tar.bz2](fnalibs.tar.bz2) to the `fnalibs` directory.
  4. Remove `net40;` from `TargetFrameworks` in `FNA/FNA.Core.csproj` to work around a problem in the Visual Studio Code C# extension.
- Open Visual Studio Code in the `FNAGame` folder and build and run the game! For best results make sure you have the C# extension installed.