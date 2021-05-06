using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApp.Pages.Portal.Shared;

namespace WebApp.Services
{
    /// <summary>
    /// 路由拦截逻辑
    /// </summary>
    public class AppRouteView : RouteView
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthService AuthenticationService { get; set; }
        [Inject]
        public ILogger<AppRouteView> Logger { get; set; }

        protected override void Render(RenderTreeBuilder builder)
        {
            // 登录、注册、主页不需要验证
            var noNeedAuthorizeRoutePath = new string[] { "/signIn", "/index", "/", "/signUp", "/signOut" };
            var navigator = new Uri(NavigationManager.Uri);
            var localpath = navigator.LocalPath;


            Console.WriteLine("path:"+localpath);
            if (noNeedAuthorizeRoutePath.Contains(localpath))
            {
                Logger.LogInformation("no authorize" + localpath);
                base.Render(builder);
            }
            else
            {
                // 验证
                var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
                Logger.LogInformation(authorize.ToString());
                if (authorize && !AuthenticationService.IsLogin)
                {
                    // 未验证跳转
                    var returnUrl = WebUtility.UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery);
                    NavigationManager.NavigateTo($"signIn?returnUrl={returnUrl}");
                }
                else
                {
                    // Portal模块
                    if (localpath.StartsWith("/portal"))
                    {
                        this.DefaultLayout = typeof(PortalLayout);
                    }

                    base.Render(builder);
                }
            }
        }
    }
}
