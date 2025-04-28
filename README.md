# 📚 Estrutura de Pastas

```plaintext
/src

  /config
    db.js               # Conexão com o banco de dados

  /controllers
    authController.js   # Lógica de login/admin
    questoesController.js # Lógica para questões

  /models
    questaoModel.js     # Model de questões (interage com o banco)
    userModel.js        # Model de usuários/admin

  /routes
    authRoutes.js       # Rotas de login/admin
    questoesRoutes.js   # Rotas públicas de questões

  /views
    /partials
      header.ejs        # Cabeçalho padrão
      footer.ejs        # Rodapé padrão
      navbar.ejs        # Menu de navegação (público/admin)
    login.ejs           # Tela de login
    painelAdmin.ejs     # Painel para cadastrar questões
    listarQuestoes.ejs  # Listagem pública das questões
    questaoDetalhe.ejs  # Visualização de questão única

  /middlewares
    authMiddleware.js   # Protege rotas (admin logado)

  /public
    /css
      style.css         # Estilos customizados (e Bootstrap se quiser personalizado)
    /js
      script.js         # JS para ações (como avançar/voltar questões)

server.js               # Arquivo principal do Node

/database
  database.sql          # Criação do banco de dados

/package.json
