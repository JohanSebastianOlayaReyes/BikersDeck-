using AutoMapper;
using Back_end.Context;
using Data.Interface;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.Extensions.Logging;

namespace Business.Implements
{

    public class BaseBusiness<T, D> : ABaseBusiness<T, D> where T : BaseModel where D : BaseDto
    {

        protected readonly IMapper _mapper;

        protected readonly IBaseModelData<T> _data;

        protected readonly ILogger _logger;

        public BaseBusiness(
            IBaseModelData<T> data,
            IMapper mapper,
            ILogger logger)
            : base()
        {
            _data = data;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger;
        }

        public BaseBusiness(ApplicationDbContext context)
        {
        }

        public override async Task<List<D>> GetAllAsync()
        {
            try
            {
                var entities = await _data.GetAllAsync();
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(T).Name}");
                return _mapper.Map<IList<D>>(entities).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(T).Name}: {ex.Message}");
                throw;
            }
        }

        public override async Task<D> GetByIdAsync(int id)
        {
            try
            {
                var entities = await _data.GetByIdAsync(id);
                _logger.LogInformation($"Obteniendo {typeof(T).Name} con ID: {id}");
                return _mapper.Map<D>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener {typeof(T).Name} con ID {id}: {ex.Message}");
                throw;
            }
        }

        public override async Task<D> CreateAsync(D dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                entity = await _data.CreateAsync(entity);
                _logger.LogInformation($"Creando nuevo {typeof(T).Name}");
                return _mapper.Map<D>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear {typeof(T).Name} desde DTO: {ex.Message}");
                throw;
            }
        }

        public override async Task<D> UpdateAsync(D dto)
        {
            try
            {

                var entity = _mapper.Map<T>(dto);
                entity = await _data.UpdateAsync(entity);
                _logger.LogInformation($"Actualizando {typeof(T).Name} desde DTO");
                return _mapper.Map<D>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar {typeof(T).Name} desde DTO: {ex.Message}");
                throw;
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando {typeof(T).Name} con ID: {id}");
                return await _data.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar {typeof(T).Name} con ID {id}: {ex.Message}");
                throw;
            }
        }

    }
}