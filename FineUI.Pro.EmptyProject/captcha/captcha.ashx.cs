using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Drawing.Imaging;

namespace FineUI.Pro.EmptyProject
{
    /// <summary>
    /// 生成验证码图片
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class captcha : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            int width = 200;
            int height = 30;

            width = ParseDimension(context.Request.QueryString["w"], width, 20, 1000);
            height = ParseDimension(context.Request.QueryString["h"], height, 20, 300);

            string captchaText = context.Session["CaptchaImageText"] as string;
            if (String.IsNullOrEmpty(captchaText))
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain; charset=utf-8";
                context.Response.Write("验证码已失效，请刷新登录页面。");
                return;
            }

            // 从 Session 中读取验证码，并创建图片
            CaptchaImage.CaptchaImage ci = new CaptchaImage.CaptchaImage(captchaText, width, height, "Consolas");

            try
            {
                // 输出图片
                context.Response.Clear();
                context.Response.ContentType = "image/jpeg";

                ci.Image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            }
            finally
            {
                ci.Dispose();
            }
        }

        private static int ParseDimension(string value, int defaultValue, int minimum, int maximum)
        {
            int parsed;
            if (!Int32.TryParse(value, out parsed))
            {
                return defaultValue;
            }

            return Math.Max(minimum, Math.Min(maximum, parsed));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
