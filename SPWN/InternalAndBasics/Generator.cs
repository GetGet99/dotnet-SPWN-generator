namespace SPWNCreator;
using SPWN.Basics;

public static class Generator
{
    public static void PrintToConsole(SPWNCodes Codes)
    {
        System.Console.WriteLine(GenerateAsString(Codes));
    }
    public static string GenerateAsString(SPWNCodes Codes)
    {
        string s = "";
        s += "impl @counter { set: (self, var1) => self = var1 }" + "\n\n";
        s += Codes.CreateCode().ReplaceLineEndings("\n").Replace("\t", new string(' ', 4));
        return s;
    }
}