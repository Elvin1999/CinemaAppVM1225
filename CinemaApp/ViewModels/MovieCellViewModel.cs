﻿using CinemaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class MovieCellViewModel:BaseViewModel
    {
		private Movie movie;

		public Movie Movie
		{
			get { return movie; }
			set { movie = value; 
				movie.Description=movie.Description.Substring(0,20);
				if (movie.Name.Length >= 25)
				{
					movie.Name=movie.Name.Substring(0,25);
				}
				OnPropertyChanged(); }
		}

		public WrapPanel StarsPanel { get; set; }

		public MovieCellViewModel()
		{

		}

	}
}
