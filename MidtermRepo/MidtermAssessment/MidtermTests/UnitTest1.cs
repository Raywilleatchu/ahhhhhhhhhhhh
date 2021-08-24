using System;
using Xunit;
using Midterm;
using System.Collections.Generic;

namespace MidtermTests
{
    public class UnitTest1
    {
        [Fact]
        public void SortGenreTest()
        {
            Movie m1 = new Movie("Bungalo", "Bob Barter", "Stevn King", "Action");
            Movie m2 = new Movie("Mumps", "Joey Birch", "Moca Boca", "Action");
            Movie m3 = new Movie("Blanked", "Knarley Sample", "Nancy Bourne", "Action");
            Movie g1 = new Movie("Norton", "Bob Barter", "Stevn King", "Comedy");
            Movie g2 = new Movie("Fortay", "Joey Birch", "Moca Boca", "Drama");
            Movie g3 = new Movie("Venting", "Shirley Temple", "Nancy Bourne", "Horror");

            List<Movie> movies = new List<Movie>() { g3, m3, g1, m2, g2, m1 };
            List<Movie> expectedList = new List<Movie>() { m1, m2, m3, g1, g2, g3 };
            List<string> expected = new List<string>();
            foreach (var e in expectedList)
            {
                expected.Add(e.Genre);
            }

            User u = new User(movies, "Name");

            List<Movie> sortedList = u.SortG(movies);
            List<string> actual = new List<string>();

            foreach (var m in sortedList)
            {
                actual.Add(m.Genre);
            }
            Assert.Equal(expected, actual);

        }


