using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string file1Path = "arquivo1.txt";
        string file2Path = "arquivo2.txt";

        // Lê o conteúdo dos arquivos para a memória
        string[] file1Content = File.ReadAllLines(file1Path);
        string[] file2Content = File.ReadAllLines(file2Path);

        // Remove as duplicatas em cada arquivo
        string[] uniqueFile1Content = RemoveDuplicates(file1Content);
        string[] uniqueFile2Content = RemoveDuplicates(file2Content);

        // Encontra os itens que não estão em ambos os arquivos
        var uniqueItems = GetUniqueItems(uniqueFile1Content, uniqueFile2Content);

        // Escreve o resultado em um novo arquivo
        string outputFilePath = "arquivo_novo.txt";
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (string item in uniqueItems)
            {
                writer.WriteLine(item);
            }
        }

        Console.WriteLine("Arquivo novo criado em: " + outputFilePath);
    }

    static string[] RemoveDuplicates(string[] arr)
    {
        var uniqueItems = new HashSet<string>();

        // Adiciona os itens únicos ao conjunto
        foreach (string item in arr)
        {
            uniqueItems.Add(item);
        }

        return uniqueItems.ToArray();
    }

    static string[] GetUniqueItems(string[] arr1, string[] arr2)
    {
        var uniqueItems = new HashSet<string>();

        // Adiciona todos os itens do primeiro array ao conjunto
        foreach (string item in arr1)
        {
            uniqueItems.Add(item);
        }

        // Remove os itens do segundo array do conjunto
        foreach (string item in arr2)
        {
            uniqueItems.Remove(item);
        }

        return uniqueItems.ToArray();
    }
}
