using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'towerBreakers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     */

    public static int towerBreakers(int n, int m)
    {
        int currentPlayer = 1;
        List<int> towers = new List<int>(n);
        for(int i = 0; i < n; i++)
            towers.Add(m);
        while(isThereAnotherRound(towers)) {
            currentPlayer = switchPlayer(currentPlayer);
            playRound(towers);
        }
        return currentPlayer;
    }
    public static void playRound(List<int> towers) {
        int max = towers.Max();
        int index = towers.LastIndexOf(towers.Max());
        for(int i = max - 1; i > 0; --i) {
            if (max % i == 0) {
                towers[index] = i;
                break;
            }
        }
    }
    public static bool isThereAnotherRound(List<int> towers) {
        int counter = 0;
        for(int i = 0; i < towers.Count; i++) {
            if (towers[i] > 1) {
               counter++;
            }
            if (counter > 1) {
                return true;
            }
        }
        return counter > 1 ? true : false;
    }
    public static int switchPlayer(int currentPlayer) {
        return currentPlayer == 1 ? 2 : 1;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.towerBreakers(n, m);

            Console.WriteLine(result);
        }
    }
}
