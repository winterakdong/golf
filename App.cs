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
      Console.Clear();
      Console.WriteLine(ActiveCourse.Name);

      // Display Par
      // Console.Write("Par: \t\t");
      // foreach (IHole hole in ActiveCourse.Holes)
      // {
      //   Console.Write();
      // }

      // Display Results for each player
      foreach (IPlayer player in Players)
      {
        Console.Write(player.Name + ":\t\t");
        foreach (int score in player.Scores)
        {
          Console.Write(score + " ");
        }
        int totalScore = player.DisplayFinalScore();
        Console.WriteLine("\t|| Total Score: " + totalScore);
      }

      int lowestScore = int.MaxValue;
      bool ifTied = false;
      foreach (IPlayer player in Players)
      {
        if (player.DisplayFinalScore() < lowestScore)
        {
          lowestScore = player.DisplayFinalScore();
        }
        else if (player.DisplayFinalScore() == lowestScore)
        {
          ifTied = true;
        }
      }

      if (ifTied)
      {
        Console.WriteLine("Winners: ");
        int index = 0;
        foreach (IPlayer player in Players)
        {
          if (player.DisplayFinalScore() == lowestScore && index == 0)
          {
            Console.Write(player.Name);
            index++;
          }
          else if (player.DisplayFinalScore() == lowestScore)
          {
            Console.Write(", " + player.Name);
          }
        }
      }
      else
      {
        Console.WriteLine("Winner: ");
        foreach (IPlayer player in Players)
        {
          if (player.DisplayFinalScore() == lowestScore)
          {
            Console.Write(player.Name);
          }
        }
      }
    }
    public void GetScore()
    {
      // bool valScore = false;
      Console.Clear();
      for (int i = 1; i <= ActiveCourse.Holes.Count; i++)
      {
        Console.Clear();
        Console.WriteLine($"Hole {i}");
        foreach (IPlayer player in Players)
        {
          Console.WriteLine("Strokes for " + player.Name + " >");

          int score = 0;

          while (!int.TryParse(Console.ReadLine(), out score) || score <= 0)
          {
            Console.WriteLine("Invalid input. Please enter a valid numerical value.\n");
            Console.WriteLine("Strokes for " + player.Name + " >");
          }
          player.Scores.Add(score);
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

        Console.WriteLine("\nPress (q) to quit, or any other key to create a new game.");
        switch (Console.ReadLine())
        {
          case "q":
            continueGame = false;
            Console.Clear();
            break;
          default:
            Console.Clear();
            Setup();
            break;
        }
      }

      // TODO "playing the game"
      // for every hole in ActiveCourse.Holes
      // for every player in Players
      // record that players score for that hole and save to that player's Score property

    }

    public void SelectCourse()
    {
      bool validSelection = true;
      do
      {
        String str = Console.ReadLine();
        switch (str)
        {
          case "1":
            ActiveCourse = Courses[0];
            validSelection = true;
            break;
          case "2":
            ActiveCourse = Courses[1];
            validSelection = true;
            break;
          case "3":
            ActiveCourse = Courses[2];
            validSelection = true;
            break;
          default:
            Console.WriteLine("Invalid selection. Please try again.");
            validSelection = false;
            break;
        }
      } while (validSelection == false);
    }

    public void SetPlayers()
    {
      Console.Clear();
      Console.WriteLine("You chose {ActiveCourse.Name}." + "\nHow many players? >");

      int playerCount = 0;
      while (!int.TryParse(Console.ReadLine(), out playerCount) || playerCount <= 0)
      {
        Console.WriteLine("Invalid input. Please enter a valid numerical value.\n");
        Console.WriteLine("How many players? >");
      }

      for (int i = 1; i <= playerCount; i++)
      {
        Console.WriteLine($"Player {i} Name >");
        string name = Console.ReadLine();
        Player player = new Player(name);
        Players.Add(player);
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