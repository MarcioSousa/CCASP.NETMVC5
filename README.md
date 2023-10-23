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
# IV - ASSOCIAÇÕES NO ENTITY FRAMEWORK
- Criar classe Produto;
- Inserir a ligação entre as classes: 
- Classe Produto:
public long? ProdutoId { get; set; }
public string Nome { get; set; }
public long? CategoriaId { get; set; }
public long? FabricanteId { get; set; }
public Categoria Categoria { get; set; }
public Fabricante Fabricante { get; set; }
- Classe Fabricante e Categoria:
public virtual ICollection<Produto> Produtos { get; set; }
- Inserir a classe Produto no context;
- Criar Colletion utilizando opção 'MVC 5 Controller with read/write actions'
- inserir o seguinte código no Index 'return View(context.Produtos.OrderBy(c=>c.Nome));';
- Criar a visão Index igual a Visão Fabricante, inserindo dois display for com Fabricante.nome e Categoria.nome;
- Inserir em layout.cshtml o 'li' de Produtos e aparecerá um erro, é preciso configurar o entity Framework (base de dados);
- Alterar o EFContext;
- Insira dados nas bases novas;
- Incluir no topo da ProdutosController o using System.Data.Entity;
- Inserir a instrução lambda: var produtos = context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);return View(produtos);
- Criar o CRUD utilizando novos códigos (ViewBag);
- Adapte a visão Details de Fabricantes;
- Adapte a visão Details de Categorias;
- Inserir o Partial View em Produtos criando _PorFabricante e _PorCategoria;
- inserir Partial View no Edit, Delete e Details.
# V - SEPARANDO A APLICAÇÃO EM CAMADAS
- Criar camada de negócio (Modelo);
- No Projeto Web, vai em referencias e adiciona o Modelo;
- Em modelo, deletar o Class1.cs;
- Criar duas pastas: Cadastros e Tabelas;
- Mova Classe Categoria para a pasta Tabelas;
- Alterar namespace para Modelo.Tabelas;
- Corrigir todos os erros e colocando Modelo.Tabelas e Modelo.Cadastros;
- Abra todas as visões e corrija;
- Crie o projeto de Persistencia;
- Em Persistencia, adicione a referencia ao Modelo;
- Instale o entity Framework 6.1.3 em Persistencia;
- Crie uma pasta chamada Context e jogue os arquivos lá;
- Crie pasta DAL e dentro crie mais outras duas: Cadastros e Tabelas;
- Código para EFContex para retirar a plurarização:
- protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
base.OnModelCreating(modelBuilder);
modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
}
- Criar as classes na pasta DAL;
- Criar camada Servico;
- Adicionar as referências Persistencia e Modelo;
- Criar as duas pastas e, pasta tabela e dentro, a classe CategoriaServico;
- Configurar os Controladores;
- Criar _PartialDetailsContantPanel.cshtml e configurar.
# VI - CODE FIRST MIGRATIONS, DATA ANNOTATIONS, VALIDAÇÃO E JQUERYUI
- Menu tools/nuget Package Manager/Package Manager Console;
- Selecione nuget.org e Persistencia e digite Enable-Migrations no prompt do package manager console;
- Em Configuration, mude a instrução AutomaticMigrationsEnabled para true;
- Em EFContext, mude o contrutor para :
Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
- Abrir references em Modelo e adicionar o Framework System.ComponentModel.DataAnnotations;
- Fazer adaptação do Modelo utilizando ComponentModel e DataAnnotations;
- Aparecendo erro, insira em Configuration o código AutomaticMigrationDataLossAllowed = true;
- Depois de rodar, altere, em Configuration o código AutomaticMigrationDataLossAllowed = false;
- Na visão Create, em @Html.LabelFor, apague o CategoriaId e FabricanteId;
- Em controller Produto, em Create, no método GravarProduto(), coloque o PopularViewBag(produto) antes dos dois Return View(Produto);
- Caso não apareça as mensagens de ValidationSummary(), troque para false, na View Create de Produto;
- Crie o _PartialEditContentPanel e implemente nas views create e edit de produto;
- Incrementar JqueryUi (pode ou não incrementar);
- Ajustar todos os htmls.
# VII - AREAS, AUTENTICAÇÃO E AUTORIZAÇÃO
- Criar Areas;
- Ajustar as Views e Controllers de Areas;
- Instalar pacotes;
- Configurar Web.Config;
- Criação Usuarios;
- Criação IdentityDbContextAplicacao
- Criação GerenciadorUsuario;
- Criação IdentityConfig;
- Criação Controller AdminController em Seguranca;
- Criado bd IdentityDB;
- Criar o crud do Usuario;
- Criar Controlador HomeController em Controller, na raiz do projeto.
# VIII - UPLOADS, DOWNLOADS E ERROS
- Incrementar na tabela produtos;
- Alterar o Post de Create e Edit;
- Criar o método SetLogotipo;
- Download de imagens;
- Erros de páginas.