namespace SPWNCreator;
using SPWN.Basics;

public static class Generator
{
    public static void PrintToConsole(SPWNCodes Codes)
    {
        System.Console.WriteLine(Codes.CreateCodes().ReplaceLineEndings("\n").Replace("\t",new string(' ',4)));
    }
}