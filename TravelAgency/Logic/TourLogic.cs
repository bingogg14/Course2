using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Logic.DTOs;
using AutoMapper;

namespace Logic
{
    public class TourLogic
    {
        UnitOfWork UoW;

        public TourLogic(UnitOfWork UoW)
        {
            TourLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TourDTO, Tour>();
                cfg.CreateMap<Tour, TourDTO>();
            }).CreateMapper();
            this.UoW = UoW;
        }

        IMapper TourLogicMapper;

        public TourLogic()
        {
            TourLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TourDTO, Tour>();
                cfg.CreateMap<Tour, TourDTO>();
            }).CreateMapper();
            UoW = new UnitOfWork();
        }

        public void AddTour(TourDTO NewTour)
        {
            UoW.ToursTemplates.Add(TourLogicMapper.Map<TourDTO, Tour>(NewTour));
        }

        public void DeleteTour(int Id)
        {
            UoW.ToursTemplates.Delete(Id);
        }

        public void EditTour(int Id, TourDTO Tour)
        {
            UoW.ToursTemplates.Modify(Id, TourLogicMapper.Map<TourDTO, Tour>(Tour));
        }

        public IEnumerable<TourDTO> GetAllToursTemplates()
        {
            return TourLogicMapper.Map<IEnumerable<Tour>, List<TourDTO>>(UoW.ToursTemplates.GetAll());
        }

        public TourDTO GetTour(int Id)
        {
            return TourLogicMapper.Map<Tour, TourDTO>(UoW.ToursTemplates.GetAll().FirstOrDefault(t => t.Id == Id));
        }
    }
}
