using System.Collections.Generic;
using System;

namespace CDOrganizer.Models
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist> {};
    private string _name;
    private string _id;
    private List<CD> _cds;

    public Artist(string artistName)
    {
      _name = artistName;
      _instances.Add(this);
      _id = _instances.Count;
      _cds = new List<CD>{};
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<CD> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public List<CD> GetCDs()
    {
      return _cds;
    }
    public void AddCD(CD cd)
    {
      _cds.Add(cd);
    }

  }
}
