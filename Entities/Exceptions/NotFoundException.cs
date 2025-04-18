
namespace Entities.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        // protected constructor olduğu için sadece bu sınıfı miras alan sınıflar kendi constructor'larında çağırabilir.
        // base Exception classına parametre oalrak verilir
        protected NotFoundException(string message) : base(message)
        {

        }
    }


}
