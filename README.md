# 📌 TaskManagerApi

## 📖 Descrição
O **TaskManagerApi** é um projeto pessoal desenvolvido para auxiliar na organização da rotina diária.  
A API permite **gerenciar categorias** (ex.: "Trabalho", "Estudos", "Urgente") e associar **tarefas** a essas categorias, facilitando a separação entre atividades importantes e menos importantes.  

Com esse sistema, é possível ter um maior controle sobre prazos, prioridades e status de conclusão das tarefas.

---

## 🏗️ Arquitetura e Tecnologias Utilizadas
- **Arquitetura MVC** – separação clara entre Model, View e Controller.  
- **Entity Framework Core** – mapeamento objeto-relacional.  
- **DbContext** – para gerenciar o acesso ao banco de dados.  
- **SQL Server** – banco de dados relacional utilizado.  
- **Data Annotations** – validações e restrições aplicadas diretamente nos modelos.  
- **DTOs (Data Transfer Objects)** – para controlar as informações expostas e recebidas pela API.  
- **AutoMapper + Profiles** – para mapear automaticamente entidades ↔ DTOs.  
- **Swagger** – documentação interativa da API.  

---

## 📂 Estrutura de Relacionamentos
- **Category**  
  - Uma categoria pode ter várias tarefas (`1:N`).  

- **TaskOn**  
  - Cada tarefa pertence a apenas **uma categoria**.  

---

## 🚀 Funcionalidades
- Criar, atualizar, listar e excluir **categorias**.  
- Criar, atualizar, listar e excluir **tarefas**.  
- Associar tarefas a uma categoria.  
- Consultar todas as categorias junto com suas tarefas.  
- Filtrar uma categoria específica (ex.: "Urgente") e listar todas as tarefas relacionadas.  
- Retornar datas no formato legível (`dd/MM/yyyy HH:mm`).  

---

## 🛠️ Tecnologias
- **.NET 8**  
- **C#**  
- **Entity Framework Core**  
- **SQL Server**  
- **AutoMapper**  
- **Swagger**  

---
