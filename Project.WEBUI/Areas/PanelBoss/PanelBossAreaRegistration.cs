using System.Web.Mvc;

namespace Project.WEBUI.Areas.PanelBoss
{
    public class PanelBossAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PanelBoss";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PanelBoss_default",
                "PanelBoss/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}