using CQIE.OVS.Models.IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.OVS.Web.Models
{
    public class SessionService
    {
        private HttpContext m_HttpContext;
        private SysUser m_User;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null)
            {
                this.m_HttpContext = httpContextAccessor.HttpContext;
            }
        }

        public bool IsAuthenticated {
            get {
                return this.m_HttpContext.User.Identity.IsAuthenticated;
            }
        }

        public SysUser GetSessionUser()
        {
            if (m_User == null && m_HttpContext.Session != null)
            {
                var buffer = new byte[0];
                if (m_HttpContext.Session.TryGetValue("SessionUser", out buffer))
                {
                    try
                    {
                        var str = System.Text.Encoding.UTF8.GetString(buffer);
                        m_User = System.Text.Json.JsonSerializer.Deserialize<SysUser>(str);
                    }
                    catch { }
                }
            }

            return m_User;
        }

        public string UserName {
            get {
                var user = this.GetSessionUser();
                if (user != null)
                {
                    return user.UserName;
                }

                return null;
            }
        }

        public int GetUserId()
        {
            var user = this.GetSessionUser();
            if (user != null)
            {
                return user.Id;
            }

            return 0;
        }

        public List<int> GetRoleIds()
        {
            if (m_HttpContext.Session != null)
            {
                var buffer = new byte[0];
                if (m_HttpContext.Session.TryGetValue("UserRoleIds", out buffer))
                {
                    try
                    {
                        var str = System.Text.Encoding.UTF8.GetString(buffer);
                        return System.Text.Json.JsonSerializer.Deserialize<List<int>>(str);
                    }
                    catch { }
                }
            }

            return null;
        }

        public void Clear()
        {
            if (m_HttpContext.Session != null)
            {
                m_HttpContext.Session.Clear();
            }
        }

    }
}
