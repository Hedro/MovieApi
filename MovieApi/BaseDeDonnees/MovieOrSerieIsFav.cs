using System;

using SQLite.Net.Attributes;

namespace MovieApi
{
	public class MovieOrSerieIsFav
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string MovieOrSerieID { get; set; }

		public override string ToString()
		{
			return string.Format("[SerieOrMovieIsFav : ID={0}, MovieOrSerieID={1}]", ID, MovieOrSerieID);
		}

		public MovieOrSerieIsFav ()
		{

		}
	}
}

