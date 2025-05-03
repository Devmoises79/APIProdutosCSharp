var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

var produtos = new List<Produto>();
var proximoId = 1;

// GET - listar todos
app.MapGet("/api/produtos", () => produtos);

// GET - buscar por ID
app.MapGet("/api/produtos/{id}", (int id) =>
{
    var produto = produtos.FirstOrDefault(p => p.Id == id);
    return produto is not null ? Results.Ok(produto) : Results.NotFound();
});

// POST - criar novo produto
app.MapPost("/api/produtos", (Produto produto) =>
{
    if (string.IsNullOrWhiteSpace(produto.Nome))
        return Results.BadRequest("O nome do produto é obrigatório.");

    if (produto.Preco <= 0)
        return Results.BadRequest("O preço deve ser maior que zero.");

    produto.Id = proximoId++;
    produtos.Add(produto);
    return Results.Created($"/api/produtos/{produto.Id}", produto);
});


// PUT - atualizar produto
app.MapPut("/api/produtos/{id}", (int id, Produto atualizado) =>
{
    if (string.IsNullOrWhiteSpace(atualizado.Nome))
        return Results.BadRequest("O nome do produto é obrigatório.");

    if (atualizado.Preco <= 0)
        return Results.BadRequest("O preço deve ser maior que zero.");

    var produto = produtos.FirstOrDefault(p => p.Id == id);
    if (produto is null) return Results.NotFound();

    produto.Nome = atualizado.Nome;
    produto.Preco = atualizado.Preco;
    return Results.NoContent();
});


// DELETE - remover produto
app.MapDelete("/api/produtos/{id}", (int id) =>
{
    var produto = produtos.FirstOrDefault(p => p.Id == id);
    if (produto is null) return Results.NotFound();

    produtos.Remove(produto);
    return Results.NoContent();
});

app.Run();

record Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public decimal Preco { get; set; }
}
