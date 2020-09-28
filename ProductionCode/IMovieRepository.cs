using System;
using System.Collections.Generic;

namespace ProductionCode
{
    public interface IMovieRepository
    {
        IEnumerable<BERating> GetAll();
    }
}
