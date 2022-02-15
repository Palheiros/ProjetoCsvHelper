using System.Globalization;
using CsvHelper.Configuration;
using ProjectCsvHelper.Model;

public class LivroMap : ClassMap<Livro>
    {
        public LivroMap()
        {
            Map(x=> x.Titulo).Name("Título");
            Map(x=> x.Preco).Name("Preço").TypeConverterOption
            .CultureInfo(CultureInfo.GetCultureInfo("pt-BR"));
            Map(x=> x.Autor).Name("Autor");
            Map(x=> x.Lancamento).Name("Lançamento").TypeConverterOption.Format(new [] {"dd/MM/yyyy"});
        }
    }