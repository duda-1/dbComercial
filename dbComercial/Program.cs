using Core._02_Repository.Interface;
using Core._02_Repository;
using Core._01_Services.Interface;
using Core._01_Services;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program)); // Para Program.cs
//importaçoes

// Endereco
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>(); 
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
//Empresa
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
//Departamento
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
//Cliente
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
//Funcionario
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
//Cargo
builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<ICargoRepository, CargoRepository>();
//TipoMercadoria
builder.Services.AddScoped<ITipoMercadoriaService, TipoMercadoriaService>();
builder.Services.AddScoped<ITipoMercadoriaRepository, TipoMercadoriaRepository>();
// Mercadorias
builder.Services.AddScoped<IMercadoriasService, MercadoriasService>();
builder.Services.AddScoped<IMercadoriasRepository, MercadoriasRepository>();
// Fornecedor
builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
// FornecedorMercadoria
builder.Services.AddScoped<IFornecedorMercadoriaService, FornecedorMercadoriaService>();
builder.Services.AddScoped<IFornecedorMercadoriaRepository, FornecedorMercadoriaRepository>();
// TabelaCompra
builder.Services.AddScoped<ITabelaComprasService, TabelaComprasService>();
builder.Services.AddScoped<ITabelaComprasRepository, TabelaComprasRepository>();
//TabelaComprasMercadorias
builder.Services.AddScoped<ITabelaComprasMercadoriasService, TabelaComprasMercadoriasService>();
builder.Services.AddScoped<ITabelaComprasMercadoriasRepository, TabelaComprasMercadoriasRepository>();



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
