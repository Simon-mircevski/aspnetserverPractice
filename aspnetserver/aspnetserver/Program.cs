using aspnetserver.Data;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
    });
});

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ASP.NET React Tutorial", Version = "v1" });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP.NET React Tutorial";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API serving a very simple Post model.");
    swaggerUIOptions.RoutePrefix = string.Empty;
});
// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.MapGet("/get-all-posts", async () => await PostRepository.GetPostsAsync())
    .WithTags("Posts Endpoints");
app.MapGet("/get-post-by-id/{postId}", async (int postId) =>
{
    Post postToReturn = await PostRepository.getPostByIdAsync(postId);
    if (postToReturn != null)
    {
        return Results.Ok(postToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.MapPost("/create-post", async (Post postToCreate) =>
{
    bool createdSuccessfully = await PostRepository.CreatePostAsynch(postToCreate);
    if (createdSuccessfully)
    {
        return Results.Ok("Create Successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.MapPut("/update-post", async (Post postToUpdate) =>
{
    bool updatedSuccessfully = await PostRepository.UpdatePostAsync(postToUpdate);
    if (updatedSuccessfully)
    {
        return Results.Ok("Update Successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");
app.MapDelete("/delete-post/{postId}", async (int postId) =>
{
    bool deletedSuccessfully = await PostRepository.DeletePostAsync(postId);
    if (deletedSuccessfully)
    {
        return Results.Ok("Delete Successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");
app.Run();
