using System.Collections.Generic;
using Golf.Interfaces;

namespace Golf.Models
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public List<int> Scores { get; set; }

    public void DisplayFinalScore()
    {

    }
    public Player(string name)
    {
      Name = name;
      Scores = new List<int>();
    }
  }
}