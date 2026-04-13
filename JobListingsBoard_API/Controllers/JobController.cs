using JobListingsBoard_API.Filters;
using JobListingsBoard_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobListingsBoard_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]
        [Route("")]
        [ValidateJobFilter]
        public ActionResult<int> Create(JobListing job)
        {
            _jobService.Create(job);
            return Ok(job.Id);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<JobListing> GetAllActive()
        {
            return _jobService.GetAllActive().ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public JobListing GetById(int id)
        {
            return _jobService.GetById(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult SoftDelete(int id)
        {
            _jobService.SoftDelete(id);
            return Ok();   
        }

        [HttpPut]
        [Route("")]
        [ValidateJobFilter]
        public ActionResult Update(int id, JobListing job)
        { 
            _jobService.Update(id , job);
            return Ok();
        }

    }
}
