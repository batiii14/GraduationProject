using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Ornek
builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IAdminDal,AdminDal>();

builder.Services.AddScoped<IBookingService,BookingManager>();
builder.Services.AddScoped<IBookingDal,BookingDal>();

builder.Services.AddScoped<ICommentService,CommentManager>();
builder.Services.AddScoped<ICommentDal,CommentDal>();

builder.Services.AddScoped<IDormitoryService,DormitoryManager>();
builder.Services.AddScoped<IDormitoryDal,DormitoryDal>();

builder.Services.AddScoped<IDormitoryDetailService,DormitoryDetailManager>();
builder.Services.AddScoped<IDormitoryDetailDal,DormitoryDetailDal>();

builder.Services.AddScoped<IDormitoryOwnerService,DormitoryOwnerManager>();
builder.Services.AddScoped<IDormitoryOwnerDal,DormitoryOwnerDal>();

builder.Services.AddScoped<IMessageService,MessageManager>();
builder.Services.AddScoped<IMessageDal,MessageDal>();

builder.Services.AddScoped<INotificationService,NotificationManager>();
builder.Services.AddScoped<INotificationDal,NotificationDal>();

builder.Services.AddScoped<IRatingService,RatingManager>();
builder.Services.AddScoped<IRatingDal,RatingDal>();

builder.Services.AddScoped<IRoomService,RoomManager>();
builder.Services.AddScoped<IRoomDal,RoomDal>();

builder.Services.AddScoped<IStudentService,StudentManager>();
builder.Services.AddScoped<IStudentDal,StudentDal>();

builder.Services.AddScoped<IUniversityService,UniversityManager>();
builder.Services.AddScoped<IUniversityDal,UniversityDal>();

builder.Services.AddScoped<ILoginService, LoginManager>();
builder.Services.AddScoped<ILoginDal,LoginDal>();

builder.Services.AddScoped<IVerificationCodeService,VerificationCodeManager>();
builder.Services.AddScoped<IVerificationCodeDal,VerificationCodeDal>();

builder.Services.AddTransient<IEmailSenderService, EmailSenderManager>();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.UseCors(opt =>
{
    opt.WithOrigins("http://localhost:4200")
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowCredentials();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
