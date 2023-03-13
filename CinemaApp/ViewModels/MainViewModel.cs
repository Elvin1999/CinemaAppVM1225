using CinemaApp.Commands;
using CinemaApp.Services;
using CinemaApp.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaApp.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
		private string searchText;

		public string SearchText
		{
			get { return searchText; }
			set { searchText = value; OnPropertyChanged(); }
		}

		public RelayCommand SearchCommand { get; set; }

		public WrapPanel MyPanel { get; set; }

		public MainViewModel()
		{
			SearchCommand = new RelayCommand((obj) =>
			{
				MyPanel.Children.Clear();
                var movies=MovieService.GetMovies(SearchText);
				int x = 10;
				int y = 10;
				foreach (var m in movies)
				{
					var ucVM = new MovieCellViewModel
					{
						Movie = m
					};
					var uc = new MovieCellUC(ucVM);

					var d=double.Parse(m.Rating.Replace('.',',')).ToString();

					double result = (double.Parse(d)+1)/2;
					int count=(int)result;

					for (int i = 0; i < count; i++)
					{
						ucVM.StarsPanel.Children.Add(new StarUC());
					}

					uc.Margin = new System.Windows.Thickness(x, y, 0, 0);
					MyPanel.Children.Add(uc);

				}
			});
		}

	}
}
