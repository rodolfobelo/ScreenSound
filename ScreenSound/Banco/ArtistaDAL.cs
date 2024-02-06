using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    public IEnumerable<Artista> ListarArtista()
    {
        using var conn = new Connection().ObterConexao();
        conn.Open();

        string sql = "select * from Artistas";
        SqlCommand cmd = new SqlCommand(sql, conn);
        using SqlDataReader reader = cmd.ExecuteReader();

        var lista = new List<Artista>();
        while (reader.Read())
        {
            string nomeArtista = Convert.ToString(reader["Nome"]);
            string bioArtista = Convert.ToString(reader["Bio"]);
            int idArtista = Convert.ToInt32(reader["Id"]);

            Artista artista = new Artista(nomeArtista, bioArtista) { Id = idArtista };
            lista.Add(artista);
        }
        return lista;
    }

    public void AdicionarArtista(Artista artista)
    {
        using var conn = new Connection().ObterConexao();
        conn.Open();

        string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";
        SqlCommand command = new SqlCommand(sql, conn);

        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
        command.Parameters.AddWithValue("@bio", artista.Bio);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas {retorno}");
    }

    public void AtualizarArtista(Artista artista)
    {
        using var conn = new Connection().ObterConexao();
        conn.Open();

        string sqlUpdate = "UPDATE ARTISTAS SET Nome = @nome, Bio = @bio WHERE Id = @id";
        SqlCommand command = new SqlCommand( sqlUpdate, conn);

        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@bio", artista.Bio);
        command.Parameters.AddWithValue("@id", artista.Id);

        int retorno = command.ExecuteNonQuery();
        if (retorno == 0)
        {
            Console.WriteLine($"Nenhuma linha foi afetada!");
        }
        else
            Console.WriteLine($"{artista.Nome} alterado com sucesso!");
    }

    public void ExcluirArtista(Artista artista)
    {
        using var conn = new Connection().ObterConexao();
        conn.Open();

        string sqlDelete = $"delete from Artistas where Id = @id";
        SqlCommand commandDelete = new SqlCommand(sqlDelete, conn);

        commandDelete.Parameters.AddWithValue("@id", artista.Id);
        int retorno = commandDelete.ExecuteNonQuery();

        if (retorno == 0)
        {
            Console.WriteLine($"Nenhuma linha foi afetada!");
        }
        else
            Console.WriteLine($"{artista.Nome} excluido com sucesso!");
    }
}
