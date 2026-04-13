using JobListingsBoard_API.Models;

public interface IJobService
{
    IEnumerable<JobListing> GetAllActive(); 
    JobListing GetById(int id); 
    void Create(JobListing job); 
    void Update(int id, JobListing job); 
    void SoftDelete(int id); 
}