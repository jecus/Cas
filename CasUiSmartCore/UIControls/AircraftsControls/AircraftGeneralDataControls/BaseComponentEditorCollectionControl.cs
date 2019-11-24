using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
	///<summary>
	///</summary>
	public partial class BaseComponentEditorCollectionControl : UserControl
	{
		#region Fields

		private Aircraft _currentAircraft;
		private BaseComponentType _componentType;
		
		private const int MARGIN = 15;
		private readonly List<BaseComponentEditorControl> _baseComponentEditorControls = new List<BaseComponentEditorControl>();

		#endregion

		#region Constructors

		#region public BaseComponentEditorCollectionControl()
		///<summary>
		///</summary>
		public BaseComponentEditorCollectionControl()
		{
			InitializeComponent();
		}
		#endregion

		#endregion

		#region Properties

		#endregion

		#region Methods

		#region public void UpdateControl(Aircraft aircraft, BaseComponentType detailType)
		/// <summary>
		/// Обновляет информацию о ВС и типе отображаемых деталей
		/// </summary>
		public void UpdateControl(Aircraft aircraft, BaseComponentType componentType)
		{
			if (componentType == null)
				throw new ArgumentNullException("componentType", "can not be null");
			if (aircraft == null)
				throw new ArgumentNullException("aircraft", "can not be null");
			if (aircraft.ItemId <= 0)
				throw new ArgumentException("can't get components on not exist aircraft", "aircraft");

			_currentAircraft = aircraft;
			_componentType = componentType;

			UpdateControl();
		}

		#endregion

		#region public bool ValidateData(out string message)
		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		public bool ValidateData(out string message)
		{
			message = "";
			foreach (BaseComponentEditorControl control in _baseComponentEditorControls)
			{
				if (!control.ValidateData(out message))
					return false;
			}
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		/// <summary>
		/// Возвращает значение, показывающее были ли изменения в данном элементе управления
		/// </summary>
		/// <returns></returns>
		public bool GetChangeStatus()
		{
			return _baseComponentEditorControls.Any(t => t.GetChangeStatus());
		}

		#endregion

		#region public void SaveData()

		/// <summary>
		/// Сохранаяет данные двигателей текущего ВС
		/// </summary>
		public void SaveData()
		{
			foreach (BaseComponentEditorControl t in _baseComponentEditorControls)
			{
				t.SaveData();
			}
		}

		#endregion

		#region private void UpdateControl()
		/// <summary>
		/// Обновляет информацию о двигателях текущего ВС
		/// </summary>
		private void UpdateControl()
		{
			var baseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId, _componentType.ItemId));
			Controls.Clear();
			_baseComponentEditorControls.Clear();
			for (int i = 0; i < baseComponents.Count; i++)
			{
				if (i == 0)
				{
					_baseComponentEditorControls.Add(new BaseComponentEditorControl{CurrentBaseComponent = baseComponents[i]}); //todo
					_baseComponentEditorControls[i].Location = new Point(0, 0);
				}
				else
				{
					_baseComponentEditorControls.Add(new BaseComponentEditorControl { CurrentBaseComponent = baseComponents[i] }); //todo
					_baseComponentEditorControls[i].Location = new Point(_baseComponentEditorControls[i - 1].Right + MARGIN, 0);
				}

				_baseComponentEditorControls[i].Deleted += PowerPlantsControlDeleted;
			}
			ButtonAdd.Location = _baseComponentEditorControls.Count > 0
				? new Point(_baseComponentEditorControls[_baseComponentEditorControls.Count - 1].Right + MARGIN, 0)
				: new Point(0, 0);

			Controls.AddRange(_baseComponentEditorControls.ToArray());
			Controls.Add(ButtonAdd);
		}

		#endregion

		#region private void PowerPlantsControlDeleted(object sender, System.EventArgs e)
		private void PowerPlantsControlDeleted(object sender, EventArgs e)
		{
			UpdateControl();
		}
		#endregion

		#region private void ButtonAddClick(object sender, System.EventArgs e)
		private void ButtonAddClick(object sender, EventArgs e)
		{
			Controls.Remove(ButtonAdd);
			var ata = (AtaChapter)GlobalObjects.CasEnvironment.GetDictionary<AtaChapter>().GetByFullName(_componentType.FullName);
			var newComponentControl =
				new BaseComponentEditorControl(new BaseComponent {BaseComponentType = _componentType, ATAChapter = ata}, _currentAircraft)
				{
					Location = _baseComponentEditorControls.Count != 0
						? new Point(_baseComponentEditorControls.Last().Right + MARGIN, 0)
						: new Point(0, 0)
				};
			_baseComponentEditorControls.Add(newComponentControl);
			ButtonAdd.Location = new Point(_baseComponentEditorControls.Last().Right + MARGIN, 0);
			Controls.Add(newComponentControl);
			Controls.Add(ButtonAdd);
		}
		#endregion

		#endregion
	}
}
