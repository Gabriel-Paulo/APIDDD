﻿using APIDDD.Domain.Entities;
using APIDDD.Domain.Repositories;
using APIDDD.infra.data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDDD.infra.data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonRepository(ApplicationDbContext db) 
        {
            _db = db;
        }
        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetIdByDocumentAsync(string document)
        {
            return (await _db.People.FirstOrDefaultAsync(x => x.Document == document))?.Id ?? 0;
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _db.People.ToListAsync();
        }
    }
}
