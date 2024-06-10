namespace Api.ViewModels.Level
{
    public class LevelUpdateModel
    {
        public Guid LevelId { get; set; }
        public string LevelName { get; set; }
        public bool IsDeleted { get; set; }
    }
}