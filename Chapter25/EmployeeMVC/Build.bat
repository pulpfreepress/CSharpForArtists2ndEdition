ECHO Building Common.dll
msbuild /t:CompileCommon
ECHO Building Commands.dll
msbuild /t:CompileCommands
ECHO Building Exceptions.dll
msbuild /t:CompileExceptions
ECHO Building Utils.dll
msbuild /t:CompileUtils
ECHO Building Model.dll
msbuild /t:CompileModel
ECHO Building View.dll
msbuild /t:CompileView
ECHO Building Application
msbuild /t:CompileApp
ECHO Running Application
msbuild /t:Run
