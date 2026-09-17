using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI.Pro;

namespace FineUI.Pro.EmptyProject
{
    public partial class hello : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHello_Click(object sender, EventArgs e)
        {
            Alert.Show("你好 FineUI！", MessageBoxIcon.Warning);
        }

    }
}
