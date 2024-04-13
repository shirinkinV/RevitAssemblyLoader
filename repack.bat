rmdir /S /Q "Destination\"
ILRepack -target:library -lib:"C:\Program Files\Autodesk\Revit 2022" -out:"Destination\RevitAssemblyLoader\RevitAssemblyLoader.dll" "RevitAssemblyLoader.Startup\bin\x64\Release\net48\RevitAssemblyLoader.dll" 
"RevitAssemblyLoader.Startup\bin\x64\Release\net48\RevitAssemblyLoader.dll" 
"RevitAssemblyLoader.Startup\bin\x64\Release\net48\RevitAssemblyLoader.Abstractions.dll" 
"RevitAssemblyLoader.Startup\bin\x64\Release\net48\RevitAssemblyLoader.DI.dll" 
"RevitAssemblyLoader.Startup\bin\x64\Release\net48\RevitAssemblyLoader.MaterialDesignCut.dll" 
"RevitAssemblyLoader.Startup\bin\x64\Release\net48\RevitAssemblyLoader.Model.dll"
//TODO put all files there and format string
xcopy "RevitAssemblyLoader.Startup\RevitAssemblyLoader.addin" "Destination\RevitAssemblyLoader.addin"
pause
