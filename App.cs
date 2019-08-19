using System;
using System.Collections.Generic;
using Golf.Interfaces;
using Golf.Models;

namespace Golf
{
  public class App : IApp
  {
    public App(Course activeCourse)
    {
      this.ActiveCourse = activeCourse;

    }

    public Course ActiveCourse { get; set; }
    public List<Player> Players { get; set; }
    public List<Course> Courses { get; set; }

    /* void Setup(); //NOTE responsible for initializing your data and establishing relationships (ie, adding course instances to the Courses list, etc.).
        void SelectCourse(); //NOTE gracefully handles bad inputs and assigns the ActiveCourse based on appropriate user selection
        void SetPlayers(); //NOTE responsible for determining number of players and generating a new player instance for each and adding them to the list of players
        void Run(); //NOTE responsible for managing application flow and gameplay
        void DisplayPlayerResults(); //NOTE responsible for determining winner and [STRETCH GOAL] listing out players scores per hole */
    public void DisplayCourses()
    {
      Console.WriteLine("Please Select a course:");
      Console.WriteLine("1. Mini Put Course\n2. Fox Hill Executive Course\n3. Rivers Canyon Course");
      Console.WriteLine("Course >");
    }

    public void DisplayPlayerResults()

    {
      Console.WriteLine($"{ActiveCourse} ");
      Console.WriteLine();

    }
    public void GetScore()
    {
      bool valScore = false;
      Console.Clear();
      for (int i = 1; i <= 9; i++)
      {
        Console.WriteLine($"Hole {i}");
        foreach (IPlayer player in Players)
        {
          while (valScore == false)
          {
            Console.WriteLine($"Strokes for {Players}");
            string scoreS = Console.ReadLine();
            if (int.Parse(scoreS.ToString()).GetType().Equals(typeof(int)))
            {
              int score = Int32.Parse(scoreS);
              player.Scores.Add(score);
              valScore = true;
              break;
            }
            else
            {
              Console.WriteLine("Please enter valid number!");
              valScore = false;
            }
          }
        }


      }
    }
    public void Greeting()
    {
      Console.WriteLine("Welcome to CodeWork Golf Course!");
      Console.WriteLine("Press any key to Start");
      Console.ReadKey();
    }

    public void Run()
    {
      Greeting();
      Console.Clear();
      bool continueGame = true;
      while (continueGame)
      {
        DisplayCourses();
        SelectCourse();
        SetPlayers();
        GetScore();
        DisplayPlayerResults();
      }

      // TODO "playing the game"
      // for every hole in ActiveCourse.Holes
      // for every player in Players
      // record that players score for that hole and save to that player's Score property

    }

    public void SelectCourse()
    {
      switch (Console.ReadLine())
      {
        case "1":
          ActiveCourse = Courses[0];
          break;
        case "2":
          ActiveCourse = Courses[1];
          break;
        case "3":
          ActiveCourse = Courses[2];
          break;
        default:
          Console.WriteLine("Invalid Entry");
          break;

      }

      Console.WriteLine($"Thanks for choosing {ActiveCourse.Name}");
    }

    public void SetPlayers()
    {
      bool valNumPlayer = false;
      while (valNumPlayer == false)
      {
        Console.WriteLine("How many players?");
        string playerNum = Console.ReadLine();
        if (int.Parse(playerNum.ToString()).GetType().Equals(typeof(int)))
        {
          int iPlayer = Int32.Parse(playerNum);
          for (int i = 1; i <= iPlayer; i++)
          {
            Console.WriteLine($"Player {i} Name >");
            string name = Console.ReadLine();
            Player player = new Player(name);
            Players.Add(player);
          }
          valNumPlayer = true;
          break;
        }
        else
        {
          Console.WriteLine("Please enter valid number!");
          valNumPlayer = true;
        }
      }
    }

    public void Setup()
    {
      //TODO create holes
      Hole par2 = new Hole(2);
      Hole par3 = new Hole(3);
      Hole par4 = new Hole(4);
      Hole par5 = new Hole(5);

      //TODO create courses
      Course miniGolf = new Course("Mini Put Course");
      Course foxHill = new Course("Fox Hill Executive Course");
      Course riverCanyon = new Course("River Canyon Course");

      // TODO add holes to courses
      miniGolf.Holes.Add(par2);
      miniGolf.Holes.Add(par3);
      miniGolf.Holes.Add(par2);
      miniGolf.Holes.Add(par3);
      miniGolf.Holes.Add(par5);
      miniGolf.Holes.Add(par4);
      miniGolf.Holes.Add(par2);
      miniGolf.Holes.Add(par4);
      miniGolf.Holes.Add(par5);


      foxHill.Holes.Add(par2);
      foxHill.Holes.Add(par3);
      foxHill.Holes.Add(par5);
      foxHill.Holes.Add(par4);
      foxHill.Holes.Add(par4);
      foxHill.Holes.Add(par2);
      foxHill.Holes.Add(par3);
      foxHill.Holes.Add(par2);
      foxHill.Holes.Add(par3);

      riverCanyon.Holes.Add(par3);
      riverCanyon.Holes.Add(par2);
      riverCanyon.Holes.Add(par4);
      riverCanyon.Holes.Add(par3);
      riverCanyon.Holes.Add(par5);
      riverCanyon.Holes.Add(par4);
      riverCanyon.Holes.Add(par5);
      riverCanyon.Holes.Add(par5);
      riverCanyon.Holes.Add(par2);


      // TODO add courses to the Courses list
      Courses.Add(miniGolf);
      Courses.Add(foxHill);
      Courses.Add(riverCanyon);
    }

    public App()
    {
      Players = new List<Player>();
      Courses = new List<Course>();
    }
  }
}