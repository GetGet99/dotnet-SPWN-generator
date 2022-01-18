namespace SPWN;
using SPWN.Basics;
using SysColGen = System.Collections.Generic;
using static SPWN.Utilities.Implementation.Methods;
using SPWN.DataTypes.Base;
public static class Generator
{
    //public enum CasesConvertMode
    //{
    //    None,
    //    Camel,
    //    Pascal,
    //    Snake
    //}
    //public static CasesConvertMode AutoCaseForCustomImplementation = CasesConvertMode.None;
    //private static string CaseConvert(string In)
    //{
    //    switch (AutoCaseForCustomImplementation)
    //    {
    //        case CasesConvertMode.Pascal:
    //            var index = In.IndexOf('_');
    //            bool first = false, last = false;
    //            while (index != -1)
    //            {
    //                if (index == 0)
    //                {
    //                    first = true; // Must added back, probably intentional behavior
    //                }
    //            }
    //            return
    //    }
    //}
    public static void PrintToConsole(SPWNCodes Codes)
    {
        System.Console.WriteLine(GenerateAsString(Codes));
    }
    public static string GenerateAsString(SPWNCodes Codes)
    {
        string s = "";
        s += Codes.CreateCode().ReplaceLineEndings("\n").Replace("\t", new string(' ', 4));
        return s;
    }
    public static SysColGen.Dictionary<string, string> GenerateAsDict(SPWNCodes Codes)
    {
        var dict = new SysColGen.Dictionary<string, string>();
        //var AllTypes = Codes.TypesMentioned;
        string main = "";
        //foreach (var type in AllTypes)
        //{
        //    var dictimplement = new SysColGen.Dictionary<string, SPWNValueBase>();
        //    foreach (var fields in type.GetFields())
        //    {
        //        dictimplement.Add(fields.Name, fields.Attributes); // Unfinished
        //    }
        //    main += Implement(SPWN.DataTypes.TypeIndicator.GetType(type),dictimplement).CreateCode().ReplaceLineEndings("\n").Replace("\t", new string(' ', 4));
        //}
        main += Codes.CreateCode().ReplaceLineEndings("\n").Replace("\t", new string(' ', 4));
        dict.Add("main.spwn", main);
        return dict;
    }

    public static void WriteToFile(SPWNCodes Codes)
    {
        var allFiles = GenerateAsDict(Codes);
        foreach (var (fileName, code) in allFiles)
        {
            System.IO.File.WriteAllText(fileName, code);
        }
    }

    public static System.Diagnostics.Process WriteAndCompile(SPWNCodes Codes, bool LevelConsoleOutput = false, bool WaitForExit = false)
    {
        WriteToFile(Codes);
        var process = new System.Diagnostics.Process()
        {
            StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "spwn",
                Arguments = $"build main.spwn {(LevelConsoleOutput ? "-c" : "")}",
                CreateNoWindow = true,
                ErrorDialog = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = System.Environment.CurrentDirectory
            }
        };
        process.ErrorDataReceived += (sendingProcess, errorLine) => System.Console.Error.WriteLine(errorLine.Data);
        process.OutputDataReceived += (sendingProcess, dataLine) => System.Console.WriteLine(dataLine.Data);
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();


        if (WaitForExit && !process.HasExited) process.WaitForExit();

        System.Console.WriteLine($"SPWN exited with code {process.ExitCode}");

        return process;
    }
}