        [Fact]
        public void SortDirectorTest()
        {
            Movie m1 = new Movie("Bungalo", "Bob Barter", "Stevn King", "Action");
            Movie m2 = new Movie("Mumps", "Joey Birch", "Moca Boca", "Action");
            Movie m3 = new Movie("Blanked", "Knarley Sample", "Nancy Bourne", "Action");
            Movie g1 = new Movie("Norton", "Bob Barter", "Stevn King", "Comedy");
            Movie g2 = new Movie("Fortay", "Joey Birch", "Moca Boca", "Drama");
            Movie g3 = new Movie("Venting", "Shirley Temple", "Nancy Bourne", "Horror");

            List<Movie> movies = new List<Movie>() { g3, m3, g1, m2, g2, m1 };
            List<Movie> expectedList = new List<Movie>() { g2, m2, g3, m3, g1, m1 };
            List<string> expected = new List<string>();
            foreach (var e in expectedList)
            {
                expected.Add(e.Director);
            }

            User u = new User(movies, "Name");

            List<Movie> sortedList = u.SortD(movies);
            List<string> actual = new List<string>();

            foreach (var m in sortedList)
            {
                actual.Add(m.Director);
            }
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void SortTitleTest()
        {
            Movie m1 = new Movie("Bungalo", "Bob Barter", "Stevn King", "Action");
            Movie m2 = new Movie("Mumps", "Joey Birch", "Moca Boca", "Action");
            Movie m3 = new Movie("Blanked", "Knarley Sample", "Nancy Bourne", "Action");
            Movie g1 = new Movie("Norton", "Bob Barter", "Stevn King", "Comedy");
            Movie g2 = new Movie("Fortay", "Joey Birch", "Moca Boca", "Drama");
            Movie g3 = new Movie("Venting", "Shirley Temple", "Nancy Bourne", "Horror");



            List<Movie> movies = new List<Movie>() { g3, m3, g1, m2, g2, m1 };
            List<Movie> expectedList = new List<Movie>() { m3, m1, g2, m2, g1, g3 };
            List<string> expected = new List<string>();
            foreach (var e in expectedList)
            {
                expected.Add(e.Title);
            }

            User u = new User(movies, "Name");

            List<Movie> sortedList = u.SortMN(movies);
            List<string> actual = new List<string>();

            foreach (var m in sortedList)
            {
                actual.Add(m.Title);
            }
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortActorTest()
        {
            Movie m1 = new Movie("Bungalo", "Bob Barter", "Stevn King", "Action");
            Movie m2 = new Movie("Mumps", "Joey Birch", "Moca Boca", "Action");
            Movie m3 = new Movie("Blanked", "Knarley Sample", "Nancy Bourne", "Action");
            Movie g1 = new Movie("Norton", "Bob Barter", "Stevn King", "Comedy");
            Movie g2 = new Movie("Fortay", "Joey Birch", "Moca Boca", "Drama");
            Movie g3 = new Movie("Venting", "Shirley Temple", "Nancy Bourne", "Horror");

            List<Movie> movies = new List<Movie>() { g3, m3, g1, m2, g2, m1 };


            List<Movie> expectedList = new List<Movie>() { m1, g1, g2, m2, m3, g3 };
            List<string> expected = new List<string>();
            foreach (var e in expectedList)
            {
                expected.Add(e.Actor);
            }

            User u = new User(movies, "Name");

            List<Movie> sortedList = u.SortMA(movies);
            List<string> actual = new List<string>();

            foreach (var m in sortedList)
            {
                actual.Add(m.Actor);
            }

            Assert.Equal(expected, actual);

        }


        [Theory]
        [InlineData(0, "Bungalo")]
        [InlineData(5, "Venting")]
        [InlineData(2, "Blanked")]
        [InlineData(3, "Norton")]
        [InlineData(1, "Mumps")]
        public void GetMoviesTest(int index, string expected)
        {
            MovieRepo mr = new MovieRepo();
            List<Movie> movies = mr.GetMovies();
            string actual = movies[index].Title;
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void AddTest()
        {
            Movie m1 = new Movie("Bungalo", "Bob Barter", "Stevn King", "Action");
            Movie m2 = new Movie("Mumps", "Joey Birch", "Moca Boca", "Action");
            Movie m3 = new Movie("Blanked", "Knarley Sample", "Nancy Bourne", "Action");
            Movie g1 = new Movie("Norton", "Bob Barter", "Stevn King", "Comedy");
            Movie g2 = new Movie("Fortay", "Joey Birch", "Moca Boca", "Drama");
            Movie g3 = new Movie("Venting", "Shirley Temple", "Nancy Bourne", "Horror");

            List<Movie> movies = new List<Movie>() { g3, m3, g1, m2, g2, m1 };

            Admin a = new Admin(movies, "Ray");
            //Movie newMovie = new Movie("title", "actor", "director", "genre");
            List<Movie> updatedList = a.AddMovie("title", "actor", "director", "genre");

            int actual = movies.Count;
            int expected = 7;

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("title", 6)]
        [InlineData("Bungalo",5)]
        [InlineData("Mumps", 5)]
        [InlineData("blanked", 6)]
        [InlineData("Norton", 5)]
        [InlineData("Plume", 6)]
        public void DeleteTest(string title, int expected)
        {
            Movie m1 = new Movie("Bungalo", "Bob Barter", "Stevn King", "Action");
            Movie m2 = new Movie("Mumps", "Joey Birch", "Moca Boca", "Action");
            Movie m3 = new Movie("Blanked", "Knarley Sample", "Nancy Bourne", "Action");
            Movie g1 = new Movie("Norton", "Bob Barter", "Stevn King", "Comedy");
            Movie g2 = new Movie("Fortay", "Joey Birch", "Moca Boca", "Drama");
            Movie g3 = new Movie("Venting", "Shirley Temple", "Nancy Bourne", "Horror");

            List<Movie> movies = new List<Movie>() { g3, m3, g1, m2, g2, m1 };

            Admin a = new Admin(movies, "Ray");
            //Movie newMovie = new Movie("title", "actor", "director", "genre");
            List<Movie> updatedList = a.DeleteMovie("title");

            a.DeleteMovie(title);

            int actual = movies.Count;
            

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("Bungalo", "Starring", "Moss Man", true)]
        [InlineData("Venting", "idk", "Black Sun", false)]
        [InlineData("Mumps", "Title", "Bumps", true)]
        [InlineData("Monkeys", "Title", "Moneys", false)]
        public void UpdateTest(string title, string choice, string newInput, bool expected)
        {
            Movie m1 = new Movie("Bungalo", "Bob Barter", "Stevn King", "Action");
            Movie m2 = new Movie("Mumps", "Joey Birch", "Moca Boca", "Action");
            Movie m3 = new Movie("Blanked", "Knarley Sample", "Nancy Bourne", "Action");
            Movie g1 = new Movie("Norton", "Bob Barter", "Stevn King", "Comedy");
            Movie g2 = new Movie("Fortay", "Joey Birch", "Moca Boca", "Drama");
            Movie g3 = new Movie("Venting", "Shirley Temple", "Nancy Bourne", "Horror");

            List<Movie> movies = new List<Movie>() { g3, m3, g1, m2, g2, m1 };

            Admin a = new Admin(movies, "Ray");

            bool actual = a.UpdateMovie(title, choice, newInput);

            Assert.Equal(expected, actual);
        }

    }
}
