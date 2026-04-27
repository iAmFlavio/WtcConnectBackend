🚀 WTC Connect - Backend API

Esta é a API RESTful principal do ecossistema WTC Connect, desenvolvida como projeto final para gerenciar clientes, campanhas de marketing e notificações em tempo real. O sistema foi construído com foco em alta performance, segurança e arquitetura escalável.
🛠️ Tecnologias Utilizadas

    C# / .NET 10: Framework principal da aplicação.

    MongoDB (NoSQL): Banco de dados orientado a documentos para alta flexibilidade.

    Autenticação JWT (JSON Web Tokens): Proteção e segurança avançada das rotas (Bearer Token).

    Firebase Cloud Messaging (FCM): Integração para envio de Push Notifications (Smartphones).

    Swagger (OpenAPI): Documentação interativa e interface de testes da API.

✨ Funcionalidades Principais

    Gestão de Clientes (CRM): CRUD completo para gerenciar os dados dos usuários VIP.

    Campanhas Express: Criação e registro de campanhas de marketing estruturadas.

    Mensageria Direta: Sistema de caixa de entrada (Inbox) para os clientes.

    Governança e Logs: Registro de auditoria (Audit Logs) para rastrear todas as ações dos operadores.

    Gatilho de Push Notifications: Disparo automático de notificações para dispositivos móveis via Firebase.

🔒 Segurança (Como testar)

A API é totalmente blindada. Para testar as rotas no Swagger:

    Faça um POST na rota /api/Auth/login com as credenciais padrão:

    Email: admin@wtc.com

    Password: admin123

    Copie o Token gerado na resposta.

    Clique no botão Authorize no topo do Swagger, cole o token e clique em Apply/Authorize.

🚀 Como Executar o Projeto Localmente
Pré-requisitos

    .NET 10 SDK

    Instância do MongoDB rodando localmente ou na nuvem.

    Chave de serviço do Firebase.

Passos

    Clone este repositório:
    git clone https://github.com/SEU_USUARIO/WtcConnectBackend.git

    Adicione o arquivo firebase-key.json (Chave de Serviço do Google) na raiz do projeto (este arquivo não está no repositório por questões de segurança).

    Restaure os pacotes e dependências:
    dotnet restore

    Execute o projeto:
    dotnet run

    Acesse o Swagger no navegador através de: http://localhost:5253/swagger

Projeto desenvolvido por Flávio para a Sprint Final.