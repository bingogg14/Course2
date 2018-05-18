using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;

namespace Logic
{
    public interface ITourLogic
    {
        void AddTour(TourDTO NewTour);
        void EditTour(TourDTO NewTour);
        IEnumerable<TourDTO> GetAllToursTemplates();

    }
}
