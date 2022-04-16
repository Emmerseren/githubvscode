using HåndværkerCase.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DnDContext>(options => options.UseSqlite(
        builder.Configuration.GetConnectionString("DnD")));
builder.Services.AddCors();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


//CORS

app.UseCors(options =>
{
    options.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

// Requests

app.MapGet("/", () =>
{

    Case protoype = new Case();
    protoype.Navn = "Marcus laursen";
    protoype.Adresse = "vendersgade 3b";
    protoype.Beskrivelse = "alt det der";
    protoype.StartsDato = DateTime.Now;
    protoype.SlutsDato = DateTime.Now;

    return protoype;
});

//array of Cases

app.MapGet("/cases", () =>



{
    List<Case> Cases = new List<Case>();

    Case prototypeTwo = new Case();
    prototypeTwo.Navn = "Marius laursen";


    Case prototypeThree = new Case();
    prototypeThree.Navn = "Magnus laursen";

    Cases.Add(prototypeTwo);
    Cases.Add(prototypeThree);

    return Cases;
});

app.MapGet("/api/cases", async (DnDContext db) => await db.cases.ToListAsync());

app.MapGet("/api/beskrivelser/{id}", async (DnDContext db, int id) => await db.beskrivelser.Include(e => e.Case).FirstOrDefaultAsync(e => e.id == id));

app.MapGet("api/beskrivelser", async (DnDContext db) => await db.beskrivelser.Include(e => e.Case).ToListAsync());

app.MapGet("/api/opgaverfracase/{id}", async (DnDContext db, int id) => await db.beskrivelser.Where(e => e.CaseId == id).ToListAsync());

app.MapPost("/api/cases", async (DnDContext db, Case cases) =>
{
    await db.cases.AddAsync(cases);
    await db.SaveChangesAsync();

    return Results.Ok(cases);
});
app.Run();


