using Bogus.DataSets;
using Bogus.Hollywood.DataSets;
using Project.COMMON.Tools;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPattern
{
    public class MyInit : CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            AppUser au = new AppUser();//Boss Tanımlama
            au.Role = ENTITIES.Enums.UserRole.Boss;
            au.Active = true;
            au.Email = "emregorentest@gmail.com";
            au.Password = DantexCrypt.Crypt("123456");
            au.ConfirmPassword = DantexCrypt.Crypt("123456");
            context.AppUsers.Add(au);

            UserProfile up = new UserProfile();//Boss Profil Tanımlama
            up.ID = au.ID;
            up.FirstName = "Emre";
            up.LastName = "Goren";
            up.MobilePhone = "5541938161";
            up.Gender = ENTITIES.Enums.Gender.Erkek;
            context.UserProfiles.Add(up);
            context.SaveChanges();

            string[] genres = new string[] {"Korku","Bilim Kurgu","Aksiyon","Belgesel","Macera" };
           
            for (int i = 1; i <=5; i++)
            {

                Genre genre = new Genre();
                genre.ID = i;


                genre.GenreName = genres[i - 1];
                genre.Description = new Lorem("tr").Sentence(10);
                context.Genres.Add(genre);
            }
            context.SaveChanges();

            
            for (int i = 1; i <=10; i++)
            {
                Actor actor = new Actor();
                actor.FirstName = new Name("en").FirstName();
                actor.LastName = new Name("en").LastName();
                actor.Age = new Random().Next(30,50).ToString();
                actor.Country = new Address("en").Country();
                context.Actors.Add(actor);
            }
            context.SaveChanges();

            for (int i = 1; i <=5; i++)
            {
                Director director = new Director();
                director.FirstName = new Name("en").FirstName();
                director.LastName = new Name("en").LastName();
                director.Age = new Random().Next(30, 50).ToString();
                director.Country = new Address("en").Country();
                context.Directors.Add(director);
            }
            context.SaveChanges();

            for (int i = 1; i <= 20; i++)
            {
                Movie movie = new Movie();
                movie.MovieName = new Lorem("en").Word();
                movie.Description = new Lorem("en").Sentences(10);
                movie.DirectorID = new Random().Next(1, 6);
                movie.MovieYear = new Random().Next(2005, 2020).ToString();
                movie.GenreID = new Random().Next(1, 6);

                context.Movies.Add(movie);
            }
            context.SaveChanges();

            for (int i = 1; i < 10; i++)
            {

            }

        }

    }
}
