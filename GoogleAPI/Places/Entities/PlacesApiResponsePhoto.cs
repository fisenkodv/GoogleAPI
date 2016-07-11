﻿using Newtonsoft.Json;

namespace GoogleAPI.Places.Entities
{
  public class PlacesApiResponsePhoto
  {
    [JsonProperty( "height" )]
    public int Height { get; set; }

    [JsonProperty( "html_attributions" )]
    public string[] HtmlAttributions { get; set; }

    [JsonProperty( "photo_reference" )]
    public string PhotoReference { get; set; }

    [JsonProperty( "width" )]
    public int Width { get; set; }
  }
}
