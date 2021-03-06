﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using System.Linq;
using Gamma.Utilities;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using QS.HistoryLog;
using QS.Utilities.Text;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.WageCalculation;
using Vodovoz.EntityRepositories.WageCalculation;
using Vodovoz.Services;
using QS.Services;
using QS.Dialog;
using QS.EntityRepositories;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories;
using System.Text.RegularExpressions;
using QS.Project.Services;

namespace Vodovoz.Domain.Employees
{
	[Appellative(Gender = GrammaticalGender.Masculine,
		NominativePlural = "сотрудники",
		Nominative = "сотрудник")]
	[EntityPermission]
	[HistoryTrace]
	public class Employee : Personnel, IEmployee
	{
		#region Свойства

		public override EmployeeType EmployeeType {
			get { return EmployeeType.Employee; }
			set { }
		}

		EmployeeCategory category;

		[Display(Name = "Категория")]
		public virtual EmployeeCategory Category {
			get => category;
			set => SetField(ref category, value);
		}

		RegistrationType? registration;

		[Display(Name = "Оформление")]
		public virtual RegistrationType? Registration {
			get { return registration; }
			set { SetField(ref registration, value, () => Registration); }
		}

		string androidLogin;

		[Display(Name = "Логин для Android приложения")]
		public virtual string AndroidLogin {
			get { return androidLogin; }
			set { SetField(ref androidLogin, value, () => AndroidLogin); }
		}

		string androidPassword;

		[Display(Name = "Пароль для Android приложения")]
		public virtual string AndroidPassword {
			get { return androidPassword; }
			set { SetField(ref androidPassword, value, () => AndroidPassword); }
		}

		string androidSessionKey;

		[Display(Name = "Ключ сессии для Android приложения")]
		public virtual string AndroidSessionKey {
			get { return androidSessionKey; }
			set { SetField(ref androidSessionKey, value, () => AndroidSessionKey); }
		}

		string androidToken;

		[Display(Name = "Токен Android приложения пользователя для отправки Push-сообщений")]
		public virtual string AndroidToken {
			get { return androidToken; }
			set { SetField(ref androidToken, value, () => AndroidToken); }
		}

		bool isFired;

		[Display(Name = "Сотрудник уволен")]
		public virtual bool IsFired {
			get { return isFired; }
			set { SetField(ref isFired, value, () => IsFired); }
		}

		User user;

		[Display(Name = "Пользователь")]
		public virtual User User {
			get { return user; }
			set { SetField(ref user, value, () => User); }
		}

		private Subdivision subdivision;

		[Display(Name = "Подразделение")]
		public virtual Subdivision Subdivision {
			get { return subdivision; }
			set { SetField(ref subdivision, value, () => Subdivision); }
		}

		private DateTime? firstWorkDay;

		[Display(Name = "Первый день работы")]
		public virtual DateTime? FirstWorkDay {
			get { return firstWorkDay; }
			set { SetField(ref firstWorkDay, value, () => FirstWorkDay); }
		}

		IList<EmployeeContract> contracts = new List<EmployeeContract>();

		[Display(Name = "Договора")]
		public virtual IList<EmployeeContract> Contracts {
			get { return contracts; }
			set { SetField(ref contracts, value, () => Contracts); }
		}

		GenericObservableList<EmployeeContract> observableContracts;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<EmployeeContract> ObservableContracts {
			get {
				if(observableContracts == null) {
					observableContracts = new GenericObservableList<EmployeeContract>(Contracts);
				}
				return observableContracts;
			}
		}

		private DeliveryDaySchedule defaultDaySheldule;

		[Display(Name = "График работы по молчанию")]
		public virtual DeliveryDaySchedule DefaultDaySheldule {
			get { return defaultDaySheldule; }
			set { SetField(ref defaultDaySheldule, value, () => DefaultDaySheldule); }
		}

		private Employee defaultForwarder;

		[Display(Name = "Экспедитор по умолчанию")]
		public virtual Employee DefaultForwarder {
			get { return defaultForwarder; }
			set { SetField(ref defaultForwarder, value, () => DefaultForwarder); }
		}

		private bool largusDriver;
		[Display(Name = "Сотрудник - водитель Ларгуса")]
		public virtual bool LargusDriver {
			get { return largusDriver; }
			set { SetField(ref largusDriver, value, () => LargusDriver); }
		}

