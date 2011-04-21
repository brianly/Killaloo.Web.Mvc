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

Uses the JSON.NET library to serialize and render an object as JSON. It works best with a list of POCOs:

	public JsonActionResult Json()
	{
		List<Incident> listOfItems = GetListOfItems();

		return new JsonActionResult { ObjectToSerialize = listOfItems, FormatResult = true};
	}

FormatResult is optional and enables/disables pretty printing of the JSON result for easier debugging.

OpenLayersActionResult
----------------------

OpenLayers supports the ability to plot points to a layer on a map from a tab delimited text file. This custom action result helps render that file:

    public OpenLayersActionResult MapData()
    {
        var myPoints = new List<MapPoint>();

        var p = new MapPoint
                    {
                        Title = "Title for point on the map",
                        Icon = "marker.png",
                        IconSize = "21,25",
                        LatLon = "12.9715987,77.5945627",
                        Description = "This is the long description for a point on the map"
        };

        myPoints.Add(p);

        return new OpenLayersActionResult { Points = myPoints };
    }

In your map you need to specify the relative output URL for the result using the URL property:

   var layer = new OpenLayers.Layer.Vector("Layer Name Here", {
        strategies: [new OpenLayers.Strategy.BBOX({ resFactor: 1.1 })],
        protocol: new OpenLayers.Protocol.HTTP({
            url: "/mapdata/",
            format: new OpenLayers.Format.Text()
        })
    });
    
    map.addLayers([wms, layer]); // Map and your overlay