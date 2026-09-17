using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

using FineUI.Pro;
using AspNet = System.Web.UI.WebControls;


namespace FineUI.Pro.EmptyProject
{
    public class PageBase : System.Web.UI.Page
    {
        #region OnInit

        protected override void OnInit(EventArgs e)
        {
            var pm = PageManager.Instance;
            if (pm != null)
            {
                HttpCookie themeCookie = Request.Cookies["Theme"];
                if (themeCookie != null)
                {
                    string themeValue = themeCookie.Value;

                    // 是否为内置主题
                    if (IsSystemTheme(themeValue))
                    {
                        pm.CustomTheme = String.Empty;
                        pm.Theme = (Theme)Enum.Parse(typeof(Theme), themeValue, true);
                    }
                    else
                    {
                        pm.CustomTheme = themeValue;
                    }
                }

                if (Constants.IS_COMMUNITY_EDITION)
                {
                    pm.EnableAnimation = false;
                }
            }

            base.OnInit(e);
        }

        private bool IsSystemTheme(string themeName)
        {
            themeName = themeName.ToLower();
            string[] themes = Enum.GetNames(typeof(Theme));
            foreach (string theme in themes)
            {
                if (theme.ToLower() == themeName)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

    }

}
