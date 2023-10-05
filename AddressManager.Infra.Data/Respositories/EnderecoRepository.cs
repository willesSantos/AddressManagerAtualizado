using AddressManager.Domain.Interfaces;
using AddressManager.Domain.Models.Context;
using AddressManager.Domain.Models;
using AutoMapper;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace AddressManager.Infra.Data.Respositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly SqlContext _context;
        private readonly IMapper _mapper;

        public EnderecoRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Endereco>> FindAll(int skip, int take)
        {
            List<Endereco> enderecos = await _context.endereco
            .OrderBy(e => e.id)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

            return enderecos;
        }

        public async Task<Endereco> FindById(int id)
        {
            Endereco endereco = await _context.endereco.Where(p => p.id == id).FirstOrDefaultAsync();

            return endereco;
        }

        public async Task<Endereco> Create(Endereco enderecoIn)
        {
            _context.endereco.Add(enderecoIn);
            await _context.SaveChangesAsync();
            return enderecoIn;
        }

        public async Task<Endereco> Update(Endereco enderecoIn)
        {
            _context.endereco.Update(enderecoIn);
            await _context.SaveChangesAsync();

            return enderecoIn;
        }
        public async Task<bool> Delete(Endereco enderecoIn)
        {
            _context.endereco.Remove(enderecoIn);
            await _context.SaveChangesAsync();

            return true;
        }
        
    }
}
