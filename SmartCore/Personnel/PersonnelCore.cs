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
			_casEnvironment.NewKeeper.Save(specialist, isCaa:isCaa);

			specialist.MedicalRecord.SpecialistId = specialist.ItemId;
			_casEnvironment.NewKeeper.Save(specialist.MedicalRecord, isCaa:isCaa);

			foreach (CategoryRecord categoryRecord in specialist.CategoriesRecords)
			{
				categoryRecord.Parent = specialist;
				_casEnvironment.NewKeeper.Save(categoryRecord, isCaa:isCaa);
			}

			foreach (var licenseDetail in specialist.LicenseDetails)
			{
				licenseDetail.SpecialistLicenseId = -1;
				licenseDetail.SpecialistId = specialist.ItemId;
				_casEnvironment.NewKeeper.Save(licenseDetail, isCaa:isCaa);
			}

			foreach (var licenseRemark in specialist.LicenseRemark)
			{
				licenseRemark.SpecialistLicenseId = -1;
				licenseRemark.SpecialistId = specialist.ItemId;
				_casEnvironment.NewKeeper.Save(licenseRemark, isCaa:isCaa);
			}

			foreach (var license in specialist.Licenses)
			{
				_casEnvironment.NewKeeper.Save(license, isCaa:isCaa);

				if (license.Document?.ParentId <= 0)
				{
					license.Document.ParentId = license.ItemId;
					_casEnvironment.NewKeeper.Save(license.Document, isCaa:isCaa);
				}

				foreach (var specialistCaa in license.CaaLicense)
				{
					specialistCaa.SpecialistLicenseId = license.ItemId;
					_casEnvironment.NewKeeper.Save(specialistCaa, isCaa:isCaa);

					if (specialistCaa.Document?.ParentId <= 0)
					{
						specialistCaa.Document.ParentId = specialistCaa.ItemId;
						_casEnvironment.NewKeeper.Save(specialistCaa.Document, isCaa:isCaa);
					}
				}

				foreach (var licenseDetail in license.LicenseDetails)
				{
					licenseDetail.SpecialistLicenseId = license.ItemId;
					licenseDetail.SpecialistId = -1;
					_casEnvironment.NewKeeper.Save(licenseDetail, isCaa:isCaa);
				}

				foreach (var rating in license.LicenseRatings)
				{
					rating.SpecialistLicenseId = license.ItemId;
					_casEnvironment.NewKeeper.Save(rating, isCaa:isCaa);
				}

				foreach (var instrumentRating in license.SpecialistInstrumentRatings)
				{
					instrumentRating.SpecialistLicenseId = license.ItemId;
					_casEnvironment.NewKeeper.Save(instrumentRating, isCaa:isCaa);
				}

				foreach (var licenseRemark in license.LicenseRemark)
				{
					licenseRemark.SpecialistLicenseId = license.ItemId;
					licenseRemark.SpecialistId = -1;
					_casEnvironment.NewKeeper.Save(licenseRemark, isCaa:isCaa);
				}
			}

			foreach (var traning in specialist.SpecialistTrainings)
			{
				traning.SpecialistId = specialist.ItemId;
				_casEnvironment.NewKeeper.Save(traning);

				if (traning.Document?.ParentId <= 0)
				{
					traning.Document.ParentId = traning.ItemId;
					_casEnvironment.NewKeeper.Save(traning.Document, isCaa:isCaa);
				}
			}

			if (specialist.MedicalRecord?.Document?.ParentId <= 0)
			{
				specialist.MedicalRecord.Document.ParentId = specialist.ItemId;
				_casEnvironment.NewKeeper.Save(specialist.MedicalRecord.Document, isCaa:isCaa);
			}
		}

		#endregion

		#region public void Delete(Specialization specialization)
		/// <summary>
		/// Удаление specialization
		/// </summary>
		/// <param name="specialization"></param>
		public void Delete(Specialization specialization)
		{
			// Объект остается в базе, т.к. через него могли проходить записи Transfer Record
			specialization.IsDeleted = true;
			_casEnvironment.NewKeeper.Save(specialization);

			var collection = _casEnvironment.GetDictionary<Specialization>();
			if (collection == null) return;
			collection.Remove(specialization);
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