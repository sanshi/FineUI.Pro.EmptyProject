<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FineUI.Pro.EmptyProject.index" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>FineUI.Pro 空项目</title>
    <link href="~/res/css/index.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="mainPanel" runat="server"></f:PageManager>
        <f:Panel ID="mainPanel" Layout="Region" CssClass="mainpanel" ShowBorder="false" ShowHeader="false" runat="server">
            <items>
                <f:Panel ID="sidebarRegion" CssClass="sidebarregion" RegionPosition="Left"
                    ShowBorder="false" Width="260" ShowHeader="false"
                    EnableCollapse="false" Collapsed="false" Layout="VBox" runat="server"
                    RegionSplit="true" RegionSplitIcon="false" RegionSplitWidth="3" RegionSplitTransparent="true">
                    <Items>
                        <f:ContentPanel CssClass="topregion" ShowBorder="false" ShowHeader="false" runat="server">
                            <div id="sideheader" class="f-widget-header f-mainheader">
                                <a class="logo" href="./" title="FineUI.Pro空项目" id="logoTitle" runat="server">FineUI.Pro空项目</a>
                            </div>
                        </f:ContentPanel>
                        <f:Panel ID="leftPanel" CssClass="leftregion" BoxFlex="1" ShowBorder="false" ShowHeader="false" Layout="Fit" runat="server">
                            <Items>
                                <f:Tree runat="server" ShowBorder="false" ShowHeader="false" ID="treeMenu" EnableSingleClickExpand="true"
                                    HeaderStyle="true" AllHeaderStyle="true" HideHScrollbar="true" HideVScrollbar="true" ExpanderToRight="true">
                                    <Nodes>
                                        <f:TreeNode Text="默认分类" Expanded="true">
                                            <f:TreeNode Text="开始页面" NavigateUrl="~/hello.aspx"></f:TreeNode>
                                            <f:TreeNode Text="登录页面" NavigateUrl="~/login.aspx"></f:TreeNode>
                                        </f:TreeNode>
                                    </Nodes>
                                </f:Tree>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
                <f:Panel ID="bodyRegion" CssClass="bodyregion" RegionPosition="Center" ShowBorder="false" ShowHeader="false"
                    Layout="VBox" runat="server">
                    <Items>
                        <f:ContentPanel ID="topPanel" CssClass="topregion" ShowBorder="false" ShowHeader="false" runat="server">
                            <div id="header" class="f-widget-header f-mainheader">
                                <div class="header-left">
                                    
                                </div>
                                <div class="header-right">
                                   <f:Button runat="server" CssClass="icononlyaction themes" ID="btnThemeSelect" ToolTip="主题仓库" IconAlign="Top" IconFont="_Skin"
 EnableDefaultState="false" EnableDefaultCorner="false" ClickHandler="onThemeSelectClick"></f:Button>
                                    <f:Button runat="server" CssClass="userpicaction" Text="三生石上" IconUrl="~/res/images/my_face_80.jpg" IconAlign="Left"
 EnableDefaultState="false" EnableDefaultCorner="false">
                                        <Menu runat="server">
                                            <f:MenuButton Text="个人信息" IconFont="_User" runat="server" ClickHandler="onUserProfileClick"></f:MenuButton>
                                            <f:MenuSeparator runat="server"></f:MenuSeparator>
                                            <f:MenuButton Text="安全退出" IconFont="_SignOut" runat="server" ClickHandler="onSignOutClick"></f:MenuButton>
                                        </Menu>
                                    </f:Button>
                                </div>
                            </div>
                        </f:ContentPanel>
                        <f:TabStrip ID="mainTabStrip" CssClass="centerregion" ShowInkBar="true" InkBarPosition="Bottom" BoxFlex="1" ShowBorder="true" EnableTabCloseMenu="true" runat="server">
                            <Tabs>
                                <f:Tab ID="tabHomepage" Title="首页" IconFont="_Home" BodyPadding="10px" AutoScroll="true" runat="server">
                                    <Content>
                                        <h2 style="margin-top: 0;">FineUI.Pro</h2>
                                        .NET 企业级全栈 UI 框架
                                        
                                        <br />
                                        <h2>FineUI的使命</h2>
                                        创建 No JavaScript，No CSS，No UpdatePanel，No ViewState，No WebServices 的网站应用程序
                                        
                                        <br />
                                        <h2>支持的浏览器</h2>
                                        Chrome、Firefox、Safari、Edge

                                        <br />
                                        <h2>授权协议</h2>
                                        商业授权
                                            
                                        <br />
                                        <h2>相关链接</h2>
                                        <ul class="list">
                                            <li>
                                                首页：<a target="_blank" href="http://fineui.com/pro/">http://fineui.com/pro/</a>
                                            </li>
                                            <li>
                                                示例：<a target="_blank" href="https://fineui.com/pro/demo/">https://fineui.com/pro/demo/</a>
                                            </li>
                                            <li>
                                                更新：<a target="_blank" href="http://fineui.com/versions/">http://fineui.com/versions/</a>
                                            </li>
                                            <li>
                                                社区：<a target="_blank" href="http://fineui.com/fans/">http://fineui.com/fans/</a>
                                            </li>
                                            <li>
                                                文档：<a target="_blank" href="http://fineui.com/pro/api/">http://fineui.com/pro/api/</a>
                                            </li>
                                            <li>
                                                JS文档：<a target="_blank" href="http://fineui.com/js/api/">http://fineui.com/js/api/</a>
                                            </li>
                                        </ul>
                                        <br />
                                        <br />
                                    </Content>
                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>
                    </Items>
                </f:Panel>
            </items>
        </f:Panel>

        <f:Window ID="windowThemeRoller" Title="主题仓库" Hidden="true" EnableIFrame="true" IFrameUrl="./common/themes.aspx" ClearIFrameAfterClose="false"
            runat="server" IsModal="true" Width="850px" Height="600px" EnableClose="true"
            EnableMaximize="true" EnableResize="true"></f:Window>
    </form>
    <script>
        var treeMenuClientID = '<%= treeMenu.ClientID %>';
        var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
        var windowThemeRollerClientID = '<%= windowThemeRoller.ClientID %>';

        // 点击主题仓库
        function onThemeSelectClick(event) {
            F(windowThemeRollerClientID).show();
        }

        function onUserProfileClick(event) {
            F.alert('尚未实现');
        }

        function onSignOutClick(event) {
            F.alert('尚未实现');
        }


        // 页面控件初始化完毕后执行
        F.ready(function () {
            var treeMenu = F(treeMenuClientID);
            var mainTabStrip = F(mainTabStripClientID);
            if (!treeMenu) return;

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // options: 参数
            // options.updateHash： 切换Tab时，是否更新地址栏Hash值（默认值：true）
            // options.refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame（默认值：false）
            // options.refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame（默认值：false）
            // options.maxTabCount: 最大允许打开的选项卡数量
            // options.maxTabMessage: 超过最大允许打开选项卡数量时的提示信息
            // options.beforeNodeClick: 节点点击事件之前执行（返回false则不执行点击事件）
            // options.beforeTabAdd: 添加选项卡之前执行（返回false则不添加选项卡）
            // options.moveToEnd: 将选项卡移到尾部（如果选项卡已存在，则不改变位置，默认值：false）
            F.initTreeTabStrip(treeMenu, mainTabStrip, {
                maxTabCount: 10,
                maxTabMessage: '请先关闭一些选项卡（最多允许打开 10 个）！'
            });

        });
    </script>
</body>
</html>
