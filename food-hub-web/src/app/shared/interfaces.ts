
export interface IRestaurantDetail {
    Id: number,
    Active: boolean,
    ActivationRequest,
    Name: string,
    About: string,
    Rating: number,
    City: string,
    Street: string,
    AverageDeliveryTime: number,
    MinOrderPrice: number,
    Approved: boolean
    MapSrc: string,
    Facebook: string,
    Instagram: string,
    Twitter: string,
    PhoneNumber: string,
    Created,
    Updated
}

export interface ITime {
    Days: number,
    Hours: number,
    Milliseconds: number,
    Minutes: number,
    Seconds: number,
    Ticks: number,
    TotalDays: number,
    TotalHours: number,
    TotalMilliseconds: number,
    TotalMinutes: number,
    Totalseconds: number
}

export interface IWorkingTime {
    CloseAt: {Hour: string, Minute: string},
    Day: number,
    Id: number,
    OpenAt: {Hour: string, Minute: string},
    RestaurantId: number
}

export interface IGetRestaurantDetail { // GET: RestaurantDetail
    restaurantDetail: IRestaurantDetail,
    workingTime: IWorkingTime,
    isOpen: boolean
}

export interface IGetOwnerRestaurantDetail { // GET: OwnerRestaurantDetail
    restaurantDetail: IRestaurantDetail,
    workingTime: IWorkingTime
}

export interface IUserRegistration {
    FirstName: string;
    LastName: string;
    Email: string;
    Password: string;
    //discriminator; //user
}

export interface IUser {
    Email;
    Address;
    EmailConfirmed;
    PhoneNumber;
    PhoneNumberConfirmed;
    FirstName;
    LastName;
    RestaurantId;
}

export interface IMenuItem {
    Id: number,
    Name: string,
    Category: string,
    About: string,
    Price: number
}

export interface IGetOrderDetails {
    ProductName: string,
    ProductPrice: number,
    Quantity: number
}

export interface IGetOrders {
    UserId: string,
    OrderId: number,
    UserFullName: string,
    PhoneNumber: string,
    PhoneNumberConfirmed: boolean,
    Address: string,
    Note: string,
    Restaurant: string,
    Status: string,
    Total: number,
    Created: any,
    Updated: any,
    Details: IGetOrderDetails[],
    AllowReview: boolean
}

export interface IPostOrderDetails {
    ProductId: number,
    Quantity: number
}

export interface IPostOrder {
    RestaurantId: number,
    Address: string,
    Note: string,
    Detail: IPostOrderDetails[],
}

export interface ICart {
    RestaurantId: number,
    RestaurantName: string,
    ProductId: number,
    ProductName: string,
    ProductPrice: number,
    Quantity: number
}

export interface IPostReviewAndComment {
    OrderId: number,
    Rating: number,
    Comment: string
}

export interface IGetReviewAndComments {
    Rating: number,
    Comment: string,
    Created,
    Response: string
}

export interface IGetEarningsHistory {
    history: {
        Id: number,
        RestaurantId: number,
        Year: number,
        Month: number,
        Total: number
    },
    dailyData : {
        Day: number,
        Total: number
    } 
}

export interface IConfirmMail {
    UserId: string,
    Hash: string
}

export interface IResetPassword {
    UserId: string,
    Hash: string,
    NewPassword: string
}

export interface IResetPasswordMail {
    Email: string
}

export interface IApplicantRestaurant {
    RestaurantName: string,
    RestaurantCity: string,
    RestaurantStreet: string,
    FirstName: string,
    LastName: string,
    Email: string,
    PhoneNumber: string,
}

export interface IPartnerConfirmMail {
    GUID: string,
    Id: number
}

export interface IGetRestaurants {
    Page: number,
    PageSize: number
}

export interface IId {
    Id: number
}

export interface IUserId {
    Id: string
}

export interface IApplicantDetails {
    CreatedAt: string,
    Email: string,
    EmailConfirmed: boolean,
    FirstName: string,
    GUID: string,
    Id: number,
    LastName: string,
    PhoneNumber: string,
    RestaurantCity: string,
    RestaurantName: string,
    RestaurantStreet: string
}

export interface ISendMail {
    Title: string,
    Body: string,
    UserId: string
}

export interface IFeedback {
    Id: number,
    Type: string,
    Message: string,
    Created: any,
    UserId: string
}

export interface IConfirmDialog {
    Title: string,
    Action: string,
    Body: string
}


