using Domain.Dto.Participant;
using Domain.Response;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ParticipantService : IParticipantService
{
    public Response<List<GetParticipant>> GetAllParticipants()
    {
        throw new NotImplementedException();
    }

    public Response<string> CreatedParticipant(CreatedParticipant dto)
    {
        throw new NotImplementedException();
    }

    public Response<string> UpdateParticipant(int id, UpdateParticipant dto)
    {
        throw new NotImplementedException();
    }

    public Response<string> DeleteParticipant(int id)
    {
        throw new NotImplementedException();
    }
}