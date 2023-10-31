using AlunosAPI.Context;
using AlunosAPI.Models;
using AlunosAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlunosAPI.Services.Repositories
{
    public class AlunosRepository : IAlunosRepository
    {
        private readonly AppDbContext _context;

        public AlunosRepository(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<Aluno>> GetAlunos()
        {

            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByName(string name)
        {
            IEnumerable<Aluno> alunos;
            if (string.IsNullOrEmpty(name))
            {
                alunos = await _context.Alunos.Where(a => a.Nome.Contains(name)).ToListAsync();
            }
            else
            {
                alunos = await _context.Alunos.ToListAsync();
            }
            return alunos;
        }
        public async Task<Aluno> GetAluno(int id)
        {
            var alunos = await _context.Alunos.FindAsync(id);
            return alunos;
        }

        public async Task CreateAluno(Aluno aluno)
        {

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAluno(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
