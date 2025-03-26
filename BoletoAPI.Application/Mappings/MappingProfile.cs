using AutoMapper;
using BoletoAPI.Application.DTOs;
using BoletoAPI.Domain.Entities;
using System;

namespace BoletoAPI.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Banco mappings
            CreateMap<Banco, BancoDto>().ReverseMap();
            
            // Boleto mappings
            CreateMap<Boleto, BoletoDto>().ReverseMap();
            
            CreateMap<Boleto, BoletoResponseDto>()
                .ForMember(dest => dest.ValorComJuros, opt => opt.MapFrom(src => src.CalcularValorComJuros()))
                .ForMember(dest => dest.NomeBanco, opt => opt.MapFrom(src => src.Banco != null ? src.Banco.Nome : string.Empty))
                .ForMember(dest => dest.CodigoBanco, opt => opt.MapFrom(src => src.Banco != null ? src.Banco.Codigo : string.Empty))
                .ForMember(dest => dest.PercentualJuros, opt => opt.MapFrom(src => src.Banco != null ? src.Banco.PercentualJuros : 0))
                .ForMember(dest => dest.Vencido, opt => opt.MapFrom(src => DateTime.Now > src.DataVencimento));
        }
    }
}

