using Domain.Base;
using Domain.Interfaces;
using Riok.Mapperly.Abstractions;

namespace Domain.Mappers;

[Mapper(PropertyNameMappingStrategy = PropertyNameMappingStrategy.CaseInsensitive)]

public static partial class PaginationMappers
{
    public static partial Pagination ToPagination(this IPagination _pagination);   
}