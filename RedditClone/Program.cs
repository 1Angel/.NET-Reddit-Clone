using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RedditClone.Controllers;
using RedditClone.Data;
using RedditClone.Services;
using RedditClone.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//databasee
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("dbconn"));
});

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//services
builder.Services.AddTransient<ISubRedditService, SubRedditServiceImpl>();
builder.Services.AddTransient<IPostService, PostServiceImpl>(); 
builder.Services.AddTransient<ICommentService, CommentServiceImpl>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
