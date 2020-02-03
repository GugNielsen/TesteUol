using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm; using Prism.Navigation; using Prism.Services;
using System;
using System.Collections.Generic; using System.Threading.Tasks;
using TesteUol.Entities;

namespace TesteUol.ViewModels {
	public abstract class ViewModelBase : BindableBase, IDestructible, INavigationAware, IConfirmNavigation, IApplicationLifecycleAware, IPageLifecycleAware
	{

		protected INavigationService _navigationService;

		protected IPageDialogService _pageDialogService;
		protected bool _workOffLine = false;

        //private Tempo _timeZone;
        //public Tempo Timezone
        //{
        //    get { return _timeZone; }
        //    set { SetProperty(ref _timeZone, value); }
        //}


        /// <param name="navigationService">Navigation service.</param>
        public ViewModelBase(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}


        protected Task _taskInit { get; set; }


        bool _isPtBr;
		/// <summary>
		/// Gets a value indicating whether this <see cref="T:DNAModelApp.ViewModels.ViewModelBase"/> culture is pt-BR.
		/// </summary>
		/// <value><c>true</c> if culture is point br; otherwise, <c>false</c>.</value>
	

		string _pageTitle;
		public virtual string PageTitle
		{
			get => _pageTitle;
			set => SetProperty(ref _pageTitle, value);
		}

		private string _subTitle;
		public string SubTitle
		{
			get { return _subTitle; }
			set { SetProperty(ref _subTitle, value); }
		}

		private bool _canLoadMore;
		public bool CanLoadMore
		{
			get { return _canLoadMore; }
			set { SetProperty(ref _canLoadMore, value); }
		}

		private string _headerText;
		public string HeaderText
		{
			get { return _headerText; }
			set { SetProperty(ref _headerText, value); }
		}

		private string _footerText;
		public string FooterText
		{
			get { return _footerText; }
			set { SetProperty(ref _footerText, value); }
		}

		private bool _isBusy = false;

		public virtual bool IsBusy
		{
			get => _isBusy;
			set { SetProperty(ref _isBusy, value); }
		}


		public string Icon { get; set; }

	
		

	

		#region INavigationAware 
		/// <summary>
		///OnNavigatingTo intercept before the View is navigated to  - OnNavigatingTo is not called when using device hardware or software back button.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		public virtual void OnNavigatingTo(INavigationParameters parameters) { }

		/// <summary>
		/// once it is navigated to - raises when you come from the other page to this page
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		public virtual void OnNavigatedTo(INavigationParameters parameters)
		{
			//get a single parameter as type object, which must be cast
			// var invite = parameters["inviteParam"] as Invite;

			//get a single typed parameter
			//var invite = parameters.GetValue<Invite>("inviteParam");
			//Item = invite;
			//get a collection of typed parameters
			// var invites = parameters.GetValues<Invite>("colors");
		}

		/// <summary>
		///  Raise when you navigated from this page to the other page
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

		#endregion INavigationAware

		#region IDestructible 
		public virtual void Destroy() { }

		#endregion IDestructible

		#region IConfirmNavigation 
		public virtual bool CanNavigate(INavigationParameters parameters) => true;

		public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters) =>
			Task.FromResult(CanNavigate(parameters));

		#endregion IConfirmNavigation 
		#region IApplicationLifecycleAware 
		public virtual void OnResume() { }

		public virtual void OnSleep() { }

		#endregion IApplicationLifecycleAware

		#region IPageLifecycleAware 
		public virtual void OnAppearing() { }

		public virtual void OnDisappearing() { }

		#endregion IPageLifecycleAware

	}  } 