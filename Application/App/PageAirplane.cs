﻿namespace Application
{
    using System.Linq;
    using System.Threading.Tasks;
    using Database.Demo;
    using Framework.DataAccessLayer;
    using Framework.Json;

    public class PageAirplane : Page
    {
        public PageAirplane(ComponentJson owner) : base(owner) { }

        public override async Task InitAsync()
        {
            new Html(this) { TextHtml = "<h1>Airplane <i class='fas fa-plane'></i></h1>" };
            new Html(this) { TextHtml = "Browse airplanes from <a href='https://en.wikipedia.org/wiki/List_of_aircraft_type_designators' target='_blank'>wikipedia.org</a> data. On how to convert and import data into sql database see <a href='https://github.com/WorkplaceX/Research/tree/master/Wikipedia' target='_blank'>github.com/WorkplaceX/Research</a>.<br/><br/>" };

            await new GridAirplane(this).LoadAsync();
        }

        protected override IQueryable GridLookupQuery(Grid grid, Row row, string fieldName, string text)
        {
            if (fieldName == nameof(RawWikipediaAircraft.IataCode))
            {
                return Data.Query<CountryDisplayCache>().Where(item => item.IsFlagIconCss == true && (item.Code.StartsWith(text == null ? "" : text)));
            }
            return base.GridLookupQuery(grid, row, fieldName, text);
        }

        protected override string GridLookupRowSelected(Grid grid)
        {
            return ((CountryDisplayCache)grid.RowSelected).Code;
        }
    }

    public class GridAirplane : Grid<RawWikipediaAircraft>
    {
        public GridAirplane(ComponentJson owner) : base(owner) { }

        protected override Task<bool> UpdateAsync(RawWikipediaAircraft row, RawWikipediaAircraft rowNew, DatabaseEnum databaseEnum)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Add some annotation to the grid data like hyperlink or render as image.
        /// </summary>
        protected override void CellAnnotation(string fieldNameCSharp, RawWikipediaAircraft row, CellAnnotationResult result)
        {
            if (fieldNameCSharp == nameof(RawWikipediaAircraft.Model) && row?.ModelImageUrl != null)
            {
                result.HtmlLeft = string.Format("<img src='{0}' width='128' />", row.ModelImageUrl);
            }

            if (fieldNameCSharp == nameof(RawWikipediaAircraft.ModelUrl) && row?.ModelUrl != null)
            {
                result.Html = string.Format("<a href='{0}' target='_blank'>{1}", row.ModelUrl, "Wikipedia");
            }

            if (fieldNameCSharp == nameof(RawWikipediaAircraft.ModelImageUrl) && row?.ModelImageUrl != null)
            {
                result.Html = string.Format("<a href='{0}' target='_blank'>{1}", row.ModelImageUrl, "Image");
            }
        }
    }
}
