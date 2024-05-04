using Alojamiento.Domain.Entities;
using Alojamiento.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AlojamientoDbContext _dbContext;
        public ClienteRepository(AlojamientoDbContext context)
        {
            _dbContext = context;
        }
        public async Task<ClienteEntity> Create(ClienteEntity entity)
        {
            await _dbContext.Clientes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ClienteEntity> Delete(ClienteEntity entity)
        {
            _dbContext.Set<ClienteEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exist(int id)
        {
            return await _dbContext.Set<ClienteEntity>().AnyAsync(e => e.Id == id);
        }

        public List<ClienteEntity> GetAll()
        {
            var Clientes = _dbContext.Clientes
                .Include(x => x.TipoDocumento)
                .Include(x => x.Genero)
                .OrderBy(x => x.Id)
                .ToList();
            return Clientes;
        }

        public async Task<ClienteEntity> GetById(int id)
        {
            var Cliente = await _dbContext.Clientes
                .Include(x => x.TipoDocumento)
                .Include(x => x.Genero)
                .Where(x => x.Id == id).FirstAsync();
            return Cliente;
        }

        public async Task<ClienteEntity> Update(ClienteEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ClienteEntity> GetByDocument(string Documento)
        {
            var Cliente = await _dbContext.Clientes.Where(x => x.Documento == Documento).FirstOrDefaultAsync();
            return Cliente;
        }
    }
}
