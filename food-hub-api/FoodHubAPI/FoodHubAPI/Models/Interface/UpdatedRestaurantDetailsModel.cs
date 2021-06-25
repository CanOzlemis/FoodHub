using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class UpdatedRestaurantDetailsModel
    {
        public EditedRestaurantDetailsModel newRestaurantDetails { get; set; }
        public EditedWorkingTimesModel[] newWorkingTimes { get; set; }
    }

    public class EditedRestaurantDetailsModel
    {
        public string About { get; set; }
        public int AverageDeliveryTime { get; set; }
        public int MinOrderPrice { get; set; }
        public string MapSrc { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Image { get; set; }
    }
    public class EditedWorkingTimesModel
    {
        public int Day { get; set; }
        public String OpenTime { get; set; }
        public String CloseTime { get; set; }
    }
}
