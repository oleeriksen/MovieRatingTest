using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ProductionCode
{
    public class MovieRepositoryFileReader : IMovieRepository
    {
        private readonly string _path = "ratings.json";

        public MovieRepositoryFileReader()
        {
            GetReviewsFromFile(_path);
        }

        private IEnumerable<BERating> _ratingCollection;

        public IEnumerable<BERating> GetAll()
        {
            return _ratingCollection;
        }

        public void GetReviewsFromFile(string _path)
        {
            using (StreamReader streamReader = File.OpenText(_path))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.CloseInput = true;
                var serializer = new JsonSerializer();
                var ratings = new List<BERating>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        BERating review = serializer.Deserialize<BERating>(reader);
                        ratings.Add(review);
                    }

                }
                _ratingCollection = ratings;
            }
        }
    }
}
