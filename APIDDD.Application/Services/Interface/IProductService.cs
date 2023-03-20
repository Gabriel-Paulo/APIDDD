using APIDDD.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDDD.Application.Services.Interface
{
    public interface IProductService
    {
        Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO);
        Task<ResultService<ICollection<ProductDTO>>> GetAllAsync();
        Task<ResultService<ProductDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(ProductDTO personDTO);
        Task<ResultService> RemoveAsync(int id);
    }
}
