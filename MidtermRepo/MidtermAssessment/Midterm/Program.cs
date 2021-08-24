using System;
using System.Collections.Generic;
using System.Linq;

namespace Midterm
{
    public class Admin : User
    {
        //protected List<Movies> movies;
        //protected string name;

        public Admin(List<Movie> movies, string name) : base(movies, name)
        {
            this.movies = movies;
            this.name = name;
        }

        public List<Movie> AddMovie()
        {
            Console.Write("Movie Title: ");
            string title = Console.ReadLine();
            Console.Write("Starring: ");
            string actor = Console.ReadLine();
            Console.Write("Director: ");
            string director = Console.ReadLine();
            Console.Write("Genre: ");
            string genre = Console.ReadLine();
            Movie movie = new Movie(title, actor, director, genre);
            Console.WriteLine($"Attempting to add \n{movie}");

            foreach (var m in movies)
            {
                if (movie.Title == m.Title)
                {
                    Console.WriteLine("Add Failed");
                    Console.WriteLine("Duplicate Found...");
                    break;
                }
                else
                {
                    movies.Add(movie);
                    Console.WriteLine("Success!");
                    break;
                }
            }
            return movies;
        }

        public List<Movie> AddMovie(string title, string actor, string director, string genre)
        {
            Movie movie = new Movie(title, actor, director, genre);
            Console.WriteLine($"Attempting to add \n{movie}");

            foreach (var m in movies)
            {
                if (movie.Title == m.Title)
                {
                    Console.WriteLine("Duplicate Found...");
                    break;
                }
                else
                {
                    movies.Add(movie);
                    Console.WriteLine("Success!");
                    break;
                }
            }
            return movies;
        }

        public List<Movie> DeleteMovie()
        {
            Console.Write("Enter the movie's title: ");
            string title = Console.ReadLine();
            int counter = 0;
            foreach (var m in movies)
            {
                if (title == m.Title)
                {
                    counter++;
                    movies.Remove(m);
                    Console.WriteLine($"{m.Title} Removed!");
                    break;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Incorrect Title");
            }
            return movies;
        }

        public List<Movie> DeleteMovie(string title)
        {
            int counter = 0;
            foreach (var m in movies)
            {
                if (title == m.Title)
                {
                    counter++;
                    movies.Remove(m);
                    Console.WriteLine($"{m.Title} Removed!");
                    break;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Incorrect Title");
            }
            return movies;
        }

        public void UpdateMovie()
        {
            bool stay = true;
            while (stay)
            {
                Console.Write("Enter the movie's title: ");
                string title = Console.ReadLine();
                int counter = 0;

                foreach (var m in movies)
                {
                    if (title == m.Title)
                    {
                        counter++;
                        Console.WriteLine("What would you like to update?\n(1) Title\n(2) Starring\n(3) Director\n(4) Genre");
                        string choice = Console.ReadLine().ToLower();
                        int numChoice;
                        bool numOrWord = int.TryParse(choice, out numChoice);
                        if (choice == "title" || numChoice == 1)
                        {
                            Console.Write("New Title: ");
                            string newInput = Console.ReadLine();
                            m.Title = newInput;
                            Console.WriteLine($"Updated Description {m}");
                            break;
                        }
                        else if (choice == "starring" || numChoice == 2)
                        {
                            Console.Write("New Actor: ");
                            string newInput = Console.ReadLine();
                            m.Actor = newInput;
                            Console.WriteLine($"Updated Description {m}");
                            break;
                        }
                        else if (choice == "director" || numChoice == 3)
                        {
                            Console.Write("New Director: ");
                            string newInput = Console.ReadLine();
                            m.Director = newInput;
                            Console.WriteLine($"Updated Description {m}");
                            break;
                        }
                        else if (choice == "genre" || numChoice == 4)
                        {
                            Console.Write("New Genre: ");
                            string newInput = Console.ReadLine();
                            m.Genre = newInput;
                            Console.WriteLine($"Updated Description \n{m}");
                            break;
                        }

                    }
                }
                if (counter == 0)
                {
                    Console.WriteLine("Incorrect Title");
                }

                Console.WriteLine("Change a different title? (Y/N)");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    stay = true;
                }
                else if (input == "n")
                {
                    stay = false;
                }
            }
        }

        public bool UpdateMovie(string title, string choice, string newInput)
        {
            int counter = 0;
            bool successfulUpdate = true;
            foreach (var m in movies)
            {
                if (title == m.Title)
                {
                    counter++;
                    Console.WriteLine("What would you like to update?\n(1) Title\n(2) Starring\n(3) Director\n(4) Genre");
                    choice = choice.ToLower();
                    int numChoice;
                    bool numOrWord = int.TryParse(choice, out numChoice);
                    if (choice == "title" || numChoice == 1)
                    {
                        Console.Write("New Title: ");
                        m.Title = newInput;
                        Console.WriteLine($"Updated Description {m}");
                        return successfulUpdate;
                    }
                    else if (choice == "starring" || numChoice == 2)
                    {
                        Console.Write("New Actor: ");
                        m.Actor = newInput;
                        Console.WriteLine($"Updated Description {m}");
                        return successfulUpdate;
                    }
                    else if (choice == "director" || numChoice == 3)
                    {
                        Console.Write("New Director: ");
                        m.Director = newInput;
                        Console.WriteLine($"Updated Description {m}");
                        return successfulUpdate;
                    }
                    else if (choice == "genre" || numChoice == 4)
                    {
                        Console.Write("New Genre: ");
                        m.Genre = newInput;
                        Console.WriteLine($"Updated Description \n{m}");
                        return successfulUpdate;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input");
                        successfulUpdate = false;
                        return successfulUpdate;
                    }

                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Incorrect Title");
                successfulUpdate = false;
            }
            return successfulUpdate;
        }

        public void EditList()
        {
            Console.WriteLine("(1) Add\n(2) Delete\n(3) Update");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                AddMovie();
            }
            else if (input == 2)
            {
                DeleteMovie();
            }
            else if (input == 3)
            {
                UpdateMovie();
            }
        }

        public override void MovieList(List<Movie> movies)
        {
            Console.WriteLine("(1) User View\n(2) Admin View");
            int input = int.Parse(Console.ReadLine());
            if(input == 1)
            {
                base.MovieList(movies);
            }
            else if(input == 2)
            {
                EditList();
            }
        }


    }

