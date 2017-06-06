using System;
using Nancy;
using System.Collections.Generic;


namespace Trunk
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        return View["index.cshtml"];
      };

      Get["/items/new"] = _ => {
        return View["item_form.cshtml"];
      };

      Post["/item"] = _ =>
      {
        Item newItem = new Item(Request.Form["new-item"]);
        newItem.Save();

        return View["item.cshtml", newItem];
      };

      Get["/items"] = _ =>
      {
        List<Item> allItems = Item.GetAll();
        return View["items.cshtml", allItems] ;
      };

      Get["/items/{id}"] = parameters =>
      {
        Item item = Item.Find(parameters.id);

        return View["item.cshtml", item];
      };
      Post["/DeleteAll"] = _ =>
      {
        Item.DeleteAll();
        return View["index.cshtml"];
      };
    }
  }
}
