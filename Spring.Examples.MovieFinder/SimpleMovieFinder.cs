using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Examples.MovieFinder
{
    /// <summary>
    /// Simple in-memory storage implementation of the
    /// <see cref="Spring.IocQuickStart.MovieFinder.IMovieFinder"/> interface.
    /// </summary>
    public class SimpleMovieFinder : IMovieFinder
    {
        private ArrayList _list = new ArrayList();

        /// <summary>
        /// Creates a new instance of the
        /// <see cref="Spring.IocQuickStart.MovieFinder.SimpleMovieFinder"/> class.
        /// </summary>
        public SimpleMovieFinder()
        {
            InitList();
        }

        /// <summary>
        /// Add a movie to the list.
        /// </summary>
        /// <param name="m">The movie.</param>
        public void AddMovie(Movie m)
        {
            _list.Add(m);
        }

        /// <summary>
        /// Finds all of the movies stored in this
        /// <see cref="Spring.IocQuickStart.MovieFinder.IMovieFinder"/> implementation.
        /// </summary>
        /// <returns>
        /// All of the movies stored in this
        /// <see cref="Spring.IocQuickStart.MovieFinder.IMovieFinder"/> implementation.
        /// </returns>
        public IList FindAll()
        {
            return new ArrayList(_list);
        }

        /// <summary>
        /// Initialises the in-mememory list of stored movies.
        /// </summary>
        private void InitList()
        {
            _list.Add(new Movie("La vita e bella", "Roberto Benigni"));
        }
    }
}
