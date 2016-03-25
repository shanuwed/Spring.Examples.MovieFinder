using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Examples.MovieFinder
{
    public interface IMovieFinder
    {
        IList FindAll();
    }
}
