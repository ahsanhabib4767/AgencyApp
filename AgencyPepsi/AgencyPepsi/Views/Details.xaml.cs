using AgencyPepsi.Models;
using AgencyPepsi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgencyPepsi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Details : ContentPage
	{
		public Details (Agency agency)
		{
			InitializeComponent ();

            var editIdeaViewModel = new ReportViewModel();
            editIdeaViewModel.Agency = agency;
      
            BindingContext = editIdeaViewModel;
        }

	}
}