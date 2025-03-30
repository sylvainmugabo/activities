using Application.Activities.DTOs;
using AutoMapper;
using Domain;

namespace Api.Mappers;

public class AutomapperProfiler : Profile
{
    public AutomapperProfiler()
    {
        
        CreateMap<CreateActivityDto, Activity>();
        CreateMap<UpdateActivityDto, Activity>();
    }
}