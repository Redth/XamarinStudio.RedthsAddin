#!/bin/bash

nuget restore RedthAddin.sln

msbuild /p:Configuration=Release RedthAddin.sln

/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool setup pack RedthAddin/bin/Release/RedthAddin.dll