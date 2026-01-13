using Domain.Dto.Participant;
using Domain.Entities;
using Domain.Response;

namespace Infrastructure.Interfaces;

public interface IParticipantService
{
    Response<List<GetParticipant>> GetAllParticipants();
    Response<string> CreatedParticipant(CreatedParticipant dto);
    Response<string> UpdateParticipant(int id, UpdateParticipant dto);
    Response<string> DeleteParticipant(int id);
}