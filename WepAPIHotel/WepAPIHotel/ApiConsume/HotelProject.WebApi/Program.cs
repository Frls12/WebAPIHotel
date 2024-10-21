using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFreamwork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffService, StaffManager>();
builder.Services.AddScoped<IStaffDal, EfStaffDal>();

builder.Services.AddScoped<IRoomService, RoomManager>();
builder.Services.AddScoped<IRoomDal, EfRoomDal>();

builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();

builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<IGuestService, GuestManager>();
builder.Services.AddScoped<IGuestDal, EfGuestDal>();

builder.Services.AddScoped<ISendMessageService, SendMessageManager>();
builder.Services.AddScoped<ISendMessageDal, EfSendMessageDal>();

builder.Services.AddScoped<IMessageCategoryService, MessageCategoryManager>();
builder.Services.AddScoped<IMessageCategoryDal, EfMessageCategoryDal>();

builder.Services.AddScoped<IWorkLocationService, WorkLocationManager>();
builder.Services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();

builder.Services.AddScoped<IUserService,UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();





builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("OtelApiCors");
app.MapControllers();
app.UseDeveloperExceptionPage();
app.Run();
