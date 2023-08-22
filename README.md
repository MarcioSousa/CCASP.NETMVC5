# A PRIMEIRA APLICAÇÃO ASP.NET MVC 5
## 1.1 - Criando o projeto no Visual Studio 2019 Community.
Selecione no menu o 'Create a new Project';
Selecione 'ASP.NET Web Application (.NET Framework)', linguagem 'C#';
Crie um nome para o Projeto;
Selecione 'Empty' e 'MVC';
Verifique se criaram as pastas:
Controllers, Models, Views
## 1.2 - Criando o Controlador para Categorias de Produtos.
Na Soluction Explorer, clique com o botão direito do mouse sobre a pasta Controllers e clique na opção Add -> Controller;
Na Janela que se abre, selecione o template MVC 5 Controller - Empty;
Clique com o botão Add;
Na janela que se apresenta, solicitando o nome do controlador, digite Categorias e mantenha o sufixo Controller, pois faz parte da convenção do ASP.NET MVC.
## 1.3 - Criando a classe de domínio para Categorias de produtos.
Na pasta Models, crie uma classe chamada Categoria da seguinte forma:
public long CategoriaId { get; set; } 
public string Nome { get; set; }
## 1.4 - Implementando a interação da Action Index com a visão.
Em CategoriasController crie os objetos:
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
		
		// GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }
		
		Antes de criar a View, dê um build em seu projeto;
		Ao criar a View, desmarque a caixa 'Use a layout page';
## 1.5 - Finalizando a aplicação por meio da implementação da operação Delete do Crud.
		Insira abaixo do código @Html.AntiForgeryToken() a implementação: @Html.HiddenFor(model => model.CategoriaId)
