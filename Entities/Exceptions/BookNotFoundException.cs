namespace Entities.Exceptions
{
    // sealed keywordu bu sınıftan miras alınmamamasını sağlar
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"The book with id : {id} could not found")
        {

        }
    }


}