    public class User
    {
        protected List<Movie> movies;
        protected string name;

        public User(List<Movie> movies, string name)
        {
            this.movies = movies;
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public List<Movie> ListOFMovies
        {
            get
            {
                return movies;
            }
            set
            {
                movies = value;
            }
        }


        public List<Movie> SortG(List<Movie> movies)
        {
            List<Movie> genreMovies = new List<Movie>();
            IEnumerable<Movie> test;
            test = movies.OrderBy(movies => movies.Genre);
            foreach (var m1 in test)
            {
                foreach (var m2 in test)
                {
                    if (m1.Genre == m2.Genre)
                    {
                        int counter = 0;
                        foreach (var gm in genreMovies)
                        {
                            if (m2 == gm)
                            {
                                counter++;
                            }
                        }
                        if (counter == 0)
                        {
                            genreMovies.Add(m2);
                        }
                    }
                }
            }

            return genreMovies;
        }


        public List<Movie> SortD(List<Movie> movies)
        {
            List<Movie> directorMovies = new List<Movie>();
            IEnumerable<Movie> test;
            test = movies.OrderBy(movies => movies.Director);
            foreach (var m1 in test)
            {
                foreach (var m2 in test)
                {
                    if (m1.Director == m2.Director)
                    {
                        int counter = 0;
                        foreach (var gm in directorMovies)
                        {
                            if (m2 == gm)
                            {
                                counter++;
                            }
                        }
                        if (counter == 0)
                        {
                            directorMovies.Add(m2);
                        }
                    }
                }
            }

            return directorMovies;
        }


        public List<Movie> SortMN(List<Movie> movies)
        {
            List<Movie> mnMovies = new List<Movie>();
            IEnumerable<Movie> test;
            test = movies.OrderBy(movies => movies.Title);
            foreach (var m1 in test)
            {
                foreach (var m2 in test)
                {
                    if (m1.Title == m2.Title)
                    {
                        int counter = 0;
                        foreach (var gm in mnMovies)
                        {
                            if (m2 == gm)
                            {
                                counter++;
                            }
                        }
                        if (counter == 0)
                        {
                            mnMovies.Add(m2);
                        }
                    }
                }
            }

            return mnMovies;
        }


        public List<Movie> SortMA(List<Movie> movies)
        {
            List<Movie> maMovies = new List<Movie>();
            IEnumerable<Movie> test;
            test = movies.OrderBy(movies => movies.Actor);
            foreach (var m1 in test)
            {
                foreach (var m2 in test)
                {
                    if (m1.Actor == m2.Actor)
                    {
                        int counter = 0;
                        foreach (var gm in maMovies)
                        {
                            if (m2 == gm)
                            {
                                counter++;
                            }
                        }
                        if (counter == 0)
                        {
                            maMovies.Add(m2);
                        }
                    }
                }
            }

            return maMovies;
        }


        public virtual void MovieList(List<Movie> movies)
        {
            while (true)
            {
                List<Movie> newList = new List<Movie>();
                //set an if chain to determine the format of the list
                Console.WriteLine("Filter by:\n(1) Movie Title\n(2) Starring\n(3) Director\n(4) Genre\n(5) Quit");
                string choice = Console.ReadLine().ToLower();
                bool numOrWord = int.TryParse(choice, out int input);
                if (choice == "movie title" || input == 1)
                {
                    newList = SortMN(movies);
                }
                else if (choice == "starring" || input == 2)
                {
                    newList = SortMA(movies);
                }
                else if (choice == "director" || input == 3)
                {
                    newList = SortD(movies);
                }
                else if (choice == "genre" || input == 4)
                {
                    newList = SortG(movies);
                }
                else if(choice == "quit" || input == 5)
                {
                    break;
                }

                foreach (var m in newList)
                {
                    Console.WriteLine(m);
                }
            }

        }

    }

