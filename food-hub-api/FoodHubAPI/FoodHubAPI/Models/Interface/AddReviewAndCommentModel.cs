using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class AddReviewAndCommentModel
    {

        public int OrderId { get; set; }
        public float Rating { get; set; }
        public string? Comment { get; set; }

    }
}
