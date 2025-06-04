Workspace Backend para o sistema de questões de Instituições Federais de Ensino.

```
/SistemaQuestoesConcurso
│
├── Domain
│   ├── Questoes
│   │   ├── Entities (Questao, Comentario, Simulado)
│   │   ├── ValueObjects (Alternativa, Estatistica)
│   │   ├── Enums (NivelDificuldade)
│   │   ├── Interfaces (IQuestaoRepository, ISimuladoRepository)
│   │   └── Services (GeradorSimuladoService, EstatisticaService)
│   │
│   ├── Usuarios
│   │   ├── Entities (Usuario, Desempenho)
│   │   ├── Enums (PerfilUsuario)
│   │   ├── Interfaces (IUsuarioRepository)
│   │   └── Services (AutenticacaoService)
│   │
│   ├── Financeiro
│   │   ├── Entities (Plano, Assinatura, Pagamento)
│   │   ├── Enums (TipoPlano, StatusPagamento)
│   │   ├── Interfaces (IPagamentoService, IPlanoRepository)
│   │   └── Services (GestaoPlanoService)
│
├── Application
│   ├── Questoes
│   ├── Usuarios
│   └── Financeiro
│
├── Infrastructure
│   ├── Data (EF Core, MongoDB, etc.)
│   ├── Auth (JWT, OAuth)
│   └── PaymentGateway (Integração com MercadoPago, Stripe, etc.)
│
├── WebAPI
│   ├── Controllers
│   │   ├── QuestoesController
│   │   ├── UsuariosController
│   │   └── FinanceiroController
│   └── ViewModels / DTOs
│
└── Tests

