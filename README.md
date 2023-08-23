# I - A PRIMEIRA APLICAÇÃO ASP.NET MVC 5
## 1.1 - Criando o projeto no Visual Studio 2019 Community.
- Selecione no menu o 'Create a new Project';
- Selecione 'ASP.NET Web Application (.NET Framework)', linguagem 'C#';
- Crie um nome para o Projeto;
- Selecione 'Empty' e 'MVC';
- Verifique se criaram as pastas:
- Controllers, Models, Views
## 1.2 - Criando o Controlador para Categorias de Produtos.
- Na Soluction Explorer, clique com o botão direito do mouse sobre a pasta Controllers e clique na opção Add -> Controller;
- Na Janela que se abre, selecione o template MVC 5 Controller - Empty;
- Clique com o botão Add;
- Na janela que se apresenta, solicitando o nome do controlador, digite Categorias e mantenha o sufixo Controller, pois faz parte da convenção do ASP.NET MVC.
## 1.3 - Criando a classe de domínio para Categorias de produtos.
- Na pasta Models, crie uma classe chamada Categoria da seguinte forma:
- public long CategoriaId { get; set; } 
- public string Nome { get; set; }
## 1.4 - Implementando a interação da Action Index com a visão.
- Em CategoriasController crie os objetos:
private static readonly IList<Categoria> categorias = new List<Categoria>()
{
   new Categoria()
   {
       CategoriaId = 1,
       Nome = "Notebooks"
   },
   new Categoria()
   {
       CategoriaId = 2,
       Nome = "Monitores"
   },
   new Categoria()
   {
       CategoriaId = 3,
       Nome = "Impressoras"
   },
   new Categoria()
   {
    CategoriaId = 4,
    Nome = "Mouses"
},
new Categoria()
{
    CategoriaId = 5,
    Nome = "Desktops"
}
};

- // GET: Categorias
public ActionResult Index()
{
   return View(categorias);
}
	
- Antes de criar a View, dê um build em seu projeto;
- Ao criar a View, desmarque a caixa 'Use a layout page';
## 1.5 - Finalizando a aplicação por meio da implementação da operação Delete do Crud.
- Insira abaixo do código @Html.AntiForgeryToken() a implementação: @Html.HiddenFor(model => model.CategoriaId)

# II - REALIZANDO ACESSO A DADOS NA APLICAÇÃO ASP.NET MVC COM O ENTITY FRAMEWORK
## 2.1 - Começando com o Entity Framework
- Crie uma nova classe chamada Fabricante, conforme abaixo:
public long FabricanteId { get; set; }
public string Nome { get; set; }
- Instale o EntityFramework versão 6.3.1;
- Verifique se está instalado o EF e o EF SQLSERVER em References;
- Crie a pasta Contexts e, dentro dela, a classe EFContext, conforme abaixo:
public class EFContext : DbContext
{
public EFContext() : base("Asp_Net_MVC_CS") { }
public DbSet<Categoria> Categorias { get; set; }
public DbSet<Fabricante> Fabricantes { get; set; }
}
- Configure a string de conexão em Web.config abaixo do appSettings da seguinte forma:
- connectionStrings
- add name="Asp_Net_MVC_CS" connectionString="Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Asp_Net_MVC_DB.mdf; Integrated Security=True; MultipleActiveResultSets=True" providerName="System.Data.SqlClient"
## 2.2 - Implementando o CRUD fazendo uso do Entity Framework
- Crie o FabricantesController Empty;
- Crie as actions e insira o context;
- Dê um build na solução;
- Crie as Views utilizando os Contexts;
- Em App_Data, clique duas vezes no arquivo mdf;
- Insira dados de fabricantes;
- Faça o CRUD completo.
# III - LAYOUTS, BOOTSTRAP E JQUERY DATATABLE
- Instalar Bootstrap versão 3.3.6;
- Criar pasta Shared em Views;
- Criar layout Page (Razor) (Add-> MVC 5 layout Page (Razor));
- Nome do arquivo _Layout.cshtml;
- Inserir código do arquivo _Layout.cshtml do github;
- Ob: xs é para celulares e md é para desktops;
- Inserir  'Layout = "~/Views/Shared/_Layout.cshtml";' no do @{};
- Instalar jquery.datatables versão 1.10.10;
- Inserir abaixo do layout... 'ViewBag.Title = "Listagem de FABRICANTES"';
- Configure toda a página Index de Fabricante;
- Configurar todo arquivo _Layout.cshtml;
- Adaptar todas as visões (Create, Edit, Details, Delete);
- Inserir glyphicons (ícones) do Bootstrap;
- Inserir aviso de que foi removido com sucesso ao Deletar.