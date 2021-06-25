using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Enum
{
    public class enums
    {
        //For order statuses
        public enum Status { Waiting, Accepted, Completed, Rejected }
        public enum FeedbackType { Suggestion, Question, BugReport, SomethingElse }
    }
}
