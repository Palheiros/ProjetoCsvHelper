using static System.Console;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;
using ProjectCsvHelper.Model;

//LerCsvComDynamic();
//LerCsvComClasse();
LerCsvComDelimitador();
EscreverCsv();

static void LerCsvComDelimitador()
{
        var path = Path.Combine(Environment.CurrentDirectory,"Entrada","livros.csv");
    var fi = new FileInfo(path);

    if(!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe!");
    
    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";"
    };
    using var csvReader = new CsvReader(sr, csvConfig);
    csvReader.Context.RegisterClassMap<LivroMap>();
    var registros = csvReader.GetRecords<Livro>();

    foreach(var registro in registros)
    {
        WriteLine($"Título: {registro.Titulo}");
        WriteLine($"Preço: R${registro.Preco}");
        WriteLine($"Autor: {registro.Autor}");
        WriteLine($"Lançamento: {registro.Lancamento}");
        WriteLine("-----------------------------------");
    }
    WriteLine("Pressione [Enter] para finalizar a aplicação.");
    ReadLine();
}

static void LerCsvComClasse()
{
    var path = Path.Combine(Environment.CurrentDirectory,"Entrada","novos-usuarios.csv");
    var fi = new FileInfo(path);

    if(!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe!");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr, csvConfig);

    var registros = csvReader.GetRecords<Usuario>();

    foreach(var registro in registros)
    {
        WriteLine($"Nome: {registro.Nome}");
        WriteLine($"Email: {registro.Email}");
        WriteLine($"Telefone: {registro.Telefone}");
        WriteLine("-----------------------------------");
    }
    WriteLine("Pressione [Enter] para finalizar a aplicação.");
    ReadLine();
}


static void LerCsvComDynamic()
{
    var path = Path.Combine(Environment.CurrentDirectory,"Entrada","Produtos.csv");

    var fi = new FileInfo(path);

    if(!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe!");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr, csvConfig);

    var registros = csvReader.GetRecords<dynamic>();

    foreach(var registro in registros)
    {
        WriteLine($"Produto: {registro.Produto}");
        WriteLine($"Marca: {registro.Marca}");
        WriteLine($"Preço: {registro.Preco}");
        WriteLine("-----------------------------------");
    }

    WriteLine("Aperte [Enter] para terminar o aplicativo.");
    ReadLine();
}

static void EscreverCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Saida");
    var di = new DirectoryInfo(path);

    if(!di.Exists)
        di.Create();
    
    path = Path.Combine(path,"usuariosNovos.csv");

    var pessoas = new List<Pessoa>()
    {
        new Pessoa()
        {
            Nome = "Zeca Pagodinho",
            Email = "zeca@gmail.com",
            Telefone = 969645521
        },
        new Pessoa()
        {
            Nome = "Diogo Nogueira",
            Email = "dn@gmail.com",
            Telefone = 989742221
        },
        new Pessoa()
        {
            Nome = "Bezerra da Silva",
            Email = "malandragem@gmail.com",
            Telefone = 917198763
        }        
    };
    using var sr = new StreamWriter(path);
    using var csvWriter = new CsvWriter(sr, CultureInfo.InvariantCulture);
    csvWriter.WriteRecords(pessoas);
}