    public class Movie
    {
        private string title;
        private string actor;
        private string director;
        private string genre;

        public Movie(string movieName, string mainActor, string director, string genre)
        {
            this.title = movieName;
            this.actor = mainActor;
            this.director = director;
            this.genre = genre;
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Actor
        {
            get
            {
                return actor;
            }
            set
            {
                actor = value;
            }
        }

        public string Director
        {
            get
            {
                return director;
            }
            set
            {
                director = value;
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
            }
        }

        public override string ToString()
        {
            return $"{title}\nStarring: {actor}\nDirected By: {director}\nGenre: {genre}\n\n";
        }
    }

    public class MovieRepo
    {

        private static Movie m1 = new Movie("Bungalo", "Bob Barter", "Stevn King", "Action");
        private static Movie m2 = new Movie("Mumps", "Joey Birch", "Moca Boca", "Action");
        private static Movie m3 = new Movie("Blanked", "Knarley Sample", "Nancy Bourne", "Action");
        private static Movie g1 = new Movie("Norton", "Bob Barter", "Stevn King", "Comedy");
        private static Movie g2 = new Movie("Fortay", "Joey Birch", "Moca Boca", "Drama");
        private static Movie g3 = new Movie("Venting", "Shirley Temple", "Nancy Bourne", "Horror");
        private List<Movie> _movies = new List<Movie>() { m1, m2, m3, g1, g2, g3 };

        public MovieRepo(List<Movie> movies)
        {
            this.movies = movies;
        }

        public MovieRepo()
        {
            //Default
        }


        public List<Movie> GetMovies()
        {
            return movies;
        }

        public List<Movie> movies
        {
            get
            {
                return _movies;
            }
            set
            {
                _movies = value;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            MovieRepo AllMovies = new MovieRepo();

            string input;
            User u = new User(AllMovies.movies, "Trina");
            Admin a = new Admin(AllMovies.movies, "Ray");
            while(true)
            {
                Console.Write("Enter Name to Continue ");
                Console.Write("\nEnter Quit to exit\n ");
                input = Console.ReadLine();
                if (input == u.GetName())
                {
                    u.MovieList(u.ListOFMovies);
                }
                else if (input == a.GetName())
                {
                    a.MovieList(a.ListOFMovies);
                }
                else if (input == "Quit")
                {
                    Console.WriteLine("Have a great day!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}
