using AutoMapper;
using Yucom.DTOs;
using Yucom.Entity;

namespace Yucom.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BoletoCreationDTO, Boleto>().ReverseMap();
            CreateMap<ClienteCreationDTO, Cliente>().ReverseMap();
            CreateMap<Sede, SedeCreationDTO>().ReverseMap();
            CreateMap<Destacados, DestacadoCreationDTO>()
                .ForMember(x => x.eventoDestacado, opciones => opciones.MapFrom(MapDestacadoEvento)).ReverseMap();
            CreateMap<Evento, EventoDestacado>().ReverseMap();
            CreateMap<EventosCreationDTO, Evento>()
                .ForMember(evento => evento.EventoPresentadors, opciones => opciones.MapFrom(MapEventoPresentadores))
                .ForMember(sede => sede.eventoSedes, opciones => opciones.MapFrom(MapEventoSedes));
            CreateMap<EventoDTO, Evento>().ReverseMap();
            CreateMap<Evento, EventoDTO>()
                .ForMember(eventoDTO => eventoDTO.presentadorCreationDTOs, opciones => opciones.MapFrom(MapEventoDTOPresentador))
                .ForMember(eventoDto => eventoDto.sede, opciones => opciones.MapFrom(MapEventoDTOSede));
            CreateMap<PresentadorCreationDTO, Presentador>().ReverseMap();
            CreateMap<ReservacionCreationDTO, Reservacion>();
            CreateMap<Evento, EventosCreationDTO>();            
            CreateMap<Presentador, PresentadorCreationDTO>().ReverseMap();
            CreateMap<Reservacion, ReservacionCreationDTO>();
        }
        
        private List<EventoDestacado>MapDestacadoEvento(Destacados destacados, DestacadoCreationDTO destacadoCreationDTO)
        {
            var resultado = new List<EventoDestacado>();

            if( destacados.eventoDestacados == null ) { return resultado; }
            foreach (var eventodes in destacados.eventoDestacados)
            {
                resultado.Add(new EventoDestacado()
                {
                    Nombre = eventodes.Nombre,
                    Descripcion = eventodes.Descripcion,
                    Fotografia = eventodes.Fotografia
                });
            }

            return resultado;
        }

        private List<SedeCreationDTO>MapEventoDTOSede(Evento evento, EventoDTO eventoDTO)
        {
            var resultado = new List<SedeCreationDTO>();
            if(evento.eventoSedes == null) {return resultado;} 

            foreach (var eventoSede in evento.eventoSedes)
            {
                resultado.Add(new SedeCreationDTO()
                {
                    Id = eventoSede.sede.Id,
                    Nombre = eventoSede.sede.Nombre,
                    RFC = eventoSede.sede.RFC,
                    Imagenes = eventoSede.sede.Imagenes,
                    Descripcion = eventoSede.sede.Descripcion,
                    Status = eventoSede.sede.Status
                });
            }

            return resultado;
        }

        private List<PresentadorCreationDTO>MapEventoDTOPresentador(Evento evento, EventoDTO eventoDTO )
        {
            var resultado = new List<PresentadorCreationDTO>();

            if(evento.EventoPresentadors == null) {return resultado;}

            foreach(var eventoPresentador in evento.EventoPresentadors)
            {
                resultado.Add(new PresentadorCreationDTO()
                {
                    Id = eventoPresentador.PresentadorId,
                    Nombre = eventoPresentador.Presentador.Nombre,
                    Fotografia = eventoPresentador.Presentador.Fotografia,
                    RFC = eventoPresentador.Presentador.RFC,
                    Descripcion = eventoPresentador.Presentador.Descripcion
                });
            }
            return resultado;
        }

        private List<EventoPresentador> MapEventoPresentadores(EventosCreationDTO eventosCreationDTO, Evento evento)
        {
            var resultado = new List<EventoPresentador>();

            if(eventosCreationDTO.PresentadoresIds == null){ return resultado; }

            foreach(var presentadorId in eventosCreationDTO.PresentadoresIds)
            {
                resultado.Add(new EventoPresentador() {PresentadorId = presentadorId});
            }
            return resultado;
        }

        private List<EventoSede> MapEventoSedes (EventosCreationDTO eventosCreationDTO, Evento evento)
        {
            var resultado = new List<EventoSede>();

            if(eventosCreationDTO.SedesIds == null) {return resultado;}

            foreach (var sedesId in eventosCreationDTO.SedesIds)
            {
                resultado.Add(new EventoSede() {SedeId = sedesId});
            }

            return resultado;
        }

    }
}