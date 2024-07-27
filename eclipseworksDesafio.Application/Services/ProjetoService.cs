using eclipseworksDesafio.Application.Dtos.Enum;
using eclipseworksDesafio.Application.Dtos.Projeto;
using eclipseworksDesafio.Application.Dtos.Tarefa;
using eclipseworksDesafio.Application.Dtos.Usuario;
using eclipseworksDesafio.Application.Interfaces;
using eclipseworksDesafio.ApplicationApplication.Dtos.Projeto;
using eclipseworksDesafio.Core.Entities;
using eclipseworksDesafio.Core.Interfaces;

namespace eclipseworksDesafio.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IHistoricoTarefasRepository _historicoRepository;
        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<ProjetoGetDto> BuscarProjetoComTarefas(int projetoId)
        {
            var projeto = await _projetoRepository.BuscarProjetoComTarefas(projetoId);
            // Verifique se o projeto é nulo antes de mapear
            if (projeto == null) return null;

            // Mapeamento de entidade para DTO
            return new ProjetoGetDto
            {
                Id = projeto.Id,
                Descricao = projeto.Descricao,
                UsuarioId = projeto.UsuarioId,
                Usuario = new UsuarioGetDTO
                {
                    Id = projeto.Usuario.Id,
                    Nome = projeto.Usuario.Nome
                },
                Tarefas = projeto.Tarefas.Select(t => new TarefaGetDto
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao,
                    Status = (Enums.StatusTarefa)t.Status,
                    Prioridade = (Enums.PrioridadeTarefa)t.Prioridade,
                    ProjetoId = t.ProjetoId
                }).ToList(),
                Ativo = projeto.Ativo,
                CriadoEm = projeto.CriadoEm,
                DtExclusao = projeto.DtExclusao,
                Observacao = projeto.Observacao
            };
        }

        public async Task<IEnumerable<ProjetoGetDto>> BuscarProjetosPorUsuarioId(int usuarioId)
        {
            var projetos = await  _projetoRepository.BuscarProjetosPorUsuarioId(usuarioId);
            if (projetos == null) return null;

            // Mapeamento de entidade para DTO
            return projetos.Select(p => new ProjetoGetDto
            {
                Id = p.Id,
                Descricao = p.Descricao,
                UsuarioId = p.UsuarioId,
                Usuario = new UsuarioGetDTO
                {
                    Id = p.Usuario.Id,
                    Nome = p.Usuario.Nome
                },
                Tarefas = p.Tarefas.Select(t => new TarefaGetDto
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao,
                    Status = (Enums.StatusTarefa)t.Status,
                    Prioridade = (Enums.PrioridadeTarefa)t.Prioridade,
                    ProjetoId = t.ProjetoId
                }).ToList(),
                Ativo = p.Ativo,
                CriadoEm = p.CriadoEm,
                DtExclusao = p.DtExclusao,
                Observacao = p.Observacao
            });
        }

        public Task<int> ContarTarefasPorProjeto(int projetoId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjetoGetDto> GetId(int projetoId)
        {
            var projeto = await _projetoRepository.GetId(projetoId);
            if (projeto == null) return null;

            return new ProjetoGetDto
            {
                Id = projeto.Id,
                Descricao = projeto.Descricao,
                UsuarioId = projeto.UsuarioId,
                Usuario = new UsuarioGetDTO
                {
                    Id = projeto.Usuario.Id,
                    Nome = projeto.Usuario.Nome
                },
                Tarefas = projeto.Tarefas.Select(t => new TarefaGetDto
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao,
                    Status = (Enums.StatusTarefa)t.Status,
                    Prioridade = (Enums.PrioridadeTarefa)t.Prioridade,
                    ProjetoId = t.ProjetoId
                }).ToList(),
                Ativo = projeto.Ativo,
                CriadoEm = projeto.CriadoEm,
                DtExclusao = projeto.DtExclusao,
                Observacao = projeto.Observacao
            };
        }


        public async Task<IEnumerable<ProjetoGetDto>> ListarProjetos()
        {
            var projetos =await _projetoRepository.ListarProjetos();
           
            if (projetos == null) return null;

            return projetos.Select(p => new ProjetoGetDto
            {
                Id = p.Id,
                Descricao = p.Descricao,
                UsuarioId = p.UsuarioId,
                Usuario = new UsuarioGetDTO
                {
                    Id = p.Usuario.Id,
                    Nome = p.Usuario.Nome
                },
                Tarefas = p.Tarefas.Select(t => new TarefaGetDto
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao,
                    Status = (Enums.StatusTarefa)t.Status,
                    Prioridade = (Enums.PrioridadeTarefa)t.Prioridade,
                    ProjetoId = t.ProjetoId
                }).ToList(),
                Ativo = p.Ativo,
                CriadoEm = p.CriadoEm,
                DtExclusao = p.DtExclusao,
                Observacao = p.Observacao
            });
        }

        public async Task<IEnumerable<ProjetoGetDto>> ListarProjetosAtivos()
        {
            var projetos= await _projetoRepository.ListarProjetosAtivos();
            if (projetos == null) return null;

            return projetos.Select(p => new ProjetoGetDto
            {
                Id = p.Id,
                Descricao = p.Descricao,
                UsuarioId = p.UsuarioId,
                Usuario = new UsuarioGetDTO
                {
                    Id = p.Usuario.Id,
                    Nome = p.Usuario.Nome
                },
                Tarefas = p.Tarefas.Select(t => new TarefaGetDto
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao,
                    Status = (Enums.StatusTarefa)t.Status,
                    Prioridade = (Enums.PrioridadeTarefa)t.Prioridade,
                    ProjetoId = t.ProjetoId
                }).ToList(),
                Ativo = p.Ativo,
                CriadoEm = p.CriadoEm,
                DtExclusao = p.DtExclusao,
                Observacao = p.Observacao
            });
        }

        public Task<bool> RemoverProjeto(int projetoId)
        {
           return _projetoRepository.RemoverProjeto(projetoId);
        }


        public async Task<IEnumerable<TarefaGetDto>> GetTarefasDoProjeto(int projetoId)
        {
            var tarefas = await _projetoRepository.GetTarefasDoProjeto(projetoId);
            if (tarefas == null) return null;

            return tarefas.Select(t => new TarefaGetDto
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Status = (Enums.StatusTarefa)t.Status, 
                Prioridade = (Enums.PrioridadeTarefa)t.Prioridade,
                CriadoEm = t.CriadoEm,
                ProjetoId = t.ProjetoId,
                Titulo = t.Titulo,

            });
        }

        public async Task<ProjetoGetDto> AlterarProjeto(int projetoId, ProjetoAlterarDto projeto)
        {
            var projetoExistente = await _projetoRepository.GetId(projetoId);
            if (projetoExistente == null) return null;

            projetoExistente.Descricao = projeto.Descricao;
            projetoExistente.Ativo = projeto.Ativo;
            projetoExistente.Observacao = projeto.Observacao;
            projetoExistente.UsuarioId = projeto.UsuarioId;
            
            var result = await _projetoRepository.AlterarProjeto(projetoId, projetoExistente);    
         
            
            return  new ProjetoGetDto
            {
                Id = projeto.Id,
                Descricao = projeto.Descricao,
                UsuarioId = projeto.UsuarioId,              
             
                Ativo = projeto.Ativo,
                Observacao = projeto.Observacao
            };
        }

        public async Task<ProjetoGetDto> CriarProjeto(ProjetoCreateDto projetoCreateDto)
        {

            var projeto = new Projeto
            {
                Descricao = projetoCreateDto.Descricao,
                UsuarioId = projetoCreateDto.UsuarioId,
                Ativo = projetoCreateDto.Ativo,
                Observacao = projetoCreateDto.Observacao,
                CriadoEm = projetoCreateDto.CriadoEm
            };
            if (projetoCreateDto.Tarefas != null)
            {
                projeto.Tarefas = projetoCreateDto.Tarefas.Select(tarefaDto => new Tarefa
                {
                    Titulo = tarefaDto.Titulo,
                    Descricao = tarefaDto.Descricao,
                    Status = tarefaDto.Status,
                    Prioridade = tarefaDto.Prioridade,
                    ProjetoId = projeto.Id
                }).ToList();
            }

            
            var projetoCriado = await _projetoRepository.CriarProjeto(projeto);

            
            return new ProjetoGetDto
            {
                Id = projetoCriado.Id,
                Descricao = projetoCriado.Descricao,
                UsuarioId = projetoCriado.UsuarioId,
                Usuario = new UsuarioGetDTO
                {
                    Id = projetoCriado.Usuario.Id,
                    Nome = projetoCriado.Usuario.Nome
                },
                Tarefas = projetoCriado.Tarefas.Select(t => new TarefaGetDto
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao,
                    Status = (Enums.StatusTarefa)t.Status,
                    Prioridade = (Enums.PrioridadeTarefa)t.Prioridade,
                    ProjetoId = t.ProjetoId
                }).ToList(),
                Ativo = projetoCriado.Ativo,
                CriadoEm = projetoCriado.CriadoEm,
                DtExclusao = projetoCriado.DtExclusao,
                Observacao = projetoCriado.Observacao
            };
        }
    }
}
