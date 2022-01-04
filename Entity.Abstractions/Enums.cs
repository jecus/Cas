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
        Minor
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
        CAAAdmin,
        CAA,
        OperatorAdmin,
        Operator
    }

    public enum UiType
    {
        All
    }
}
