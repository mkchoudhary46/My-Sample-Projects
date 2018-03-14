using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core.DAO;
using LifeLine.Core.RepositoryInterfaces;

namespace LifeLine.Infrastructure.Repository
{
    public class BloodDonorRepository : IBloodDonorRepository
    {
        readonly BloodDonorContext _context = new BloodDonorContext();  
        public void Add(BloodDonor b)
        {
            _context.BloodDonors.Add(b);
            _context.SaveChanges(); 
        }

        public void Edit(BloodDonor b)
        {
            _context.Entry(b).State = System.Data.Entity.EntityState.Modified;
        }

        public void Remove(string bloodDonorId)
        {
            BloodDonor b = _context.BloodDonors.Find(bloodDonorId);
            _context.BloodDonors.Remove(b);
            _context.SaveChanges(); 
        }

        public IEnumerable<BloodDonor> GetBloodDonors()
        {
            return _context.BloodDonors; 
        }

        public BloodDonor FindById(string bloodDonorId)
        {
            var bloodDonor = (from r in _context.BloodDonors where r.BloodDonorId == bloodDonorId select r).FirstOrDefault();
            return bloodDonor;  
        }
    }
}
