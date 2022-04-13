using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Personnel
{
	public class PersonnelCore : IPersonnelCore
	{
		private readonly IBaseEnvironment _casEnvironment;

		public PersonnelCore(IBaseEnvironment casEnvironment)
		{
			_casEnvironment = casEnvironment;
		}

		#region public void Save(Specialist specialist)

		public void Save(Specialist specialist, bool isCaa = false)
		{
			_casEnvironment.NewKeeper.Save(specialist);

			specialist.MedicalRecord.SpecialistId = specialist.ItemId;
			_casEnvironment.NewKeeper.Save(specialist.MedicalRecord);

			foreach (CategoryRecord categoryRecord in specialist.CategoriesRecords)
			{
				categoryRecord.Parent = specialist;
				_casEnvironment.NewKeeper.Save(categoryRecord);
			}

			foreach (var licenseDetail in specialist.LicenseDetails)
			{
				licenseDetail.SpecialistLicenseId = -1;
				licenseDetail.SpecialistId = specialist.ItemId;
				_casEnvironment.NewKeeper.Save(licenseDetail);
			}

			foreach (var licenseRemark in specialist.LicenseRemark)
			{
				licenseRemark.SpecialistLicenseId = -1;
				licenseRemark.SpecialistId = specialist.ItemId;
				_casEnvironment.NewKeeper.Save(licenseRemark);
			}

			foreach (var license in specialist.Licenses)
			{
				_casEnvironment.NewKeeper.Save(license);

				if (license.Document?.ParentId <= 0)
				{
					license.Document.ParentId = license.ItemId;
					_casEnvironment.NewKeeper.Save(license.Document);
				}

				foreach (var specialistCaa in license.CaaLicense)
				{
					specialistCaa.SpecialistLicenseId = license.ItemId;
					_casEnvironment.NewKeeper.Save(specialistCaa);

					if (specialistCaa.Document?.ParentId <= 0)
					{
						specialistCaa.Document.ParentId = specialistCaa.ItemId;
						_casEnvironment.NewKeeper.Save(specialistCaa.Document);
					}
				}

				foreach (var licenseDetail in license.LicenseDetails)
				{
					licenseDetail.SpecialistLicenseId = license.ItemId;
					licenseDetail.SpecialistId = -1;
					_casEnvironment.NewKeeper.Save(licenseDetail);
				}

				foreach (var rating in license.LicenseRatings)
				{
					rating.SpecialistLicenseId = license.ItemId;
					_casEnvironment.NewKeeper.Save(rating);
				}

				foreach (var instrumentRating in license.SpecialistInstrumentRatings)
				{
					instrumentRating.SpecialistLicenseId = license.ItemId;
					_casEnvironment.NewKeeper.Save(instrumentRating);
				}

				foreach (var licenseRemark in license.LicenseRemark)
				{
					licenseRemark.SpecialistLicenseId = license.ItemId;
					licenseRemark.SpecialistId = -1;
					_casEnvironment.NewKeeper.Save(licenseRemark);
				}
			}

			foreach (var traning in specialist.SpecialistTrainings)
			{
				traning.SpecialistId = specialist.ItemId;
				_casEnvironment.NewKeeper.Save(traning);

				if (traning.Document?.ParentId <= 0)
				{
					traning.Document.ParentId = traning.ItemId;
					_casEnvironment.NewKeeper.Save(traning.Document);
				}
			}

			if (specialist.MedicalRecord?.Document?.ParentId <= 0)
			{
				specialist.MedicalRecord.Document.ParentId = specialist.ItemId;
				_casEnvironment.NewKeeper.Save(specialist.MedicalRecord.Document);
			}
		}

		#endregion

		#region public void Delete(Specialization specialization)
		/// <summary>
		/// Удаление specialization
		/// </summary>
		/// <param name="occupation"></param>
		public void Delete(Occupation occupation)
		{
			// Объект остается в базе, т.к. через него могли проходить записи Transfer Record
			occupation.IsDeleted = true;
			_casEnvironment.NewKeeper.Save(occupation);

			var collection = _casEnvironment.GetDictionary<Occupation>();
			if (collection == null) return;
			collection.Remove(occupation);
		}

		#endregion

		#region public void Delete(SpecialistLicense license)

		public void Delete(SpecialistLicense license)
		{
			foreach (var remark in license.LicenseRemark)
				_casEnvironment.NewKeeper.Delete(remark);
			foreach (var caa in license.CaaLicense)
				_casEnvironment.NewKeeper.Delete(caa);
			foreach (var detail in license.LicenseDetails)
				_casEnvironment.NewKeeper.Delete(detail);
			foreach (var rating in license.LicenseRatings)
				_casEnvironment.NewKeeper.Delete(rating);
			foreach (var instrumentRating in license.SpecialistInstrumentRatings)
				_casEnvironment.NewKeeper.Delete(instrumentRating);

			_casEnvironment.NewKeeper.Delete(license);
		}

		#endregion
	}
}