#!/bin/sh

if [ $# -ge 1 ]; then
	mv "FNAGame.cs"     "$1.cs"
	mv "FNAGame.csproj" "$1.csproj"
	sed -i "s/FNAGame/$1/g" "$1.cs" Program.cs .vscode/*
fi

git submodule update --init --recursive
mkdir Dependencies/fnalibs
curl http://fna.flibitijibibo.com/archive/fnalibs.tar.bz2 | tar -xj -C Dependencies/fnalibs
