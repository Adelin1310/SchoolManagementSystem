using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using server.Services.Interfaces;
namespace server.Services
{
    public class SituationsService : ISituationsService
    {
        private readonly SMGMSYSContext _context;
        private readonly IMapper _mapper;
        public SituationsService(SMGMSYSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SR<bool>> EndSituation(server.Dtos.Situations.EndSituationDto endSituationDto)
        {
            var res = new SR<bool>();
            try
            {
                var grades = await _context.dbo_Grade
                    .Where(x => x.StudentId == endSituationDto.StudentId
                        && x.SubjectId == endSituationDto.SubjectId
                        && x.ClassbookId == endSituationDto.ClassbookId)
                    .Select(x => x.Value)
                    .ToListAsync();
                var value = Math.Round((decimal)grades.Sum() / (decimal)grades.Count);
                await _context.dbo_Situations.AddAsync(new Models.dbo_Situations
                {
                    ClassbookId = endSituationDto.ClassbookId,
                    StudentId = endSituationDto.StudentId,
                    SubjectId = endSituationDto.SubjectId,
                    Value = value,
                    IsGeneralAverage = false
                });
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.StatusCode = StatusCodes.Status500InternalServerError;
                res.Success = false;
            }
            return res;
        }

    }
}