		private CarTypeOfUse? driverOf;
		[Display(Name = "Водитель автомобиля типа")]
		public virtual CarTypeOfUse? DriverOf {
			get { return driverOf; }
			set { SetField(ref driverOf, value, () => DriverOf); }
		}

		private float driverSpeed = 1;

		[Display(Name = "Скорость работы водителя")]
		public virtual float DriverSpeed {
			get { return driverSpeed; }
			set { SetField(ref driverSpeed, value, () => DriverSpeed); }
		}

		private short tripPriority = 6;

		/// <summary>
		/// Приорите(1-10) чем меньше тем лучше. Фактически это штраф.
		/// </summary>
		[Display(Name = "Приоритет для маршрутов")]
		public virtual short TripPriority {
			get { return tripPriority; }
			set { SetField(ref tripPriority, value, () => TripPriority); }
		}

		private IList<DriverDistrictPriority> districts = new List<DriverDistrictPriority>();

		[Display(Name = "Районы")]
		public virtual IList<DriverDistrictPriority> Districts {
			get { return districts; }
			set { SetField(ref districts, value, () => Districts); }
		}

		GenericObservableList<DriverDistrictPriority> observableDistricts;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<DriverDistrictPriority> ObservableDistricts {
			get {
				if(observableDistricts == null) {
					observableDistricts = new GenericObservableList<DriverDistrictPriority>(districts);
					observableDistricts.ElementAdded += ObservableDistricts_ElementAdded;
					observableDistricts.ElementRemoved += ObservableDistricts_ElementRemoved;
				}
				return observableDistricts;
			}
		}

		IList<WageParameter> wageParameters = new List<WageParameter>();
		[Display(Name = "Параметры расчета зарплаты")]
		public virtual IList<WageParameter> WageParameters {
			get => wageParameters;
			set => SetField(ref wageParameters, value, () => WageParameters);
		}

		GenericObservableList<WageParameter> observableWageParameters;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<WageParameter> ObservableWageParameters {
			get {
				if(observableWageParameters == null)
					observableWageParameters = new GenericObservableList<WageParameter>(WageParameters);
				return observableWageParameters;
			}
		}

		bool visitingMaster;
		public virtual bool VisitingMaster {
			get => visitingMaster;
			set => SetField(ref visitingMaster, value);
		}

		bool isDriverForOneDay;
		public virtual bool IsDriverForOneDay {
			get => isDriverForOneDay;
			set => SetField(ref isDriverForOneDay, value);
		}

		private string loginForNewUser;
		[Display(Name = "Логин нового пользователя")]
		public virtual string LoginForNewUser {
			get { return loginForNewUser; }
			set { SetField(ref loginForNewUser, value, () => LoginForNewUser); }
		}

		#endregion

		public Employee()
		{
			Name = String.Empty;
			LastName = String.Empty;
			Patronymic = String.Empty;
			DrivingNumber = String.Empty;
			Category = EmployeeCategory.office;
			AddressRegistration = String.Empty;
			AddressCurrent = String.Empty;
		}

		public virtual IDictionary<object, object> GetValidationContextItems(ISubdivisionService subdivisionService)
		{
			if(subdivisionService == null) {
				throw new ArgumentNullException(nameof(subdivisionService));
			}

			return new Dictionary<object, object> {
				{"Reason", subdivisionService} };
		}

		#region IValidatableObject implementation

		public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			foreach(var item in base.Validate(validationContext)) {
				yield return item;
			}

