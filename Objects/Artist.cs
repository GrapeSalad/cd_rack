using System.Collections.Generic;
using System;

namespace Organizer.Objects
{
  public class Artist
  {
    private static List<Artist> _artists = new List<Artist> {};
    private string _artistName;
    private int _id;
    public Artist(string artistName)
    {
      _artistName = artistName;
      _artists.Add(this);
      _id = _artists.Count;
    }

    public string GetName()
    {
      return _artistName;
    }
    // public void SetName(string artistName)
    // {
    //   _artistName = artistName;
    // }
    public int GetId()
    {
      return _id;
    }
    public static List<Artist> GetAll()
    {
      return _artists;
    }
    public static void Clear()
    {
      _artists.Clear();
    }
    public static Artist Find(int searchId)
    {
      return _artists[searchId-1];
    }
  }
}
