using eclipseworksDesafio.Application.Dtos.Enum;
using eclipseworksDesafio.Application.Dtos.Tarefa;
using eclipseworksDesafio.Core.Entities;
using eclipseworksDesafio.Core.Interfaces;

namespace eclipseworksDesafio.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        private readonly IHistoricoTarefasRepository _historicoRepository;
        public TarefaService(ITarefaRepository tarefaRepository, IHistoricoTarefasRepository historicoRepository)
        {
            _tarefaRepository = tarefaRepository;
            _historicoRepository = historicoRepository;
        }
        public async Task<TarefaAlterarDto> AtualizarTarefa(int tarefaId, TarefaAlterarDto tarefaAlterarDto)
        {
            var tarefas = await _tarefaRepository.GetId(tarefaId);
            if (tarefas == null)
            {
                return null;
            }
            else
            {
                if (tarefaAlterarDto.Descricao != null)
                {
                    tarefas.Descricao = tarefaAlterarDto.Descricao;
                }
                if (tarefaAlterarDto.Titulo != null)
                {
                    tarefas.Titulo = tarefaAlterarDto.Titulo;
                }
                if (tarefaAlterarDto.Status != null)
                {
                    tarefas.Status = tarefaAlterarDto.Status;
                }
               
               


                var Result = await _tarefaRepository.AtualizarTarefa(tarefaId, tarefas);
                if (Result != null)
                {
                    string descricaoHistorico = ObterDescricaoHistorico(tarefas, tarefaAlterarDto);
                    if (!string.IsNullOrEmpty(descricaoHistorico))
                    {
                        var historico = new HistoricoTarefa
                        {
                            Descricao = descricaoHistorico,
                            UsuarioId = Result.Projeto.UsuarioId,
                            TarefaId = tarefaId,
                            CriadoEm = DateTime.Now
                        };

                        await _historicoRepository.AdicionarHistorico(historico);
                    }

                }
                return new TarefaAlterarDto
                {
               
                    Descricao = tarefas.Descricao,
                    Status = tarefas.Status,                  
                    Titulo = tarefas.Titulo,

                };

               
            }
        }

        public async Task<TarefaCreateDto> CriarTarefa(TarefaCreateDto tarefaCreateDto)
        {

            try
            {
                var dto = new Tarefa
                {
                    Titulo = tarefaCreateDto.Titulo,
                    Descricao = tarefaCreateDto.Descricao,
                    CriadoEm = DateTime.Now, // Você pode definir manualmente ou no construtor da Tarefa
                    Status = tarefaCreateDto.Status,
                    Prioridade = tarefaCreateDto.Prioridade,
                    ProjetoId = tarefaCreateDto.ProjetoId
                };
                var tarefa = await _tarefaRepository.CriarTarefa(dto);
                var createDto = new TarefaCreateDto
                {
                    Titulo = tarefa.Titulo,
                    Descricao = tarefa.Descricao,
                    CriadoEm = DateTime.Now, // Você pode definir manualmente ou no construtor da Tarefa
                    Status = tarefa.Status,
                    Prioridade = tarefa.Prioridade,
                    ProjetoId = tarefa.ProjetoId
                };
                return createDto;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        public async Task<TarefaGetDto> GetId(int tarefaId)
        {
            var tarefas = await _tarefaRepository.GetId(tarefaId);
            if (tarefas == null) return null;

            return new TarefaGetDto
            {
                Id = tarefas.Id,
                Descricao = tarefas.Descricao,
                Status = (Enums.StatusTarefa)tarefas.Status,
                Prioridade = (Enums.PrioridadeTarefa)tarefas.Prioridade,
                CriadoEm = tarefas.CriadoEm,
                ProjetoId = tarefas.ProjetoId,
                Titulo = tarefas.Titulo,

            };
        }

        public async Task<IEnumerable<TarefaGetDto>> GetTarefasDoProjeto(int projetoId)
        {
            var tarefas = await _tarefaRepository.GetTarefasDoProjeto(projetoId);
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

        public async Task<IEnumerable<TarefaGetDto>> ListarTarefas()
        {
            try
            {

                var tarefas = await _tarefaRepository.ListarTarefas();

                var tarefaDtos = tarefas.Select(tarefa => new TarefaGetDto
                {
                    Id = tarefa.Id,
                    Titulo = tarefa.Titulo,
                    Descricao = tarefa.Descricao,
                    CriadoEm = tarefa.CriadoEm,
                    Status = (Enums.StatusTarefa)tarefa.Status,
                    Prioridade = (Enums.PrioridadeTarefa)tarefa.Prioridade,
                    ProjetoId = tarefa.ProjetoId
                });

                return tarefaDtos;
            }
            catch (Exception ex)
            {
                // Log o erro ou trate conforme necessário
                throw new ApplicationException("Erro ao listar tarefas", ex);
            }

        }

        public async Task<bool> RemoverTarefa(int tarefaId)
        {
            try
            {
                var tarefa = await _tarefaRepository.RemoverTarefa(tarefaId);
                if (!tarefa)
                {
                    throw new Exception("Tarefa não encontrada");
                }
                return true;

            }
            catch (Exception erro)
            {

                throw erro;
            }

        }

        private string ObterDescricaoHistorico(Tarefa tarefa, TarefaAlterarDto tarefaAlterarDto)
        {
            var descricao = string.Empty;

            if (tarefa.Titulo != tarefaAlterarDto.Titulo && tarefaAlterarDto.Titulo != null)
            {
                descricao += $"Título alterado de '{tarefa.Titulo}' para '{tarefaAlterarDto.Titulo}'. ";
            }

            if (tarefa.Descricao != tarefaAlterarDto.Descricao && tarefaAlterarDto.Descricao != null)
            {
                descricao += $"Descrição alterada de '{tarefa.Descricao}' para '{tarefaAlterarDto.Descricao}'. ";
            }

            if (tarefa.Status != tarefaAlterarDto.Status && tarefaAlterarDto.Status != null)
            {
                descricao += $"Status alterado de '{tarefa.Status}' para '{tarefaAlterarDto.Status}'. ";
            }



            return descricao.Trim();
        }
    }
}
