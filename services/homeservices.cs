using Dapper;
using MySqlConnector;
using CRUDREPOSITORY.Dto;
namespace CRUDREPOSITORY.Services
{
    public class Homeservices : IHomeinterface
    {
        readonly MySqlConnection connectionBD;

        public Homeservices(IConfiguration configuration)
        {
            var bancodeDados = configuration.GetConnectionString("DefaultConnection");
            connectionBD = new MySqlConnection(bancodeDados);
        }

        //get route
        public IEnumerable<users> AllPeople()
        {
            var queryCommand = @"
                select * from usuario";
            
            return connectionBD.Query<users>(queryCommand);
        }

        //post route
        public string NewPeople(users user)
        {
            var queryCommand = @"
                INSERT INTO usuario (Nome, Bio, Telefone) VALUES (@Nome, @Bio, @Telefone)";
            connectionBD.Execute(queryCommand, user);

            return "Novo usuario cadastrado com sucesso";
        }

        //put route
        public string UpdatePeople(users user)
        {
            var queryCommand = @"
                UPDATE usuario SET Nome = @Nome, Bio = @Bio, Telefone = @Telefone WHERE id = @id";
            connectionBD.Execute(queryCommand, user);

            return "aualizado com sucesso";
        }

        //delete route
        public string DeletePeople(int id)
        {
            var queryCommand = @"
                DELETE FROM usuario WHERE id = @id";
            connectionBD.Execute(queryCommand, new {Id = id});
            
            return "cadastro de pessoa deletado com sucesso";
        }

    }
}