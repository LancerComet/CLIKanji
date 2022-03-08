using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kawazu;

namespace CLIKanji {
  internal class Program {
    private static void PrintHelp () {
      Console.WriteLine("CLIKanji - Make Japanese easy");
      Console.WriteLine("LancerComet # Carry Your World #");
      Console.WriteLine("");
      Console.WriteLine("Usage:");
      Console.WriteLine("> CLIKanji 君が大好き");
      Console.WriteLine("");
      Console.WriteLine("Output:");
      Console.WriteLine("  きみがだいすき");
      Console.WriteLine("  キミガダイスキ");
      Console.WriteLine("  kimigadaisuki");
      Console.WriteLine("");
    }
    
    public static async Task Main (string[] args) {
      var arguments = args.ToList();
      if (arguments.Count < 1 || arguments.Contains("-h")) {
        PrintHelp();
        return;
      }

      var resultHiragana = new List<string>();
      var resultKatakana = new List<string>();
      var resultRomaji = new List<string>();
      
      var converter = new KawazuConverter();
      foreach (var inputText in arguments) {
        var hiragana = await converter.Convert(inputText, To.Hiragana);
        var katakana = await converter.Convert(inputText, To.Katakana);
        var romaji = await converter.Convert(inputText, To.Romaji);
        
        resultHiragana.Add(hiragana);
        resultKatakana.Add(katakana);
        resultRomaji.Add(romaji);
      }
      
      Console.WriteLine(string.Join(" ", resultHiragana));
      Console.WriteLine(string.Join(" ", resultKatakana));
      Console.WriteLine(string.Join(" ", resultRomaji));
    }
  }
}