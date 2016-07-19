using System.Linq;
using System.Reflection;
using GoogleAPI.Places.Types;

namespace GoogleAPI.Places.ParameterBuilder.QueryBuilder
{
  internal class SearchQueryBuilderBase : QueryBuilderBase
  {
    public SearchQueryBuilderBase( string baseUrl, string apiKey ) :
      base( baseUrl )
    {
      AddParameter( ApiParameters.ApiKey, apiKey );
    }

    public void SetQuery( string query )
    {
      AddParameter( ApiParameters.Query, query );
    }

    public void SetRadius( int radius )
    {
      AddParameter( ApiParameters.Radius, radius.ToString() );
    }

    public void SetLocation( double latitude, double longitude )
    {
      AddParameter( ApiParameters.Location, $"{latitude},{longitude}" );
    }

    public void SetRankingBy( RankBy rankBy )
    {
      AddParameter( ApiParameters.RankBy, rankBy.ToString().ToLowerInvariant() );
    }

    public void SetKeyword( string keyword )
    {
      AddParameter( ApiParameters.Keyword, keyword );
    }

    public void SetLanguage( Languages language )
    {
      LanguageCodeAttribute languageCodeAttribute = GetLanguageCodeAttribute(language);
      AddParameter( ApiParameters.Language, languageCodeAttribute?.Code );
    }

    public void SetPrice( int? minprice, int? maxprice )
    {
      if ( minprice.HasValue )
        AddParameter( ApiParameters.MinPrice, minprice.Value.ToString() );

      if ( maxprice.HasValue )
        AddParameter( ApiParameters.MaxnPrice, maxprice.Value.ToString() );
    }

    public void SetNames( params string[] names )
    {
      AddParameter( ApiParameters.Name, string.Join( "|", names ) );
    }

    public void SetPageToken( string pageToken )
    {
      AddParameter( ApiParameters.PageToken, pageToken );
    }

    public void SetType( SearchTypes type )
    {
      AddParameter( ApiParameters.Type, type.ToString().ToLowerInvariant() );
    }

    public LanguageCodeAttribute GetLanguageCodeAttribute( Languages language )
    {
      MemberInfo memberInfo = typeof( Languages )
        .GetMember( language.ToString() )
        .FirstOrDefault();

      LanguageCodeAttribute attribute = (LanguageCodeAttribute)memberInfo?
        .GetCustomAttributes( typeof( LanguageCodeAttribute ), false )
        .FirstOrDefault();

      return attribute;
    }
  }
}