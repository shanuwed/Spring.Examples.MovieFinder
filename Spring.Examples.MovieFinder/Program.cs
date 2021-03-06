﻿using System;
// The Spring.Context namespace gives the application access to 
// the IApplicationContext class that will serve as the primary
// means for the application to access the IoC container.
using Spring.Context;
using Spring.Context.Support; // required by ContextRegistry

/*
 * Example from: http://www.springframework.net/doc-latest/reference/html/quickstarts.html
 * and https://github.com/spring-projects/spring-net/tree/master/examples/Spring/Spring.IoCQuickStart.MovieFinder
 * What we want to do is get a reference to an instance of the MovieLister class... 
 * since this is a Spring.NET example we'll get this reference from 
 * Spring.NET's IoC container, the IApplicationContext. 
 * There are a number of ways to get a reference to an IApplicationContext instance, 
 * but for this example we'll be using an IApplicationContext that is 
 * instantiated from a custom configuration section in a standard .NET 
 * application config file...
 */
namespace Spring.Examples.MovieFinder
{
    class Program
    {

        static void Main(string[] args)
        {
            // Retrieve a fully configured IApplicationContext implementation 
            // that has been configured using the named <objects/> section from 
            // the application config file
            IApplicationContext ctx = ContextRegistry.GetContext();

            //the full, assembly-qualified name of the MovieLister class 
            //has been specified in the type attribute of the object definition in app.config, 
            //and that the definition has been assigned the (unique) id of MyMovieLister. 
            //Using this id, an instance of the object so defined can be retrieved from 
            //the IApplicationContext reference like so...
            MovieLister lister = (MovieLister)ctx.GetObject("MyMovieLister");

            /*
             * When the MyMovieLister object is retrieved from (i.e. instantiated by) 
             * the IApplicationContext in the application, the Spring.NET IoC container 
             * will inject the reference to the MyMovieFinder object into the MovieFinder 
             * property of the MyMovieLister object. The MovieLister object that is 
             * referenced in the application is then fully configured and ready 
             * to be used in the application to do what is does best... list movies by director.
             * */
            Movie[] movies = lister.MoviesDirectedBy("Robert Benigni");
            Console.WriteLine("\nSearching for movie...\n");
            foreach (Movie m in movies)
            {
                Console.WriteLine(
                    string.Format("Movie Title = '{0}', Directory = '{1}'",
                    m.Title, m.Director));
            }
            Console.WriteLine("\nMovieApp done.");
        }
    }



}
