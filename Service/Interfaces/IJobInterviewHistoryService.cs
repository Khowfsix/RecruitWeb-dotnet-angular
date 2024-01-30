using Service.Models;

namespace Service.Interfaces
{
    public interface IJobInterviewHistoryService
    {
        Task<PositionModel> GetPosition(Guid id);

        //Task<List<ApplicationHistoryViewModel>> GetApplicationHistory(Guid candidateId);
        Task<List<ApplicationModel>> GetApplicationHistory(Guid candidateId);

        Task<InterviewerModel> GetInterviewerInformation(Guid id);
        //Task<bool> GetRoomInformation();
        Task<CvModel> GetCV(Guid id);
        Task<RoomModel> GetRoomInformation(Guid id);
    }
}