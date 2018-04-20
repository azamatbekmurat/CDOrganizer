using System.Collections.Generic;
using System;

namespace CDOrganizer.Models
{
  public class CD
  {
    private string _title;
    private string _genre;
    private int _id;

    private static List<CD> _instances = new List<CD> {};

    public CD (string title, string genre)
    {
      _title = title;
      _genre = genre;
      _instances.Add(this);
      _id = _instances.Count;
    }
    public string GetTitle()
    {
      return _title;
    }
    public string GetGenre()
    {
      return _genre;
    }
    public int GetId()
    {
      return _id;
    }

    public static List<CD> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static CD Find(int searchId)
    {
      return _instances[searchId-1];
    }

  }
}
