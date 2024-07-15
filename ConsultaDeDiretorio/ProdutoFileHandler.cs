using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class ProdutoFileHandler
{

    public List<string> LerArquivosDoDiretorio(string diretorio, string padraoArquivo)
    {
        List<string> listaArquivos = new List<string>();

      
        if (Directory.Exists(diretorio))
        {
          
            string[] arquivos = Directory.GetFiles(diretorio, padraoArquivo);

            foreach (string arquivo in arquivos)
            {
                listaArquivos.Add(arquivo);
            }
        }
        else
        {
            Console.WriteLine("Diretório não encontrado.");
        }

        return listaArquivos;
    }


    public Dictionary<string, List<string>> ExtrairCodigosProduto(List<string> listaArquivos, string padraoCodigo)
    {
        Dictionary<string, List<string>> codigosProdutos = new Dictionary<string, List<string>>();
        Regex regex = new Regex(padraoCodigo);

        foreach (string arquivo in listaArquivos)
        {
            string nomeArquivo = Path.GetFileName(arquivo);
            Match match = regex.Match(nomeArquivo);

            if (match.Success)
            {
                string codigoProduto = match.Groups[1].Value;

                if (!codigosProdutos.ContainsKey(codigoProduto))
                {
                    codigosProdutos[codigoProduto] = new List<string>();
                }
                codigosProdutos[codigoProduto].Add(arquivo);
            }
        }

        return codigosProdutos;
    }

    public void ProcessarDiretorio(string diretorio, string padraoArquivo, string padraoCodigo)
    {
  
        List<string> listaArquivos = LerArquivosDoDiretorio(diretorio, padraoArquivo);

 
        Dictionary<string, List<string>> codigosProdutos = ExtrairCodigosProduto(listaArquivos, padraoCodigo);

   
        foreach (var item in codigosProdutos)
        {
            Console.WriteLine($"Código do Produto: {item.Key}");
            foreach (var arquivo in item.Value)
            {
                Console.WriteLine($"  Arquivo: {arquivo}");
            }
        }
    }
}
