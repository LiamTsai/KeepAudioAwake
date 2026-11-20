# Builds KeepAudioAwake.exe with the C# compiler bundled in .NET Framework 4.x (no SDK needed).
$csc = "$env:WINDIR\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
& $csc /nologo /target:winexe /codepage:65001 /optimize `
    /r:System.Windows.Forms.dll /r:System.Drawing.dll `
    /out:"$PSScriptRoot\KeepAudioAwake.exe" "$PSScriptRoot\src\KeepAudioAwake.cs"
