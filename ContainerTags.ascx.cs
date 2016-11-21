using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke;
using DotNetNuke.Entities.Modules;
using System.Text;

namespace DNNspot.Tags
{
    public partial class ContainerTags : DotNetNuke.UI.Skins.SkinObjectBase
    {
        public int ModuleId { get; private set; }                

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ModuleInfo moduleInfo = ModuleController.Instance.GetModule(ModuleControl.ModuleContext.ModuleId, ModuleControl.ModuleContext.TabId, false);
                this.ModuleId = moduleInfo.ModuleID;

                var moduleTerms = ModuleControl.ModuleContext.Configuration.Terms;
                string termUrlFormat = DotNetNuke.Common.Globals.NavigateURL(PortalSettings.SearchTabId, "", "Tag={0}");

                var html = new StringBuilder();

                html.Append(@"<ul class=""categories"">");
                foreach (var term in moduleTerms)
                {
                    html.AppendFormat(@"<li><a href=""{0}"" title=""{1}"" rel=""tag"">{1}</a></li>", string.Format(termUrlFormat, term.Name), term.Name);
                }
                html.Append("</ul>");

                litHtml.Text = html.ToString();
            }
            catch(Exception ex)
            {
                DotNetNuke.Services.Exceptions.Exceptions.LogException(ex);
                litHtml.Text = string.Empty;
            }
        }
    }
}