// Do not modify this file. It's generated by Framework.Cli.

namespace DatabaseBuiltIn.dbo
{
    using System.Collections.Generic;
    using Database.dbo;

    public static class FrameworkConfigGridBuiltInTableApplicationCli
    {
        public static List<FrameworkConfigGridBuiltIn> RowList
        {
            get
            {
                var result = new List<FrameworkConfigGridBuiltIn>();
                result.Add(new FrameworkConfigGridBuiltIn() { Id = 3, IdName = "Demo.Language; ", TableId = 14, TableIdName = "Demo.Language", TableNameCSharp = "Demo.Language", ConfigName = null, RowCountMax = null, IsAllowInsert = null, IsExist = true });
                result.Add(new FrameworkConfigGridBuiltIn() { Id = 4, IdName = "Demo.RawWikipediaAircraft; ", TableId = 20, TableIdName = "Demo.RawWikipediaAircraft", TableNameCSharp = "Demo.RawWikipediaAircraft", ConfigName = null, RowCountMax = 5, IsAllowInsert = null, IsExist = true });
                return result;
            }
        }
    }

    public static class FrameworkConfigFieldBuiltInTableApplicationCli
    {
        public static List<FrameworkConfigFieldBuiltIn> RowList
        {
            get
            {
                var result = new List<FrameworkConfigFieldBuiltIn>();
                result.Add(new FrameworkConfigFieldBuiltIn() { Id = 18, ConfigGridId = 3, ConfigGridIdName = "Demo.Language; ", FieldId = 105, FieldIdName = "Demo.Language; LanguageName", TableNameCSharp = "Demo.Language", ConfigName = null, FieldNameCSharp = "LanguageName", Text = "Sprache", Description = null, IsVisible = null, IsReadOnly = null, Sort = null, IsExist = true });
                result.Add(new FrameworkConfigFieldBuiltIn() { Id = 19, ConfigGridId = 4, ConfigGridIdName = "Demo.RawWikipediaAircraft; ", FieldId = 136, FieldIdName = "Demo.RawWikipediaAircraft; IataCode", TableNameCSharp = "Demo.RawWikipediaAircraft", ConfigName = null, FieldNameCSharp = "IataCode", Text = "IATA Code", Description = null, IsVisible = null, IsReadOnly = null, Sort = null, IsExist = true });
                result.Add(new FrameworkConfigFieldBuiltIn() { Id = 20, ConfigGridId = 4, ConfigGridIdName = "Demo.RawWikipediaAircraft; ", FieldId = 135, FieldIdName = "Demo.RawWikipediaAircraft; IcaoCode", TableNameCSharp = "Demo.RawWikipediaAircraft", ConfigName = null, FieldNameCSharp = "IcaoCode", Text = "ICAO Code", Description = null, IsVisible = null, IsReadOnly = true, Sort = null, IsExist = true });
                result.Add(new FrameworkConfigFieldBuiltIn() { Id = 21, ConfigGridId = 4, ConfigGridIdName = "Demo.RawWikipediaAircraft; ", FieldId = 137, FieldIdName = "Demo.RawWikipediaAircraft; Model", TableNameCSharp = "Demo.RawWikipediaAircraft", ConfigName = null, FieldNameCSharp = "Model", Text = "Image", Description = null, IsVisible = null, IsReadOnly = null, Sort = null, IsExist = true });
                result.Add(new FrameworkConfigFieldBuiltIn() { Id = 22, ConfigGridId = 4, ConfigGridIdName = "Demo.RawWikipediaAircraft; ", FieldId = 140, FieldIdName = "Demo.RawWikipediaAircraft; ModelImageUrl", TableNameCSharp = "Demo.RawWikipediaAircraft", ConfigName = null, FieldNameCSharp = "ModelImageUrl", Text = "Image Link", Description = null, IsVisible = null, IsReadOnly = null, Sort = null, IsExist = true });
                result.Add(new FrameworkConfigFieldBuiltIn() { Id = 23, ConfigGridId = 4, ConfigGridIdName = "Demo.RawWikipediaAircraft; ", FieldId = 139, FieldIdName = "Demo.RawWikipediaAircraft; ModelTitle", TableNameCSharp = "Demo.RawWikipediaAircraft", ConfigName = null, FieldNameCSharp = "ModelTitle", Text = "Title", Description = null, IsVisible = null, IsReadOnly = null, Sort = null, IsExist = true });
                result.Add(new FrameworkConfigFieldBuiltIn() { Id = 24, ConfigGridId = 4, ConfigGridIdName = "Demo.RawWikipediaAircraft; ", FieldId = 138, FieldIdName = "Demo.RawWikipediaAircraft; ModelUrl", TableNameCSharp = "Demo.RawWikipediaAircraft", ConfigName = null, FieldNameCSharp = "ModelUrl", Text = "Url", Description = null, IsVisible = null, IsReadOnly = null, Sort = null, IsExist = true });
                return result;
            }
        }
    }
}
