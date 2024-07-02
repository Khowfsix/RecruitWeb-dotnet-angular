namespace Data.Enums
{
    public enum EInterviewCandidateStatus
    {
        NOT_START = 201000,
        FINISHED = 201010,
    }
    public enum EInterviewCompanyStatus
    {
        PENDING = 202000,
        PASSED = 202010,
        PASSED_N_MAILED = 102011,
        FAILED = 202020,
    }
    public enum EInterviewType
    {
        FACE2FACE = 203010,
        ONLINE_GG_MEET = 203020,
    }
}
