using JobListingsBoard_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JobListingsBoard_API.Filters
{
    public class ValidateJobFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.TryGetValue("job", out var value))
            {
                context.Result = new BadRequestObjectResult("Invalid request data");
                return;
            }

            var job = value as JobListing;

            if (job == null ||
            string.IsNullOrWhiteSpace(job.Title) ||
            string.IsNullOrWhiteSpace(job.Company) ||
            job.Salary <= 0)
            {
                context.Result = new BadRequestObjectResult("Title and Company are required. Salary must be positive.");
            }
        }
    }
}
