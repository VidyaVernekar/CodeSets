using Microsoft.EntityFrameworkCore;
using MVCApplication.Data;
using MVCApplication.Models;
namespace MVCApplication.Controllers;

public static class studentmodelEndpoints
{
    public static void MapstudentmodelEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/studentmodel", async (MVCApplicationContext db) =>
        {
            return await db.studentmodel.ToListAsync();
        })
        .WithName("GetAllstudentmodels");

        routes.MapGet("/api/studentmodel/{id}", async (int StudentID, MVCApplicationContext db) =>
        {
            return await db.studentmodel.FindAsync(StudentID)
                is studentmodel model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetstudentmodelById");

        routes.MapPut("/api/studentmodel/{id}", async (int StudentID, studentmodel studentmodel, MVCApplicationContext db) =>
        {
            var foundModel = await db.studentmodel.FindAsync(StudentID);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("Updatestudentmodel");

        routes.MapPost("/api/studentmodel/", async (studentmodel studentmodel, MVCApplicationContext db) =>
        {
            db.studentmodel.Add(studentmodel);
            await db.SaveChangesAsync();
            return Results.Created($"/studentmodels/{studentmodel.StudentID}", studentmodel);
        })
        .WithName("Createstudentmodel");

        routes.MapDelete("/api/studentmodel/{id}", async (int StudentID, MVCApplicationContext db) =>
        {
            if (await db.studentmodel.FindAsync(StudentID) is studentmodel studentmodel)
            {
                db.studentmodel.Remove(studentmodel);
                await db.SaveChangesAsync();
                return Results.Ok(studentmodel);
            }

            return Results.NotFound();
        })
        .WithName("Deletestudentmodel");
    }
}
