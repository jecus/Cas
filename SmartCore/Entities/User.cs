using System;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Entities
{
	[Serializable]
	public class User : BaseEntityObject
	{
		[Filter("Name:")]
		public string Name { get; set; }

		[Filter("Surname:")]
		public string Surname { get; set; }

		[Filter("Login:")]
		public string Login { get; set; }

		[Filter("Password:")]
		public string Password { get; set; }

		[Filter("UserType:")]
		public UserType UserType { get; set; }

		[Filter("UiType:")]
		public UiType UiType { get; set; }

		public int PersonnelId { get; set; }

		[Filter("Personnel:")]
		public Specialist Personnel { get; set; }

		public User(IIdentityUser user)
		{
			ItemId = user.ItemId;
			SmartCoreObjectType = SmartCoreType.User;
			Name = user.Name;
			Surname = user.Surname;
			Login = user.Login;
			Password = user.Password;
			UserType = user.UserType;
			UiType = user.UiType;
			PersonnelId = user.PersonnelId;
		}

		public User()
		{
			Login = "";
			Name = "";
			Password = "";
			Surname = "";
		}

		#region Overrides of BaseEntityObject

		public override string ToString()
		{
			return Name.Equals(Surname) ? Name : $"{Surname} {Name}";
		}

		#endregion
	}


    [Serializable]
    [CAADto(typeof(CAAUserDTO))]
    public class CAAUser : BaseEntityObject
    {
        [Filter("Name:")]
        public string Name { get; set; }

        [Filter("Surname:")]
        public string Surname { get; set; }

        [Filter("Login:")]
        public string Login { get; set; }

        [Filter("Password:")]
        public string Password { get; set; }

        [Filter("UserType:")]
        public CAAUserType UserType { get; set; }

        [Filter("UiType:")]
        public UiType UiType { get; set; }

        public int PersonnelId { get; set; }

        [Filter("Personnel:")]
        public Specialist Personnel { get; set; }

        public CAAUser(IIdentityUser user)
        {
            ItemId = user.ItemId;
            SmartCoreObjectType = SmartCoreType.User;
            Name = user.Name;
            Surname = user.Surname;
            Login = user.Login;
            Password = user.Password;
            UserType = user.CAAUserType;
            UiType = user.UiType;
            PersonnelId = user.PersonnelId;
        }

        public CAAUser()
        {
            Login = "";
            Name = "";
            Password = "";
            Surname = "";
        }

        #region Overrides of BaseEntityObject

        public override string ToString()
        {
            return Name.Equals(Surname) ? Name : $"{Surname} {Name}";
        }

        #endregion
    }
}