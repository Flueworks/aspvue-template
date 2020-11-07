using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using School.Entity;

namespace School.Authorization
{
    public class TeacherAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Teacher>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       OperationAuthorizationRequirement requirement,
                                                       Teacher resource)
        {
            context.Succeed(requirement);
        }
    }
}
