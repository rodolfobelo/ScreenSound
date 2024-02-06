using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;

try
{
    var artistaDal = new ArtistaDAL();
    var artista1 = new Artista("Foo Fighters", "Foo Fighters é uma banda de rock alternativo americana formada por Dave Grohl em 1995.");
    Artista artistaMarley = new Artista("Bob Marley", "Robert Nesta Marley foi um cantor e compositor jamaicano, o mais conhecido músico de reggae de todos os tempos") { Id = 9 };
    Artista artistaNatiruts = new Artista("Natiruts", "Natiruts, anteriormente conhecida como Nativus, é uma banda de reggae brasileira formada em 1996 em Brasília.") { Id = 11 };
    //artistaDal.ExcluirArtista(artistaMarley);
    //artistaDal.AdicionarArtista(artistaNatiruts);
    //artistaDal.AtualizarArtista(artistaNatiruts);

    var metricaDAL = new MetricaDAL();
    metricaDAL.ListarMetrica("20232", "20232");

    var listaArtista = new ArtistaDAL().ListarArtista();

    foreach (var artista in listaArtista)
    {
        Console.WriteLine(artista);
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

return;

Artista ira = new Artista("Ira!", "Banda Ira!");
Artista beatles = new("The Beatles", "Banda The Beatles");

Dictionary<string, Artista> artistasRegistrados = new();
artistasRegistrados.Add(ira.Nome, ira);
artistasRegistrados.Add(beatles.Nome, beatles);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarArtista());
opcoes.Add(2, new MenuRegistrarMusica());
opcoes.Add(3, new MenuMostrarArtistas());
opcoes.Add(4, new MenuMostrarMusicas());
opcoes.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um artista");
    Console.WriteLine("Digite 2 para registrar a música de um artista");
    Console.WriteLine("Digite 3 para mostrar todos os artistas");
    Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(artistasRegistrados);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();