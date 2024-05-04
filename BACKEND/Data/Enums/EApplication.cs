namespace Data.Enums
{
    public enum EApplicationCandidateStatus
    {
        PENDING = 101000,
        PASSED = 101010,
    }
    public enum EApplicationCompanyStatus
    {
        PENDING = 102000,
        NEED_SCHEDULE = 102010,
        SCHEDULED = 102011,
        CAND_ACCEPTED = 102012,
        CAND_REJECTED = 102013,
        CONFIRM_N_MAILED = 102014,
        REJECTED = 102020,
    }
}