			if(!string.IsNullOrEmpty(AndroidLogin)) {
				Employee exist = EmployeeSingletonRepository.GetInstance().GetDriverByAndroidLogin(UoW, AndroidLogin);
				if(exist != null && exist.Id != Id)
					yield return new ValidationResult(string.Format("Другой водитель с логином {0} для Android уже есть в БД.", AndroidLogin),
						new[] { this.GetPropertyName(x => x.AndroidLogin) });
			}
			if(!String.IsNullOrEmpty(LoginForNewUser) && User != null) {
				yield return new ValidationResult($"Сотрудник уже привязан к пользователю",
					new[] { this.GetPropertyName(x => x.LoginForNewUser) });
			}
			var regex = new Regex(@"^[a-zA-Z0-9].{3,25}$");
			if(!String.IsNullOrEmpty(LoginForNewUser) && !regex.IsMatch(LoginForNewUser)) {
				yield return new ValidationResult($"Логин пользователя должен иметь длину от 3 до 25 символов и состоять из латинских букв и цифр",
					new[] { this.GetPropertyName(x => x.LoginForNewUser) });
			}
			if(!String.IsNullOrEmpty(LoginForNewUser)) {
				User exist = UserSingletonRepository.GetInstance().GetUserByLogin(UoW, LoginForNewUser);
				if(exist != null && exist.Id != Id)
					yield return new ValidationResult($"Пользователь с логином {LoginForNewUser} уже существует в базе",
						new[] { this.GetPropertyName(x => x.LoginForNewUser) });
			}
			if(!String.IsNullOrEmpty(LoginForNewUser) && UserSingletonRepository.GetInstance().MySQLUserWithLoginExists(UoW, LoginForNewUser)) {
					yield return new ValidationResult($"Пользователь с логином {LoginForNewUser} уже существует на сервере",
						new[] { this.GetPropertyName(x => x.LoginForNewUser) });
			}
			if(!String.IsNullOrEmpty(LoginForNewUser) && !ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_manage_users")) {
			yield return new ValidationResult($"Недостаточно прав для создания нового пользователя",
					new[] { this.GetPropertyName(x => x.LoginForNewUser) });
			}
			if(!String.IsNullOrEmpty(LoginForNewUser)) {
				string exist = GetPhoneForSmsNotification();
				if(exist == null)
					yield return new ValidationResult($"Для создания пользователя должен быть правильно указан мобильный телефон",
							new[] { this.GetPropertyName(x => x.LoginForNewUser) });
			}
			if(Category == EmployeeCategory.driver && DriverOf == null) {
				yield return new ValidationResult($"Обязательно должно быть выбрано поле 'Управляет а\\м'",
					new[] { this.GetPropertyName(x => x.DriverOf) });
			}

			if(validationContext.Items.ContainsKey("Reason") && validationContext.Items["Reason"] is ISubdivisionService subdivisionService) {

				if(Subdivision == null || Subdivision.Id == subdivisionService.GetParentVodovozSubdivisionId()) {
					yield return new ValidationResult($"Поле подразделение должно быть заполнено и не должно являться" +
						" общим подразделением 'Веселый Водовоз'");
				}
			} else {
				throw new ArgumentException("Неверно передан ValidationContext");
			}
		}

		#endregion

		#region Функции

		public virtual IWageCalculationRepository WageCalculationRepository { get; set; } = WageSingletonRepository.GetInstance();

		public virtual string GetPersonNameWithInitials() => PersonHelper.PersonNameWithInitials(LastName, Name, Patronymic);

		public virtual void CheckAndFixDriverPriorities() => CheckDistrictsPriorities();

		void CheckDistrictsPriorities()
		{
			for(int i = 0; i < Districts.Count; i++) {
				if(Districts[i] == null) {
					Districts.RemoveAt(i);
					i--;
					continue;
				}

				if(Districts[i].Priority != i)
					Districts[i].Priority = i;
			}
		}

		public virtual double TimeCorrection(long timeValue) => (double)timeValue / DriverSpeed;

		public virtual bool CheckStartDateForNewWageParameter(DateTime newStartDate)
		{
			WageParameter oldWageParameter = ObservableWageParameters.FirstOrDefault(x => x.EndDate == null);
			if(oldWageParameter == null) {
				return true;
			}

			return oldWageParameter.StartDate < newStartDate;
		}

		public virtual void ChangeWageParameter(WageParameter wageParameter, DateTime startDate)
		{
			if(wageParameter == null) {
				throw new ArgumentNullException(nameof(wageParameter));
			}

			wageParameter.Employee = this;
			wageParameter.StartDate = startDate.AddTicks(1);
			WageParameter oldWageParameter = ObservableWageParameters.FirstOrDefault(x => x.EndDate == null);
			if(oldWageParameter != null) {
				if(oldWageParameter.StartDate > startDate) {
					throw new InvalidOperationException("Нельзя создать новую запись с датой более ранней уже существующей записи. Неверно выбрана дата");
				}
				oldWageParameter.EndDate = startDate;
			}
			ObservableWageParameters.Add(wageParameter);
			return;
		}

		public virtual WageParameter GetActualWageParameter(DateTime date)
		{
			return WageParameters.Where(x => x.StartDate <= date)
								 .OrderByDescending(x => x.StartDate)
								 .Take(1)
								 .SingleOrDefault();
		}

