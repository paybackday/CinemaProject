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
           Employee au = new Employee();//Boss Tanımlama
            
            au.Email = "Serkan1903@hotmail.de";
            au.Password = DantexCrypt.Crypt("123");
            au.ConfirmPassword = DantexCrypt.Crypt("123");
            au.EmployeeType = ENTITIES.Enums.EmployeeType.Boss;
            au.FirstName = "Serkan";
            au.LastName = "Akçay";
            au.TCNO = "21111111111";
            au.Sallary = 5300;
            au.MobilePhone = "5316622582";
            context.Employees.Add(au);
            context.SaveChanges();




            AppUser vau = new AppUser();//VIP Tanımlama
            vau.Role = ENTITIES.Enums.UserRole.Vip;
            vau.Active = true;
            vau.Email = "emregoren98@yandex.com";
            vau.Password = DantexCrypt.Crypt("123456");
            vau.ConfirmPassword = DantexCrypt.Crypt("123456");
            context.AppUsers.Add(vau);


            UserProfile vup = new UserProfile();//VIP Profil Tanımlama
            vup.ID = vau.ID;
            vup.FirstName = "Emre";
            vup.LastName = "Özdemir";
            vup.MobilePhone = "5345997081";
            vup.Gender = ENTITIES.Enums.Gender.Erkek;
            context.UserProfiles.Add(vup);
            context.SaveChanges();


            Employee emp = new Employee();//BookingClerk 
            emp.Email = "ercankarahan@hotmail.de";
            emp.Password =DantexCrypt.Crypt( "123");
            emp.ConfirmPassword = DantexCrypt.Crypt("123");
            emp.EmployeeType = ENTITIES.Enums.EmployeeType.BookingClerk;
            emp.FirstName = "Ercan";
            emp.LastName = "Karahan";
            emp.TCNO = "21111111111";
            emp.Sallary = 1300;
            emp.MobilePhone = "5316622582";
            context.Employees.Add(emp);
            context.SaveChanges();

            Employee emp2 = new Employee(); //BoxOfficeSuperVisor

            emp2.EmployeeType = ENTITIES.Enums.EmployeeType.BoxOfficeSupervisor;
            emp2.Email = "emredeneme@gmail.com";
            emp2.Password = DantexCrypt.Crypt("1234");
            emp2.ConfirmPassword = DantexCrypt.Crypt("1234");
            emp2.FirstName = "Yusuf Emre";
            emp2.LastName = "Ozdemir";
            emp2.TCNO = "11111111111";
            emp2.Sallary = 1301;
            emp2.MobilePhone = "5312622582";
            context.Employees.Add(emp2);
            context.SaveChanges();

            Employee emp3 = new Employee(); //Management
            emp3.EmployeeType = ENTITIES.Enums.EmployeeType.Management;
            emp3.Email = "Sakcay415@gmail.com";
            emp3.Password = DantexCrypt.Crypt("serkan1903");
            emp3.ConfirmPassword = DantexCrypt.Crypt("serkan1903");
            emp3.FirstName = "Serkan";
            emp3.LastName = "Akçay";
            emp3.TCNO = "11111111113";
            emp3.Sallary = 4500;
            emp3.MobilePhone = "5312625582";
            context.Employees.Add(emp3);
            context.SaveChanges();





            string[] genres = new string[] { "Korku", "Bilim Kurgu", "Aksiyon", "Belgesel", "Macera" };

            for (int i = 1; i <= 5; i++)
            {

                Genre genre = new Genre();
                genre.ID = i;


                genre.GenreName = genres[i - 1];
                genre.Description = new Lorem("tr").Sentence(10);
                context.Genres.Add(genre);
            }
            context.SaveChanges();


            for (int i = 1; i <= 10; i++)
            {
                Actor actor = new Actor();
                actor.FirstName = new Name("en").FirstName();
                actor.LastName = new Name("en").LastName();
                actor.Age = new Random().Next(30, 50).ToString();
                actor.Country = new Address("en").Country();
                context.Actors.Add(actor);
            }
            context.SaveChanges();

            for (int i = 1; i <= 5; i++)
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
                movie.MovieImagePath = "/Pictures/starWars.jpg";

                context.Movies.Add(movie);
            }
            context.SaveChanges();

           

            context.SaveChanges();


            DateTime[] sessions = new DateTime[] { Convert.ToDateTime("2021-04-17 11:00:00.000"), Convert.ToDateTime("2021-04-22 13:00:00.000"), Convert.ToDateTime("2021-05-27 14:00:00.000"), Convert.ToDateTime("2021-05-29 15:00:00.000"), Convert.ToDateTime("2021-06-12 15:00:00.000") };

            for (int i = 0; i < 5; i++)
            {
                Session session = new Session();
                session.ID = i + 1;
                session.Time = sessions[i];
                session.SessionActive = true;
                session.IsSpecial = false;
                session.Price = Convert.ToDecimal(new Commerce("tr").Price());
                context.Sessions.Add(session);

            }
            context.SaveChanges();



            for (int i = 1; i <= 5; i++)
            {
                Saloon saloon = new Saloon();
                saloon.SaloonNo = i;
                context.Saloons.Add(saloon);
            }
            context.SaveChanges();

            for (int i = 1; i <= 5; i++)
            {

                for (char j = 'A'; j < 'I'; j++)
                {
                    for (int k = 1; k <= 14; k++)
                    {
                        Seat seat = new Seat();
                        seat.SeatActive = false;
                        seat.SaloonID = i;
                        seat.SessionID = i;
                        seat.Character = Convert.ToString(j);
                        seat.Number = k;
                        context.Seats.Add(seat);
                    }
                }
            }
            context.SaveChanges();


            for (int l = 1; l <= 5; l++)
            {
                MovieSessionSaloon mss = new MovieSessionSaloon();
                mss.MovieID = l;
                mss.SessionID = l;
                mss.SaloonID = l;
                context.MovieSessionSaloons.Add(mss);
            }
            context.SaveChanges();
        
        
        }

    }
}
