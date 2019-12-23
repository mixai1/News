﻿using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace WebApiNews_site.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
