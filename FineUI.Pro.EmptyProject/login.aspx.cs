using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using FineUI.Pro;

namespace FineUI.Pro.EmptyProject
{
    public partial class login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }


        private void LoadData()
        {
            InitCaptchaCode();
        }

        /// <summary>
        /// 初始化验证码
        /// </summary>
        private void InitCaptchaCode()
        {
            // 创建一个 6 位的随机数并保存在 Session 对象中
            Session["CaptchaImageText"] = GenerateRandomCode();

            imgCaptcha.Text = String.Format("<img src=\"{0}\" />", ResolveUrl("~/captcha/captcha.ashx?w=100&h=26&t=" + DateTime.Now.Ticks));
        }



        /// <summary>
        /// 创建一个 6 位的随机数
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomCode()
        {
            StringBuilder code = new StringBuilder(6);
            byte[] randomByte = new byte[1];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                for (int i = 0; i < 6; i++)
                {
                    do
                    {
                        random.GetBytes(randomByte);
                    }
                    while (randomByte[0] >= 250);

                    code.Append(randomByte[0] % 10);
                }
            }
            return code.ToString();
        }

        protected void imgCaptcha_Click(object sender, EventArgs e)
        {
            InitCaptchaCode();
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string captchaText = Session["CaptchaImageText"] as string;
            if (String.IsNullOrEmpty(captchaText)
                || !String.Equals(tbxCaptcha.Text, captchaText, StringComparison.Ordinal))
            {
                InitCaptchaCode();
                Alert.ShowInTop("验证码错误！", String.Empty, tbxCaptcha.GetMarkInvalidReference("验证码错误！") + tbxCaptcha.GetFocusReference());
                return;
            }

            // 验证码校验成功后立即失效，避免同一个验证码被重复使用。
            Session.Remove("CaptchaImageText");

            if (tbxUserName.Text == "admin" && tbxPassword.Text == "admin")
            {
                Alert.ShowInTop("成功登录！");
            }
            else
            {
                Alert.ShowInTop("用户名或密码错误！", MessageBoxIcon.Error);
            }
        }

    }
}
