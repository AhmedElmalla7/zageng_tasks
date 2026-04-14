using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Task_Feedback_API.Models
{
    public class FeedbackRequest
    {
        public string UserName { get; set; }

        [Range(1 , 5 , ErrorMessage = "Rate must be [1 : 5]")]
        public int Rate { get; set; }
        public string Comment { get; set; }
    }
}
