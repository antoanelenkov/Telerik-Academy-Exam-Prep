namespace Web.Infrastructure.Mappings
{
    using AutoMapper;

    interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration config);
    }
}
