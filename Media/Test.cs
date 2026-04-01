using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    public class Symbol
    {
        public char symbol { get; set; }
        public int frequence { get; set; }
        public string code { get; set; }
    }
   public static void SplitSymbols(List<Symbol> symbols)
    {
        int frequnces=symbols.Sum(symbol => symbol.frequence);
        int acc = 0;
        int splitindex=0;
        foreach (Symbol symbol in symbols)
        {
            acc += symbol.frequence;
            if (acc >= (frequnces / 2))
                break;
            splitindex++;
        }
        for(int i = 0; i < symbols.Count; i++)
        {
            if (i <= splitindex)
                symbols[i].code += '1';
            else
                symbols[i].code += '0';
        }
        SplitSymbols(symbols.Take(splitindex+1).ToList());
        SplitSymbols(symbols.Skip(splitindex + 1).ToList());

    }
    static List<Symbol> Encode(Dictionary<char, int> input)
    {
        var data = input.Select(p => new Symbol { symbol = p.Key, frequence=p.Value }).OrderByDescending(o=>o.frequence).ToList();
       SplitSymbols(data);
        return data;
    }

}