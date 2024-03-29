﻿namespace Entity.Abstractions
{
    public interface IIdentityUser : IBaseEntity
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        UserType UserType { get; set; }
        CAAUserType CAAUserType { get; set; }
        UiType UiType { get; set; }
        int PersonnelId { get; set; }
        int OperatorId { get; set; }
    }
}
