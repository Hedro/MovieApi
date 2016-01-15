using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Model
{
	public class DetailsSerieViewModel
	{
		public string Title { get; set; }
		public string OverView { get; set; }
		public string Imdb { get; set; } 
		public long Year { get; set; }
		public long Runtime { get; set; }
		public string Country { get; set; }
		public long Rating { get; set; }
		public string UrlImage { get; set; }
		public string UrlTrailer { get; set; }
		public string Language { get; set; }
		public string[] Gender { get; set; }
		public string AvailableTranslation { get; set; }
		public long Vote { get; set; }
		public string Certification { get; set; }
	}
}