using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.Interfaces
{
    public interface ISituationsService
    {
        Task<SR<bool>> EndSituation(server.Dtos.Situations.EndSituationDto endSituationDto);
    }
}