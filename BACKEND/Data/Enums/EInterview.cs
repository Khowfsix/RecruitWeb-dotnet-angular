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
        FINISHED = 202010,
        PASSED = 202020,
        PASSED_N_MAILED = 202021,
        FAILED = 202030,
    }
    public enum EInterviewType
    {
        FACE2FACE = 203010,
        ONLINE_GG_MEET = 203020,
    }
}
