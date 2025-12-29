using CRUDREPOSITORY.Dto;

namespace CRUDREPOSITORY.Services
{
    public interface IHomeinterface
    {
        IEnumerable<users> AllPeople();

        string NewPeople(users user);

        string UpdatePeople(users user);

        string DeletePeople(int id);
    }
}