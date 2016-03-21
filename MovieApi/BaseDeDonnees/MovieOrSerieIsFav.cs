using System;

using SQLite.Net.Attributes;

namespace MovieApi
{
	public class MovieOrSerieIsFav
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string MovieOrSerieID { get; set; }

		public string MovieOrSerieName { get; set; }

		public string MovieOrSerieImageUrl { get; set; }

		public string MovieOrSerieType { get; set; }

		public override string ToString()
		{
			return string.Format("[SerieOrMovieIsFav : ID={0}, MovieOrSerieID={1}, MovieOrSerieName={2}, MovieOrSerieImageUrl={3}, MovieOrSerieType={4}", ID, MovieOrSerieID, MovieOrSerieName, MovieOrSerieImageUrl, MovieOrSerieType);
		}

		public MovieOrSerieIsFav ()
		{

		}
	}
}

