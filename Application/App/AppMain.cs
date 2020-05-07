﻿namespace Application
{
    using Database.Demo;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System.Linq;
    using System.Threading.Tasks;

    public class AppMain : AppJson
    {
        public override async Task InitAsync()
        {
            if (this.IsSessionExpired)
            {
                this.HtmlSessionExpired = this.BootstrapAlert("Session expired!", BootstrapAlertEnum.Warning);
                this.IsScrollToTop = true;
            }

            // new Custom01(this) { TextHtml = "Hello <b>World</b>" };

            PageMain = new PageMain(this);
            await PageMain.InitAsync();

            PageCmsContent = new PageCmsContent(this) { IsHide = true };

            // this.Button = new Button(this) { TextHtml = "Click" };
            // new Button(this) { TextHtml = "Click2" };
        }

        public PageMain PageMain;

        public PageCmsContent PageCmsContent;

        public Button Button;

        public Html HtmlSessionExpired;

        protected override Task ProcessAsync()
        {
            // if (Button.IsClick)
            // {
            //     Button.TextHtml += ".";
            // }
            if (this.HtmlSessionExpired != null && this.IsSessionExpired == false)
            {
                this.HtmlSessionExpired.ComponentRemove();
            }
            return base.ProcessAsync();
        }

        protected override async Task FileDownloadAsync(FileDownloadArgs args, FileDownloadResult result)
        {
            if (args.IsFileName(UtilCms.PathCmsFile(), out string fileName))
            {
                var row = (await Data.Query<CmsFile>().Where(item => item.FileName == fileName).QueryExecuteAsync()).FirstOrDefault();
                result.Data = row?.Data;
            }
            else
            {
                if (args.IsFileName("/shop/", out string fileNameShop))
                {
                    var row = (await Data.Query<ShopProductPhoto>().Where(item => item.FileName == fileNameShop).QueryExecuteAsync()).FirstOrDefault();
                    result.Data = row?.Data;
                }
                else
                {
                    if (args.IsPath(UtilCms.PathCmsPage(), out _))
                    {
                        result.IsSession = true;
                    }
                    else
                    {
                        var row = (await Data.Query<StorageFile>().Where(item => item.FileName == args.FileName).QueryExecuteAsync()).FirstOrDefault();
                        result.Data = row?.Data;
                    }
                }
            }
        }

        protected override async Task FileDownloadSessionAsync(FileDownloadArgs args, FileDownloadSessionResult result)
        {
            if (args.Path == "/")
            {
                result.IsPage = true;
                PageMain.IsHide = false;
                PageCmsContent.IsHide = true;
            }
            if (args.IsPath(UtilCms.PathCmsPage(), out string path))
            {
                result.IsPage = true;
                PageMain.IsHide = true;
                PageCmsContent.IsHide = false;
                await PageCmsContent.Load(path);
            }
        }
    }

    public class AppX : AppJson
    {
        public override Task InitAsync()
        {
            new Html(this) { TextHtml = "Hello ApplicationX" };

            return base.InitAsync();
        }
    }
}