		public virtual void CreateDefaultWageParameter(IWageCalculationRepository wageRepository, IWageParametersProvider wageParametersProvider, IInteractiveService interactiveService)
		{
			if(wageRepository == null) {
				throw new ArgumentNullException(nameof(wageRepository));
			}
			if(wageParametersProvider == null) {
				throw new ArgumentNullException(nameof(wageParametersProvider));
			}
			if(interactiveService == null) {
				throw new ArgumentNullException(nameof(interactiveService));
			}

			var defaultLevel = wageRepository.DefaultLevelForNewEmployees(UoW);
			if(defaultLevel == null) {
				interactiveService.ShowMessage(ImportanceLevel.Warning, "\"В журнале ставок по уровням не отмечен \"Уровень по умолчанию для новых сотрудников\"!\"", "Невозможно создать расчет зарплаты");
				return;
			}

			if(Id != 0) {
				return;
			}

			ObservableWageParameters.Clear();
			switch(Category) {
				case EmployeeCategory.driver:
					WageParameter parameterForDriver = new ManualWageParameter { WageParameterTarget = WageParameterTargets.ForMercenariesCars };
					if(VisitingMaster && !IsDriverForOneDay)
						parameterForDriver = new PercentWageParameter {
							PercentWageType = PercentWageTypes.Service,
							WageParameterTarget = WageParameterTargets.ForMercenariesCars
						};
					else if(DriverOf == CarTypeOfUse.CompanyLargus)
						parameterForDriver = new FixedWageParameter {
							FixedWageType = FixedWageTypes.RouteList,
							RouteListFixedWage = wageParametersProvider.GetFixedWageForNewLargusDrivers(),
							WageParameterTarget = WageParameterTargets.ForMercenariesCars,
							IsStartedWageParameter = true
						};
					else if(!IsDriverForOneDay)
						parameterForDriver = new RatesLevelWageParameter {
							WageDistrictLevelRates = defaultLevel,
							WageParameterTarget = WageParameterTargets.ForMercenariesCars
						};
					ChangeWageParameter(parameterForDriver, DateTime.Today);
					break;
				case EmployeeCategory.forwarder:
					var parameterForForwarder = new RatesLevelWageParameter {
						WageDistrictLevelRates = wageRepository.DefaultLevelForNewEmployees(UoW),
						WageParameterTarget = WageParameterTargets.ForMercenariesCars
					};
					ChangeWageParameter(parameterForForwarder, DateTime.Today);
					break;
				case EmployeeCategory.office:
				default:
					ChangeWageParameter(new ManualWageParameter { WageParameterTarget = WageParameterTargets.ForMercenariesCars }, DateTime.Today);
					break;

			}
			return;
		}

		public virtual string GetPhoneForSmsNotification()
		{
			string stringPhoneNumber = Phones.FirstOrDefault(p => p?.DigitsNumber != null && p.DigitsNumber.Count() == 10)?.DigitsNumber.TrimStart('+').TrimStart('7').TrimStart('8');
			if(String.IsNullOrWhiteSpace(stringPhoneNumber)
				|| stringPhoneNumber.Length == 0
				|| stringPhoneNumber.First() != '9'
				|| stringPhoneNumber.Length != 10)
				return null;

			return stringPhoneNumber;
		}

		#endregion

		void ObservableDistricts_ElementAdded(object aList, int[] aIdx)
		{
			CheckDistrictsPriorities();
		}

		void ObservableDistricts_ElementRemoved(object aList, int[] aIdx, object aObject)
		{
			CheckDistrictsPriorities();
		}
	}

	public enum EmployeeCategory
	{
		[Display(Name = "Офисный работник")]
		office,
		[Display(Name = "Водитель")]
		driver,
		[Display(Name = "Экспедитор")]
		forwarder
	}

	public enum RegistrationType
	{
		[Display(Name = "ТК РФ")]
		LaborCode,
		[Display(Name = "ГПК")]
		Contract,
	}

	public enum EmployeeType
	{
		[Display(Name = "Сотрудник")]
		Employee,
		[Display(Name = "Стажер")]
		Trainee
	}

	public class EmployeeCategoryStringType : NHibernate.Type.EnumStringType
	{
		public EmployeeCategoryStringType() : base(typeof(EmployeeCategory))
		{
		}
	}

	public class RegistrationTypeStringType : NHibernate.Type.EnumStringType
	{
		public RegistrationTypeStringType() : base(typeof(RegistrationType))
		{
		}
	}

	public class EmployeeTypeStringType : NHibernate.Type.EnumStringType
	{
		public EmployeeTypeStringType() : base(typeof(EmployeeType))
		{
		}
	}
}