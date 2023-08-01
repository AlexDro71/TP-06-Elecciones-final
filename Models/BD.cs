
using System.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=Elecciones2023;Trusted_Connection=True;";

    public static void AgregarCandidato(Candidato can)
    {
        string sql = "INSERT INTO Candidato(idPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@pidPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pidPartido = can.idPartido, pApellido = can.Apellido, pNombre = can.Nombre, pFechaNacimiento = can.FechaNacimiento, pFoto = can.Foto, pPostulacion = can.Postulacion });

        }

    }

    public static void EliminarCandidato(int idCandidato)
    {
        int registrosEliminados = 0;
        string sql = "DELETE FROM Candidatos WHERE idCandidato = @Candidato";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            registrosEliminados = db.Execute(sql, new { Candidato = idCandidato });
        }
        
    }

    public static Partido verInfoPartido(int idPartido)
    {
        Partido miPartido = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido WHERE idPartido = @pidPartido";
            miPartido = db.QueryFirstOrDefault<Partido>(sql, new { pidPartido = idPartido });
        }

        return miPartido;
    }

    public static Candidato verInfoCandidato(int idCandidato)
    {
        Candidato miCandidato = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE idCandidato = @pidCandidato";
            miCandidato = db.QueryFirstOrDefault<Candidato>(sql, new { pidCandidato = idCandidato });
        }

        return miCandidato;
    }
    public static List<Partido> listarPartidos()
    {
        List<Partido> ListaPartidos = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido";
            ListaPartidos = db.Query<Partido>(sql).ToList();
        }
return ListaPartidos;
    }

    public static List<Candidato> listaCandidatos(int idPartido)
    {
        List<Candidato> ListaCandidatos = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {

            string sql = "SELECT * FROM Candidato WHERE idPartido = @cidPartido";
            ListaCandidatos = db.Query<Candidato>(sql, new{cidPartido = idPartido}).ToList();
        }
        return ListaCandidatos;
    } 
}