using Nancy;
using Organizer.Objects;
using System.Collections.Generic;
using System;

namespace Organizer
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/add_cd"] = _ => View["add_cd_form.cshtml"];

      Post["add_cd"] = _ => {
        Rack newRack = new Rack(Request.Form["title"]);
        List<Rack> fullRack = Rack.GetAll();
        return View["view_cd_titles.cshtml", fullRack];
      };
      Get["/cd/{id}"] = parameters => {
        Dictionary<string,object> model = new Dictionary<string, object>();
        Rack selectedRack = Rack.Find(parameters.id);
        List<Artist> cdArtists = selectedRack.GetArtists();
        model.Add("rack",selectedRack);
        model.Add("name", cdArtists);
        return View["cd_info.cshtml", model];
      };

      Get["/cd/{id}/add_artist_form"] = parameters => {
        Dictionary<string,object> model = new Dictionary<string, object>();
        Rack selectedRack = Rack.Find(parameters.id);
        List<Artist> cdArtists = selectedRack.GetArtists();
        model.Add("rack",selectedRack);
        model.Add("name", cdArtists);
        return View["artist_entry_form.cshtml", model];
      };
      Post["/add_artist_name"] = _ =>{
        Dictionary<string,object> model = new Dictionary<string, object>();
        Rack selectedRack = Rack.Find(Request.Form["rack-id"]);
        // Console.WriteLine(selectedRack.GetTitle());
        string artistName = Request.Form["artist_name"];
        Artist newArtist = new Artist(artistName);
        List<Artist> cdArtists = selectedRack.GetArtists();
        model.Add("rack",selectedRack);
        model.Add("name", cdArtists);
        cdArtists.Add(newArtist);
        // foreach(Artist artist in cdArtists){
        //   Console.WriteLine("artists name is " + artist.GetName());
        // }
        // Console.WriteLine("rack is " + selectedRack.GetTitle());
        return View["cd_info.cshtml", model];
      };

      Get["/cd"] = _ => {
        List<Rack> fullRack = Rack.GetAll();
        return View["view_cd_titles.cshtml", fullRack];
      };
    }
  }
}
