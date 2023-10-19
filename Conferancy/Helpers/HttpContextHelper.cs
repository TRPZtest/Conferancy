using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference.Helpers
{
    public static class HttpContextHelper
    {
        public static long GetUserId(this HttpContextBase httpContext)
        {
            var userId = httpContext.Items["UserId"];

            if (userId == null)
                return 0;

            return (long)userId;
        }

        public static void AddUserId(this HttpContextBase httpContext, long userId)
        {
            httpContext.Items.Add("UserId", userId);
        }
    }
}