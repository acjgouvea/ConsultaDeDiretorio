using System;

public class Program
{
    public static void Main()
    {
        ProdutoFileHandler handler = new ProdutoFileHandler();

   
        string diretorio = @"P:\CarlosGouvea_Developer\CadastroProdutos\Fotos";


        string padraoArquivo = "*.JPG";

    
        string padraoCodigo = @"^(\d+)\s*\(.*\)\.JPG$";

        handler.ProcessarDiretorio(diretorio, padraoArquivo, padraoCodigo);
    }
}
