namespace Entity.Abstractions
{
    public enum LevelColor
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        White,
        Unknown
    }
    public enum LevelClass
    {
        Major,
        Minor,
        Significant
    }

    public enum UserType
    {
        Admin,
        SuperUser,
        ReadOnly,
        SaveOnly
    }

    public enum CAAUserType
    {
        CAAAdmin = 0,
        CAA = 1,
        OperatorAdmin = 10,
        Operator = 11
    }

    public enum UiType
    {
        All
    }
}
