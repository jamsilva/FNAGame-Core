#!/bin/sh

if [ $# -ge 1 ]; then
	mv "FNAGame"           "$1"
	mv "$1/FNAGame.cs"     "$1/$1.cs"
	mv "$1/FNAGame.csproj" "$1/$1.csproj"
	sed -i "s/FNAGame/$1/g" $1/*.cs* $1/.vscode/*
fi

git submodule update --init --recursive
sed -i 's/net40;//g' FNA/FNA.Core.csproj
mkdir fnalibs
curl http://fna.flibitijibibo.com/archive/fnalibs.tar.bz2 | tar -xj -C fnalibs
