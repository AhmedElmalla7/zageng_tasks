using JobListingsBoard_API.Data;
using JobListingsBoard_API.Models;

namespace JobListingsBoard_API.Services
{
    public class JobService : IJobService
    {
        private readonly AppDbContext _context;

        public JobService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(JobListing job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public IEnumerable<JobListing> GetAllActive()
        {
            return _context.Jobs.Where(j => j.IsActive == true).ToList();
        }

        public JobListing GetById(int id)
        {
            return _context.Jobs.FirstOrDefault(j => j.Id == id);
        }

        public void SoftDelete(int id)
        {
            var job = _context.Jobs.Find(id);
            if (job != null)
            { 
                job.IsActive = false;
                _context.SaveChanges();
            }
        }

        public void Update(int id, JobListing job)
        {
            var existingJob = _context.Jobs.Find(id);
            if (existingJob != null)
            {
                existingJob.Title = job.Title;
                existingJob.Company = job.Company;
                existingJob.Location = job.Location;
                existingJob.Salary = job.Salary;

                _context.SaveChanges();
            }
        }
    }
}
