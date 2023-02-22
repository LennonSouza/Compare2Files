using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string file1Path = "arquivo1.txt";
        string file2Path = "arquivo2.txt";
        string outputFilePath = "arquivo_novo.txt";

        // Lê o conteúdo dos arquivos para memória
        string[] file1Content = File.ReadAllLines(file1Path);
        string[] file2Content = File.ReadAllLines(file2Path);

        // Encontra os itens que não estão em ambos os arquivos
        var uniqueItems = GetUniqueItems(file1Content, file2Content);

        // Escreve o resultado em um novo arquivo
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (string item in uniqueItems)
            {
                writer.WriteLine(item);
            }
        }

        Console.WriteLine("Arquivo novo criado em: " + outputFilePath);
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