Killaloo MVC Library
====================

This is a collection of classes from ASP.NET MVC projects that I've built. Use them as you like!

RssActionResult
---------------

This renders an RSS 2.0 feed using classes from WCF:

	public RssActionResult Rss()
	{
		var feed = new SyndicationFeed("Name of feed",
									   "Description of feed",
									   new Uri(Request.Url.ToString()),
									   "ID for feed",
									   DateTime.Now)
		{
			Items = GetListOfItems()
		};

		return new RssActionResult { Feed = feed };
	}

AtomActionResult
----------------

Use this in a similar way to RssActionResult to create an Atom feed.

JsonActionResult
----------------

Using the JSON.NET library this renders JSON to the client for an arbitrary object. It works best with a list of POCOs:

	public JsonActionResult Json()
	{
		List<Incident> listOfItems = GetListOfItems();

		return new JsonActionResult { ObjectToSerialize = listOfItems, FormatResult = true};
	}

FormatResult is optional and enables/disables pretty printing of the JSON result for easier debugging.

