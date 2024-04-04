using Infrastructure.DataContext;
using Infrastructure.Services;
using Infrastructure.Services.CourseServices;
using Infrastructure.Services.GroupServices;
using Infrastructure.Services.MentorServices;
using Infrastructure.Services.Relations;
using Infrastructure.Services.StudentServices;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<IMentorService,MentorService>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<IGroupService,GroupService>();
builder.Services.AddScoped<IMentor_GroupService,Mentor_GroupService>();
builder.Services.AddScoped<IStudent_GroupService,Student_GroupService>();
builder.Services.AddScoped<DapperContext>();



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();