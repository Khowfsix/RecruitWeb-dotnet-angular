namespace Api.ViewModels.Level
{
    public class LevelUpdateModel
    {
        public string LevelName { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}