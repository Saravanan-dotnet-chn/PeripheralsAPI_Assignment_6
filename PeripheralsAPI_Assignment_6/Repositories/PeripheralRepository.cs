using Microsoft.EntityFrameworkCore;
using PeripheralsAPI_Assignment_6.Data;
using PeripheralsAPI_Assignment_6.Models;

namespace PeripheralsAPI_Assignment_6.Repositories
{
    public class PeripheralRepository<T> : IPeripheralRepository<Peripheral>
    {


        private readonly AppDbContext _context;

        public PeripheralRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Peripheral>> GetAllAsync()
        {
            return await _context.Peripherals.ToListAsync();
        }

        public async Task<Peripheral> GetByIdAsync(int id)
        {
            return await _context.Peripherals.FindAsync(id);
        }
        public async Task<Peripheral> AddAsync(Peripheral peripheral)
        {
            peripheral.AddedDate = DateTime.Now;
            _context.Peripherals.Add(peripheral);
            await _context.SaveChangesAsync();
            return peripheral;
        }

        public async Task UpdateAsync(Peripheral peripheral)
        {
            _context.Entry(peripheral).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var peripheral = await _context.Peripherals.FindAsync(id);
            if (peripheral != null)
            {
                _context.Peripherals.Remove(peripheral);
                await _context.SaveChangesAsync();
            }
        }
    }
}