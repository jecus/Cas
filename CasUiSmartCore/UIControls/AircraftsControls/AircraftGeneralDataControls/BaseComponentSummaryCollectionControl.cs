using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
	///<summary>
	///</summary>
	public partial class BaseComponentSummaryCollectionControl : UserControl
	{
		#region Fields

		private Aircraft _currentAircraft;
		private BaseComponentType _componentType;
		
		private readonly List<BaseComponentSummary> _baseComponentSummaryControls = new List<BaseComponentSummary>();

		#endregion

		#region Constructors

		#region public BaseComponentSummaryCollectionControl()
		///<summary>
		///</summary>
		public BaseComponentSummaryCollectionControl()
		{
			InitializeComponent();
		}
		#endregion

		#endregion

		#region Properties


		public int ControlsCount
		{
			get { return _baseComponentSummaryControls.Count; }
		}

		#endregion

		#region Methods

		#region public void UpdateControl(Aircraft aircraft, BaseComponentType componentType)
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
			return  false;
		}

		#endregion

		#region public void SaveData()

		/// <summary>
		/// Сохранаяет данные двигателей текущего ВС
		/// </summary>
		public void SaveData()
		{
		
		}

		#endregion

		#region private void UpdateControl()
		/// <summary>
		/// Обновляет информацию о двигателях текущего ВС
		/// </summary>
		private void UpdateControl()
		{
			var baseComponents =  new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId, _componentType.ItemId));
			flowLayoutPanel1.Controls.Clear();
			_baseComponentSummaryControls.Clear();
			for (int i = 0; i < baseComponents.Count; i++)
			{
				_baseComponentSummaryControls.Add(new BaseComponentSummary { CurrentComponent = baseComponents[i] }); 
			}
			flowLayoutPanel1.Controls.AddRange(_baseComponentSummaryControls.ToArray());
		}

		#endregion

		#endregion
	}
}
