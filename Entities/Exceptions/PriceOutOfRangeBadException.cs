
namespace Entities.Exceptions
{
    public abstract partial class BadRequestException
    {
        public class PriceOutOfRangeBadException : BadRequestException
        {
            public PriceOutOfRangeBadException()
                : base("Max Price should be less than 1000 and greater than 10")
            {

            }
        }
    }
}
