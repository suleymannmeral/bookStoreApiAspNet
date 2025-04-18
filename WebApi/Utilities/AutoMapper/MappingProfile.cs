using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate,Book> ().ReverseMap();  // Source Destination
            CreateMap<Book,BookDto> ();  // Source Destination 
            CreateMap<BookDtoForInsertion,Book> ();  // Source Destination 
        }

    }

    // İfadeleri Maplayeblirmek için(enititler ile dtoları ) bu dosyaya ihtriyaç var. Images klasöründe images_10_1 de görsel var.
}
