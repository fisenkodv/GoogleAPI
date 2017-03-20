using GoogleApi.Places.Search.Types;
using GoogleApi.Places.Types;
using GoogleApi.QueryBuilder;

namespace GoogleApi.Places.Search.ParameterBuilder.Interfaces
{
  /// <summary>
  /// A Nearby Search lets you search for places within a specified area. 
  /// You can refine your search request by supplying keywords or specifying the type of place you are searching for.
  /// </summary>
  public interface INearbyHttpQueryBuilder : IHttpQueryBuilder
  {
    INearbyHttpQueryBuilder Radius( int radius );
    INearbyHttpQueryBuilder Location( double latitude, double longitude );
    INearbyHttpQueryBuilder RankingBy( RankBy rankBy );
    INearbyHttpQueryBuilder Keyword( string keyword );
    INearbyHttpQueryBuilder Language( Languages language );
    INearbyHttpQueryBuilder Price( int? minprice, int? maxprice );
    INearbyHttpQueryBuilder Names( params string[] names );
  }
}