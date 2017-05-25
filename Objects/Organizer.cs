using System.Collections.Generic;
using System;

namespace Organizer.Objects
{
  public class Rack
  {
    private string _title;
    private int _id;
    private static List<Rack> _instances = new List<Rack>{};
    private List<Artist> _artists;

    public Rack (string title)
    {
      _title = title;
      _instances.Add(this);
      _id = _instances.Count;
      _artists = new List<Artist>{};
    }
    public string GetTitle()
    {
      return _title;
    }
    public void SetTitle(string title)
    {
      _title = title;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Rack> GetAll()
    {
      return _instances;
    }
    public static Rack Find(int searchId)
   {
     return _instances[searchId-1];
   }
   public List<Artist> GetArtists()
   {
     return _artists;
   }
   public void AddArtist(Artist artist)
   {
     _artists.Add(artist);
   }
  }
}
