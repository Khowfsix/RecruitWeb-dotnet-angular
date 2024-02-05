using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service;

public class ItrsinterviewService : IItrsinterviewService
{
    private readonly IItrsinterviewRepository _itrsinterviewRepository;
    private readonly IInterviewRepository _interviewRepository;
    private readonly IMapper _mapper;

    public ItrsinterviewService(IItrsinterviewRepository itrsinterviewRepository, IInterviewRepository interviewRepository, IMapper mapper)
    {
        _itrsinterviewRepository = itrsinterviewRepository;
        _interviewRepository = interviewRepository;
        _mapper = mapper;
    }

    public async Task<ItrsinterviewModel?> SaveItrsinterview(ItrsinterviewModel itrsinterviewModel, Guid interviewerId)
    {
        // Nếu ca, phòng đó đã có người đặt
        if (await ExistITRS(itrsinterviewModel, interviewerId) == true)
        {
            return null!;
        }

        try
        {
            var data = _mapper.Map<Itrsinterview>(itrsinterviewModel);
            var response = await _itrsinterviewRepository.SaveItrsinterview(data, interviewerId);

            if (response != null)
            {
                return _mapper.Map<ItrsinterviewModel>(response);
            }

            return null!;
        }
        catch (Exception)
        {
            return null!;
            throw;
        }
    }

    public async Task<bool> DeleteItrsinterview(Guid itrsinterviewModelId)
    {
        return await _itrsinterviewRepository.DeleteItrsinterview(itrsinterviewModelId);
    }

    public async Task<IEnumerable<ItrsinterviewModel>> GetAllItrsinterview()
    {
        var data = await _itrsinterviewRepository.GetAllItrsinterview();
        if (!data.IsNullOrEmpty())
        {
            List<ItrsinterviewModel> result = _mapper.Map<List<ItrsinterviewModel>>(data);
            return result;
        }
        return null!;
    }

    public async Task<bool> UpdateItrsinterview(ItrsinterviewModel itrsinterviewModel, Guid itrsinterviewId, Guid interviewerId)
    {
        var addData = new ItrsinterviewModel
        {
            DateInterview = itrsinterviewModel.DateInterview,
            RoomId = itrsinterviewModel.RoomId,
            ShiftId = itrsinterviewModel.ShiftId
        };

        if (await ExistITRS(addData, interviewerId)) return false;

        var data = _mapper.Map<Itrsinterview>(itrsinterviewModel);
        return await _itrsinterviewRepository.UpdateItrsinterview(data, itrsinterviewId);
    }

    public async Task<ItrsinterviewModel?> GetItrsinterviewById(Guid id)
    {
        var data = await _itrsinterviewRepository.GetItrsinterviewById(id);
        var result = _mapper.Map<ItrsinterviewModel>(data);
        return result;
    }

    public async Task<bool> ExistITRS(ItrsinterviewModel itrsinterview, Guid interviewerId)
    {
        if (itrsinterview == null)
        {
            return await Task.FromResult(false);
        }

        // check ngày giờ phòng đó có ai đăng ký chưa
        var exists = await _itrsinterviewRepository.GetAllItrsinterview_NoInclude();
        bool alreadyExist_Room = exists.Any(item =>
            (
                (item.DateInterview.Date.Equals(itrsinterview.DateInterview.Date)) &&
                (item.ShiftId.Equals(itrsinterview.ShiftId)) &&
                (item.RoomId.Equals(itrsinterview.RoomId))
            ));
        if (alreadyExist_Room) return await Task.FromResult(true);

        //check interviewer vào ngày giờ đó có itrs không
        var interviewOfInterviewer = await _interviewRepository.GetInterviewOfInterviewer(interviewerId);
        bool alreadyExist_Time = interviewOfInterviewer.Any(item =>
            (
                (item.Itrsinterview!.DateInterview.Date.Equals(itrsinterview.DateInterview.Date)) &&
                (item.Itrsinterview.ShiftId.Equals(itrsinterview.ShiftId))
            ));
        if (alreadyExist_Time) return await Task.FromResult(true);

        return await Task.FromResult(false);
    }
}