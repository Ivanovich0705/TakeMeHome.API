using AutoMapper;
using TakeMeHome.API.TakeMeHome.Domain.Models;
using TakeMeHome.API.TakeMeHome.Resources;

namespace TakeMeHome.API.TakeMeHome.Mapping;

public class ResourceToModelProfile : Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<SaveUserResource, User>();
    }
}